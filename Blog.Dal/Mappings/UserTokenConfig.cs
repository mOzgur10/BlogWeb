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
    public class UserTokenConfig : IEntityTypeConfiguration<AppUserToken>
    {
        public void Configure(EntityTypeBuilder<AppUserToken> builder)
        {
            // default config on https://learn.microsoft.com/tr-tr/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-8.0

            builder.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

            
            builder.Property(t => t.LoginProvider);
            builder.Property(t => t.Name);

            
            builder.ToTable("AspNetUserTokens");
        }
    }
}
