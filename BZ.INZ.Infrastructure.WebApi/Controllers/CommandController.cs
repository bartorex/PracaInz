using Autofac.Features.Indexed;
using BZ.INZ.Application.Core.Command;
using BZ.INZ.Application.IoC.CommandHandlerInvoker;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BZ.INZ.Infrastructure.WebApi.Controllers {
    [RoutePrefix("command")]
    public class CommandController : ApiController {
        private readonly ICommandHandlerInvoker invoker;
        private readonly IIndex<string, ICommand> commands;

        public CommandController(
            ICommandHandlerInvoker invoker,
            IIndex<string, ICommand> commands) {
            this.invoker = invoker;
            this.commands = commands;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromUri] string id, [FromBody] JObject body) {
            var command = commands[string.Concat(id, "Command")];
            command = (ICommand)body.ToObject(command.GetType());

            CommandResult result = await InvokeCommandHandler(command);

            return Ok(result);
        }

        private Task<CommandResult> InvokeCommandHandler(ICommand command) {
            try {
                return invoker.Invoke(command);
            } catch (Exception exp) {
                throw new HttpResponseException(new HttpResponseMessage {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Content = new StringContent(exp.Message)
                });
            }
        }
    }
}