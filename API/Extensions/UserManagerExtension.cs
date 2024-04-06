
using System.Security.Claims;
using core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class UserManagerExtension
    {
     public static async Task<AppUser>   FindByEmailWithAddressAsync(this UserManager<AppUser> usermanager, ClaimsPrincipal claims)
     {
        var email= claims.RetrieveEmailFromPrincipal();
        
        return await usermanager.Users.Include(x=> x.Address).SingleOrDefaultAsync(x=> x.Email == email);
     }

      public static async Task<AppUser>   FindByEmailFromClaimsPrincipalAsync(this UserManager<AppUser> usermanager, ClaimsPrincipal claims)
     {
        var email= claims.RetrieveEmailFromPrincipal();
        
        return await usermanager.Users.SingleOrDefaultAsync(x=> x.Email == email);
     }

    }
}