using System.Collections.Generic;
using System.Threading.Tasks;
using WebhookProviderApi.Models;

namespace WebhookProviderApi.Service
{
    public interface IWebhookService
    {
        void AddWebhook(WebhookRegistrationViewModel registration);
        IEnumerable<Webhook> GetWebhooksForEvent(string @event);
        Task CallListeners<T>(string @event, T data);
    }
}
