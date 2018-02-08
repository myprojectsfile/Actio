using System;
using Actio.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using System.Threading.Tasks;

namespace Actio.Api.Controllers {
    [Route ("[controller]")]
    public class ActivitiesController : Controller {
        public readonly IBusClient _busClient;
        public ActivitiesController (IBusClient busClient) {
            _busClient = busClient;
        }

        [HttpPost ("")]
        public async Task<IActionResult> Post ([FromBody] CreateActivity command) {
            command.Id = Guid.NewGuid ();
            command.CreatedAt = DateTime.UtcNow;
            await _busClient.PublishAsync (command);
            return Accepted ($"activities/command.Id");

        }
    }
}