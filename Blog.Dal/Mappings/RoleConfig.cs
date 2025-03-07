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
    public class RoleConfig : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {// default config on https://learn.microsoft.com/tr-tr/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-8.0

            builder.HasKey(r => r.Id);

           
            builder.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

           
            builder.ToTable("AspNetRoles");

        
            builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

         
            builder.Property(u => u.Name).HasMaxLength(256);
            builder.Property(u => u.NormalizedName).HasMaxLength(256);

          

           
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

            builder.HasMany<AppRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();

            builder.HasData(new AppRole
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN"

            },
            new AppRole
            {
                Id = 2,
                Name = "User",
                NormalizedName = "USER"

            }

            );
        
        }
    }
}
