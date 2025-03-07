using Blog.Data.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dal.Mappings
{
    public class UserRoleConfig : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // default config on https://learn.microsoft.com/tr-tr/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-8.0
            builder.HasKey(r => new { r.UserId, r.RoleId });

            builder.ToTable("AspNetUserRoles");

            builder.HasData(new AppUserRole()
            {
                UserId = 1,
                RoleId = 1
            },
            new AppUserRole()
            {
                UserId=2,
                RoleId = 2
            }
            );
        }
    }
}
