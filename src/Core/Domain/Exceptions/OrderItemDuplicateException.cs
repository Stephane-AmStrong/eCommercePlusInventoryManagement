using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class OrderItemDuplicateException : DuplicateException
    {
        public OrderItemDuplicateException(OrderItem orderItem) : base($"An orderItem with Qte : {orderItem.Qte}, Total : {orderItem.Total}, ItemId : {orderItem.ItemId}, OrderId : {orderItem.OrderId} already exists")
        {
        }
    }
}
/*

*/
