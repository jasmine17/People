using People.Models;

namespace People.data
{
    public class Seed
    {
       
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<UserContext>();

                context.Database.EnsureCreated();
                {
                    if (context.Users.Any())
                    {
                        return;
                    }

                    context.Users.AddRange(
                    new Users
                    {
                        Name = "Gary Chester",
                        Email = "GaryChester@gmail.com",
                        Password = "chesterPasswordISTRONG!",
                        PhoneNumber = "0900780601",
                        IsActive = true
                    },

                    new Users
                    {
                        Name = "Randy Kline",
                        Email = "Randy@Kline@.com",
                        Password = "Qwertyuiop!",
                        PhoneNumber = "0110885621",
                        IsActive = true
                    },

                    new Users
                    {
                        Name = "Mccauley Doherty",
                        Email = "Doherty@outlook.com",
                        Password = "password1!",
                        PhoneNumber = "0213778509",
                        IsActive = true
                    },

                    new Users
                    {
                        Name = "Louise Lyons",
                        Email = "Louise@gmail.com",
                        Password = "Es!u0l$n0yl",
                        PhoneNumber = "0753154952",
                        IsActive = true
                    }
                );
                    context.SaveChanges();
                }
            }
        }
    }
}
