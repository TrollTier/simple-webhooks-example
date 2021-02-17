using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebhookProviderApi.Events;
using WebhookProviderApi.Models;
using WebhookProviderApi.Service;

namespace WebhookProviderApi.EventHandler
{
    public class OrdersEventHandler
        : INotificationHandler<OrderCreated>
    {
        private readonly IWebhookService _webhookService;

        public OrdersEventHandler(IWebhookService webhookService)
        {
            _webhookService = webhookService;
        }

        public async Task Handle(OrderCreated notification, CancellationToken cancellationToken)
        {
            await _webhookService.CallListeners(AvailableEvents.OrderCreated, notification.Order);
        }
    }
}
