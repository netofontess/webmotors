using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using SalesForce.API.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMotors.Domain.Commands;
using WebMotors.Domain.Commands.Result;
using WebMotors.Domain.Entities;
using WebMotors.Domain.Handlers;
using WebMotors.Domain.Interfaces.Repository;
using WebMotors.Shared.Transactions;

namespace WebMotors.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnuncioController : BaseController
    {
        private readonly AnuncioWebMotorsCommandHandler _handler;
        private readonly IAnuncioWebMotorsRepository _repository;

        public AnuncioController(IUow uow, AnuncioWebMotorsCommandHandler handler, IAnuncioWebMotorsRepository repository) : base(uow)
        {
            _handler = handler;
            _repository = repository;
        }

        /// <summary>
        /// Cria anuncio novo
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(CommandResult), 200)]
        [ProducesResponseType(typeof(List<Notification>), 400)]
        public async Task<IActionResult> Post([FromBody] AnuncioWebMotorsCommand command)
        {
            try
            {
                return await Response(_handler.Handle(command), _handler.Notifications);
            }
            catch (Exception e)
            {
                return await ResponseException(e);
            }
        }
    }
}