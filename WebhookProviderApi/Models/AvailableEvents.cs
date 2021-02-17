namespace WebhookProviderApi.Models
{
    public class AvailableEvents
    {
        public const string OrderCreated = "OrderCreated";

        public static string[] GetAll { get; } = new[]
        {
            OrderCreated
        };
    }
}
