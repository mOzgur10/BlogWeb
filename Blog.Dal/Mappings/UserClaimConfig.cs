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
    public class UserClaimConfig : IEntityTypeConfiguration<AppUserClaim>
    {// default config on https://learn.microsoft.com/tr-tr/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-8.0
        public void Configure(EntityTypeBuilder<AppUserClaim> builder)
        {
           
            builder.HasKey(uc => uc.Id);

           
            builder.ToTable("AspNetUserClaims");
        }
    }
}
