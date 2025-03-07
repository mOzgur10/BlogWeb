using Blog.Data.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dal.Mappings
{
    public class UserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
           
            builder.HasKey(u => u.Id);
            // default config on https://learn.microsoft.com/tr-tr/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-8.0

            builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

            
            builder.ToTable("AspNetUsers");

           
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

           
            builder.Property(u => u.UserName).HasMaxLength(256);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

            builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

           
            builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

           
            builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

            var admin = new AppUser()
            {
                Id = 1,
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "ADMIN@ADMIN.COM",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                FirstName = "Mertcan",
                LastName = "Ozgur",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var kullanici= new AppUser()
            {
                Id = 2,
                UserName = "kullanici@kullanici.com",
                NormalizedUserName = "KULLANICI@KULLANICI.COM",
                Email = "KULLANICI@KULLANICI.COM",
                NormalizedEmail = "KULLANICI@KULLANICI.COM",
                FirstName = "Kaan",
                LastName = "binici",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()

            };
            admin.PasswordHash = CreatePassword(admin, "Admin123");
            kullanici.PasswordHash = CreatePassword(kullanici, "Kullanici123");

            builder.HasData(admin, kullanici);
        }
        private string CreatePassword(AppUser user, string pass)
        {
            var hasher = new PasswordHasher<AppUser>();
            return hasher.HashPassword(user, pass);
        }
    }
}
