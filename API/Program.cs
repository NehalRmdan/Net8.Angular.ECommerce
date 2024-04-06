
using Infrastructure.Data;
using core.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using IInfrastructure.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using API.Helper;
using API.Middleware;
using Microsoft.AspNetCore.Mvc;
using API.Errors;
using API.Extensions;
using StackExchange.Redis;
using Humanizer.Configuration;
using Infrastructure.Identity;
using core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration= builder.Configuration;
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerDocumentation();
        
        builder.Services.AddDbContext<StoreContext>(options=> 
        options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        
        builder.Services.AddDbContext<AppIdentityDbContext>(options =>
        options.UseSqlite(configuration.GetConnectionString("IdentityConnection")));

        builder.Services.AddSingleton<IConnectionMultiplexer>(c => {
            var config= ConfigurationOptions.Parse(configuration.GetConnectionString("Redis"));
            return ConnectionMultiplexer.Connect(config);
        });

        builder.Services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy", policy =>
            {
                policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200","https://localhost:7105");
            });
        });

        builder.Services.AddAutoMapper(typeof(MappingProfiles));

        builder.Services.AddApplicationServices();

        builder.Services.ConfigureIdentity(configuration);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerDocumentation();
        }

       app.UseStatusCodePagesWithReExecute("/errors/{0}");
         
        app.UseMiddleware<ExcptionMiddleware>();

   //for production environment it is recommended to use generation scripts from migrations
         using (var scope = app.Services.CreateScope())
         {
        var db = scope.ServiceProvider.GetRequiredService<StoreContext>();
        db.Database.Migrate();

        StoreCotenxtDataSeeding.SeedData(db);
        }

        using (var scope = app.Services.CreateScope())
         {
        var db = scope.ServiceProvider.GetRequiredService<AppIdentityDbContext>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

        db.Database.Migrate();

        await AppIdentityDbContextSeed.SeedUsersAsync(userManager);
        }

        app.UseHttpsRedirection();

        app.UseRouting();
        app.UseStaticFiles();

        app.MapControllers();

       app.UseCors("CorsPolicy");
       app.UseAuthorization();

        app.Run();
    }
}
