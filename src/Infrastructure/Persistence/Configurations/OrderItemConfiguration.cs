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
    internal sealed class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(orderItem => orderItem.Id);

            builder.Property(orderItem => orderItem.Id).ValueGeneratedOnAdd();

            builder.Property(orderItem => orderItem.OrderId).IsRequired();

            builder.Property(orderItem => orderItem.ItemId).IsRequired();

        }
    }
}
