using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMotors.API.Controllers.Base;
using WebMotors.Domain.Commands;
using WebMotors.Domain.Commands.Result;
using WebMotors.Domain.Entities;
using WebMotors.Domain.Filtros;
using WebMotors.Domain.Handlers;
using WebMotors.Domain.Interfaces.Repository;
using WebMotors.Shared.Transactions;

namespace WebMotors.Api.Controllers
{
    /// <summary>
    /// Controller responsável por operações na Tabela Anúncios Webmotors
    /// </summary>
    [ApiController]
    public class AnuncioController : BaseController
    {
        private readonly AnuncioWebMotorsCommandHandler _handler;
        private readonly IAnuncioWebMotorsRepository _repository;

        /// <summary></summary>
        /// <param name="uow"></param>
        /// <param name="handler"></param>
        /// <param name="repository"></param>
        public AnuncioController(IUow uow, AnuncioWebMotorsCommandHandler handler, IAnuncioWebMotorsRepository repository) : base(uow)
        {
            _handler = handler;
            _repository = repository;
        }

        /// <summary>
        /// Lista anúncios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(AnuncioWebmotors), 200)]
        public Task<IActionResult> Get()
        {
            try
            {
                return QueryResponse(_repository.GetAll());
            }
            catch (Exception e) { return ResponseException(e); }
        }
        
        /// <summary>
        /// Lista anúncio
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/filtro")]
        [ProducesResponseType(typeof(AnuncioWebmotors), 200)]
        public Task<IActionResult> Get([FromQuery] Filtro filtro)
        {
            try
            {
                return QueryResponse(_repository.GetAll(filtro));
            }
            catch (Exception e) { return ResponseException(e); }
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
        public async Task<IActionResult> Post([FromBody] CreateAnuncioWebMotorsCommand command)
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

        /// <summary>
        /// Alteração de Anúncio
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(CommandResult), 200)]
        [ProducesResponseType(typeof(List<Notification>), 400)]
        public async Task<IActionResult> Put([FromBody] UpdateAnuncioWebMotorsCommand command)
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

        /// <summary>
        /// Deletar anúncio
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(CommandResult), 200)]
        [ProducesResponseType(typeof(List<Notification>), 400)]
        public async Task<IActionResult> Delete([FromBody] DeleteAnuncioWebMotorsCommand command)
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