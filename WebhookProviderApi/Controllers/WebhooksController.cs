using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebhookProviderApi.Models;
using WebhookProviderApi.Service;

namespace WebhookProviderApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WebhooksController : ControllerBase
    {
        private IWebhookService _webhookService;

        public WebhooksController(IWebhookService webhookService)
        {
            _webhookService = webhookService;
        }

        [HttpPost]
        public IActionResult Register(WebhookRegistrationViewModel registration)
        {
            if (registration == null)
                return BadRequest("webhook data must be provided");

            if (string.IsNullOrWhiteSpace(registration.EndpointUrl))
                return BadRequest("endpoint url must be provided");

            if (!AvailableEvents.GetAll.Contains(registration.Event))
                return BadRequest($"{registration.Event} is not a supported webhook event");

            _webhookService.AddWebhook(registration);

            return NoContent();
        }
    }
}
