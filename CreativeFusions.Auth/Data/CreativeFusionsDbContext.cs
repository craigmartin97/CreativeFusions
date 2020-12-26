using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CreativeFusions.Auth.Data
{
    public class CreativeFusionsDbContext : IdentityDbContext<AppUser>
    {
        public CreativeFusionsDbContext(DbContextOptions<CreativeFusionsDbContext> options)
            : base(options)
        { }
    }
}