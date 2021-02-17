using MediatR;
using WebhookProviderApi.Models;

namespace WebhookProviderApi.Events
{
    public class OrderCreated : INotification, IRequest
    {
        public CreateOrderViewModel Order { get; }

        public OrderCreated(CreateOrderViewModel order)
        {
            Order = order;
        }
    }
}
