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
    internal sealed class ItemCategoryConfiguration : IEntityTypeConfiguration<ItemCategory>
    {
        public void Configure(EntityTypeBuilder<ItemCategory> builder)
        {
            builder.HasKey(itemCategory => itemCategory.Id);

            builder.Property(itemCategory => itemCategory.Id).ValueGeneratedOnAdd();

            builder.Property(itemCategory => itemCategory.Name).IsRequired();

            builder.HasMany(itemCategory => itemCategory.Items)
                .WithOne(item => item.ItemCategory)
                .HasForeignKey(item => item.ItemCategoryId)
                .OnDelete(DeleteBehavior.Cascade);
           
        }

        
    }
}
