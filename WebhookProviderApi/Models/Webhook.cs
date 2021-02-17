namespace WebhookProviderApi.Models
{
    public class Webhook
    {
        public string Endpoint { get; }
        public string Event { get; }

        public Webhook(string endpoint, string @event)
        {
            Endpoint = endpoint;
            Event = @event;
        }
    }
}
