using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMotors.Shared.Transactions;

namespace WebMotors.API.Controllers.Base
{
    /// <summary>
    /// Controller base com Authorize a ser utilizado no projeto. Todos os controllers criados devem herdar de AuthorizeController ou AnonymousController
    /// </summary>
    public class BaseController : Controller
    {

        private readonly IUow _uow;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uow"></param>
        public BaseController(IUow uow)
        {
            _uow = uow;
        }

        /// <summary>
        /// Resposta a ser utilizada nas Actions de controllers que contém Commands
        /// </summary>
        /// <param name="result">O resultado do processamento do comando</param>
        /// <param name="notifications">A lista de notificações do Handler</param>
        /// <returns>Retorna a resposta conforme o resultado do processamento</returns>
        protected new async Task<IActionResult> Response(object result, IReadOnlyCollection<Notification> notifications)
        {
            if (!notifications.Any())
            {
                try
                {
                    _uow.Commit();
                    return Ok(new
                    {
                        success = true,
                        data = result
                    });
                }
                catch (Exception e)
                {
                    return await ResponseException(e);
                }
            }
            else
            {
                _uow.Rollback();
                return BadRequest(new
                {
                    success = false,
                    errors = notifications
                });
            }
        }

        /// <summary>
        /// Resposta a ser utilizada nas Actions de controllers que contém Queries
        /// </summary>
        /// <param name="result">O resultado do processamento da Query</param>
        /// <returns>Retorna a resposta conforme o resultado do processamento</returns>
        protected async Task<IActionResult> QueryResponse(object result)
        {
            if (result != null)
            {
                try
                {
                    _uow.Commit();
                    return Ok(new
                    {
                        success = true,
                        data = result
                    });
                }
                catch (Exception e)
                {
                    return await ResponseException(e);
                }
            }
            else
            {
                _uow.Rollback();
                return Ok(new
                {
                    success = false,
                    errors = new[] { new { message = "Dados não encontrados" } }
                });
            }
        }

        /// <summary>
        /// Resposta para exceções ocorridas no processamento
        /// </summary>
        /// <returns>Retorna código HTTP 500</returns>
        protected async Task<IActionResult> ResponseException(Exception e)
        {
            _uow.Rollback();
            return await Task.FromResult<IActionResult>(StatusCode(500, new
            {
                success = false,
                errors = new[] { new { message = "Ocorreu uma falha interna no servidor" + e.Message } }
            }));
        }

    }
}
