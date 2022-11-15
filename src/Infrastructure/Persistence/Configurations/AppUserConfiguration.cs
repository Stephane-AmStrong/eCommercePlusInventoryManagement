using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    internal sealed class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(appUser => appUser.Id);

            builder.Property(appUser => appUser.Id).ValueGeneratedOnAdd();

            builder.Property(appUser => appUser.FirstName).IsRequired();

            builder.Property(appUser => appUser.LastName).IsRequired();


            builder.HasMany(appUser => appUser.Items)
                .WithOne(item => item.Seller)
                .HasForeignKey(item => item.SellerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(appUser => appUser.Orders)
                .WithOne(item => item.Customer)
                .HasForeignKey(item => item.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
