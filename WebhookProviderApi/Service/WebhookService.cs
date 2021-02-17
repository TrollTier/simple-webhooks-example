using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebhookProviderApi.Models;

namespace WebhookProviderApi.Service
{
    public class WebhookService : IWebhookService
    {
        private List<Webhook> _webhooks = new List<Webhook>();

        private IHttpClientFactory _clientFactory;
        private ILogger<WebhookService> _logger;

        public WebhookService(
            IHttpClientFactory clientFactory, 
            ILogger<WebhookService> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }

        public void AddWebhook(WebhookRegistrationViewModel registration)
        {
            _webhooks.Add(new Webhook(registration.EndpointUrl, registration.Event));
        }

        public async Task CallListeners<T>(string @event, T data)
        {
            var listeners = GetWebhooksForEvent(@event);

            var client = _clientFactory.CreateClient();

            var serialized = JsonSerializer.Serialize(data);

            var content = new StringContent(
                serialized,
                Encoding.UTF8,
                "application/json");

            foreach (var listener in listeners)
            {
                _logger.LogInformation($"Sending {serialized} to {listener.Endpoint}");

                try
                {
                    await client.PostAsync(listener.Endpoint, content);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error while sending order created event to {listener.Endpoint}");
                    // Todo: retry logic
                }
            }
        }

        public IEnumerable<Webhook> GetWebhooksForEvent(string @event)
        {
            return _webhooks
                .Where(hook => string.Equals(hook.Event, @event, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
        }
    }
}
