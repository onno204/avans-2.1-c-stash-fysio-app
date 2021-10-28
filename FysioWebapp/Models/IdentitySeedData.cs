using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FysioWebapp.Models
{
    public class IdentitySeedData
    {
        private const string AdminUser = "AdminUser";
        private const string AdminPassword = "Password123!";

        private const string PatientUser = "PatientUser";
        private const string PatientPassword = "Password123!";


        public static async Task EnsurePopulated(UserManager<IdentityUser> userManager)
        {
            IdentityUser user = await userManager.FindByIdAsync(AdminUser);
            if (user == null)
            {
                user = new IdentityUser(AdminUser);
                var res = await userManager.CreateAsync(user, AdminPassword);
                await userManager.AddClaimAsync(user, new Claim("Therapist", "true"));
            }

            IdentityUser player = await userManager.FindByIdAsync(PatientUser);
            if (player == null)
            {
                player = new IdentityUser(PatientUser);
                await userManager.CreateAsync(player, PatientPassword);
                await userManager.AddClaimAsync(user, new Claim("Patient", "true"));
            }
        }

    }
}