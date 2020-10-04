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
    /// Controller responsável por operações de chamada Api Modelos
    /// </summary>
    [ApiController]
    public class ModeloController : BaseController
    {
        private readonly IModeloRepository _repository;

        /// <summary></summary>
        /// <param name="uow"></param>
        /// <param name="repository"></param>
        public ModeloController(IUow uow, IModeloRepository repository) : base(uow)
        {
            _repository = repository;
        }

        /// <summary>
        /// Lista modelos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]")]
        [ProducesResponseType(typeof(List<ListarModeloQueryResult>), 200)]
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