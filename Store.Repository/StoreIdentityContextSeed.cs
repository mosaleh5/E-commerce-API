using Microsoft.AspNetCore.Identity;
using Store.Data.Entities.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class StoreIdentityContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Mohamed Saleh",
                    Email = "www.mosaleh@gmail.com",
                    UserName = "Mosaleh5",
                    Address = new Address
                    {
                        FirstName = "Mohamed",
                        LastName = "Saleh" ,
                        City = "Tamyyah",
                        State = "Fayoum",
                        Street = "23 july",
                        PostalCode = "12345"
                    }

                };
                await userManager.CreateAsync(user, "Password123@");
            }
        }
    }
}
