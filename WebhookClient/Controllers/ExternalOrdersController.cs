using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebhookClient.Models;

namespace WebhookClient.Controllers
{
    [Route("[controller]")]
    public class ExternalOrders : ControllerBase
    {
        private readonly ILogger<ExternalOrders> _logger;

        public ExternalOrders(ILogger<ExternalOrders> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult HandleOrderCreated([FromBody] CreateOrderViewModel order)
        {
            _logger.LogInformation($"order with id {order.Id} received");

            return Ok();
        }
    }
}
