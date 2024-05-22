using Microsoft.EntityFrameworkCore;
using People.Models;

namespace People.data
{
    public class UserContext :DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { 
        }

        public DbSet<Users> Users { get; set; }
    }
}
