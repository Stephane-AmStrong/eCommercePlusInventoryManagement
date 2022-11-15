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
    internal sealed class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(item => item.Id);

            builder.Property(item => item.Id).ValueGeneratedOnAdd();

            builder.Property(item => item.Name).IsRequired();

            builder.HasMany(item => item.InventoryLevels)
                .WithOne(inventoryLevel => inventoryLevel.Item)
                .HasForeignKey(inventoryLevel => inventoryLevel.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(item => item.OrderItems)
                .WithOne(orderItem => orderItem.Item)
                .HasForeignKey(orderItem => orderItem.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
