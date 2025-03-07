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
    public class RoleClaimConfig : IEntityTypeConfiguration<AppRoleClaim>
    {
        public void Configure(EntityTypeBuilder<AppRoleClaim> builder)
        {
            // default config on https://learn.microsoft.com/tr-tr/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-8.0
            builder.HasKey(rc => rc.Id);

            
            builder.ToTable("AspNetRoleClaims");
        }
    }
}
