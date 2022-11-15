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
    internal sealed class InventoryLevelConfiguration : IEntityTypeConfiguration<InventoryLevel>
    {
        public void Configure(EntityTypeBuilder<InventoryLevel> builder)
        {
            builder.HasKey(inventoryLevel => inventoryLevel.Id);

            builder.Property(inventoryLevel => inventoryLevel.Id).ValueGeneratedOnAdd();

            builder.Property(inventoryLevel => inventoryLevel.UpdatedAt).IsRequired();

            //builder.HasOne(inventoryLevel => inventoryLevel.Item)
            //    .WithMany()
            //    .HasPrincipalKey(item => item.Id)
            //    .OnDelete(DeleteBehavior.Cascade);


        }
    }

    /*
     builder.HasMany(item => item.InventoryLevels)
                .WithOne()
                .HasForeignKey(inventoryLevel => inventoryLevel.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
     */
}
