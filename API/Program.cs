
using Infrastructure.Data;
using core.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using IInfrastructure.Data;

namespace API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration= builder.Configuration;
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddDbContext<StoreContext>(options=> 
        options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        
        builder.Services.AddScoped<IProductRepository,ProductRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(); 
        }

   //for production environment it is recommended to use generation scripts from migrations
         using (var scope = app.Services.CreateScope())
         {
        var db = scope.ServiceProvider.GetRequiredService<StoreContext>();
        db.Database.Migrate();

        StoreCotenxtDataSeeding.SeedData(db);
        }
        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
