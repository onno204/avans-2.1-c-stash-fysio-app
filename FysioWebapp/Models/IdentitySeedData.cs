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
            IdentityUser user = await userManager.FindByNameAsync(AdminUser);
            if (user == null)
            {
                user = new IdentityUser(AdminUser);
                await userManager.CreateAsync(user, AdminPassword);
                await userManager.AddClaimAsync(user, new Claim("Therapist", "true"));
            }

            IdentityUser patient = await userManager.FindByNameAsync(PatientUser);
            if (patient == null)
            {
                patient = new IdentityUser(PatientUser);
                await userManager.CreateAsync(patient, PatientPassword);
                await userManager.AddClaimAsync(patient, new Claim("Patient", "true"));
            }
        }
    }
}