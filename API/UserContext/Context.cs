using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.UserContext
{
    public class Context : IdentityDbContext<User>
    {
        public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }
    }
}
