using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebhookProviderApi.Events;
using WebhookProviderApi.Models;

namespace WebhookProviderApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderViewModel order)
        {
            // Validate and save to database

            var @event = new OrderCreated(order);

            await _mediator.Publish(@event);

            return Ok();
        }
    }
}
