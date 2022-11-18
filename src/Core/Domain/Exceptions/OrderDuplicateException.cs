using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class OrderDuplicateException : DuplicateException
    {
        public OrderDuplicateException(Order order) : base($"An order with Date : {order.Date}, Total : {order.Total}, CustomerId : {order.CustomerId} already exists")
        {
        }
    }
}

