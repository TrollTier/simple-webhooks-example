using System;
using System.Collections.Generic;

namespace WebhookProviderApi.Models
{
    public class OrderPositionViewModel
    {
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }

    public class CreateOrderViewModel
    {
        public Guid Id { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<OrderPositionViewModel> Positions { get; set; }
    }
}
