using System;
using Actio.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using System.Threading.Tasks;

namespace Actio.Api.Controllers {

    [Route ("[controller]")]

    public class UsersController : Controller {
        public readonly IBusClient _busClient;
        public UsersController (IBusClient busClient) {
            _busClient = busClient;
        }

        [HttpPost ("register")]
        public async Task<IActionResult> Post ([FromBody] CreateUser command) {
            await _busClient.PublishAsync (command);
            return Accepted ();
        }
    }
}