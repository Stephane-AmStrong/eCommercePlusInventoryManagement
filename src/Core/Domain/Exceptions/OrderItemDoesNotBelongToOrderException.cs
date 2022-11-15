using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class OrderItemDoesNotBelongToOrderException : BadRequestException
    {
        public OrderItemDoesNotBelongToOrderException(Guid orderId, Guid orderItemNo) : base($"The orderItem n° {orderId} does not belong to the order with the identifier {orderItemNo}")
        {
        }
    }
}
