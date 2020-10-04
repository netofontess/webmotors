using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMotors.API.Controllers.Base;
using WebMotors.Domain.Entities;
using WebMotors.Domain.Filtros;
using WebMotors.Domain.Interfaces.Repository;
using WebMotors.Shared.Transactions;

namespace WebMotors.Api.Controllers
{
    /// <summary>
    /// Controller responsável por operações de chamada Api Marcas
    /// </summary>
    [ApiController]
    public class VersaoController : BaseController
    {
        private readonly IVersaoRepository _repository;

        /// <summary></summary>
        /// <param name="uow"></param>
        /// <param name="repository"></param>
        public VersaoController(IUow uow, IVersaoRepository repository) : base(uow)
        {
            _repository = repository;
        }

        /// <summary>
        /// Lista marcas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(List<ListarVersaoQueryResult>), 200)]
        public async Task<IActionResult> Get([FromQuery] Filtro filtro)
        {
            try
            {
                return await QueryResponse(await _repository.GetAll(filtro));
            }
            catch (Exception e) { return await ResponseException(e); }
        }
    }
}