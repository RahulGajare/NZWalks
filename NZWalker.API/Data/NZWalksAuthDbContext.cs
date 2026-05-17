using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalker.API.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {

        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = Guid.Parse("d1b9c8e7-5c3a-4f0e-9b2a-1a2b3c4d5e6f");
            var writerRoleId = Guid.Parse("e2c8d9f8-6a4b-5f1e-0c3d-2b3c4d5e6f7a");

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId.ToString(),
                    ConcurrencyStamp =readerRoleId.ToString(),
                    Name = "reader",
                    NormalizedName = "READER"
                },
                 new IdentityRole
                {
                    Id = writerRoleId.ToString(),
                    ConcurrencyStamp =writerRoleId.ToString(),
                    Name = "writer",
                    NormalizedName = "Writer"
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
