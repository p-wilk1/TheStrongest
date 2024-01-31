using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheStrongest.API.Models.Domain;

namespace TheStrongest.API.Data
{
    public class AuthDbContext : IdentityDbContext<OwnUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "732e803c-3c0b-4cd2-a869-336b62d8ec82";
            var loggedRoleId = "0613a79a-7237-4acb-999e-5a8d5f82044a";

            //create roles
            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id = readerRoleId,
                    Name="Reader",
                    NormalizedName = "Reader".ToUpper(),
                    ConcurrencyStamp = readerRoleId
                },
                new IdentityRole()
                {
                    Id = loggedRoleId,
                    Name="LoggedUser",
                    NormalizedName = "LoggedUser".ToUpper(),
                    ConcurrencyStamp = loggedRoleId
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}