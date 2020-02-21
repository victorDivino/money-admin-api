using System;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyAdmin.Domain.Core.Commands;

namespace MoneyAdmin.WebApi.Controllers
{
    public class CustomController : Controller
    {
        private readonly IMediator _mediator;

        public CustomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult> SendCommand<T>(T command) where T : CommandBase
        {
            try
            {
                var commandResult = await _mediator.Send(command);

                if (!commandResult)
                    return StatusCode((int)HttpStatusCode.BadRequest, commandResult.Exception);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}