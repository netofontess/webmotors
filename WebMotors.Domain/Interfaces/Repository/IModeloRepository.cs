using System.Collections.Generic;
using System.Threading.Tasks;
using WebMotors.Domain.Entities;
using WebMotors.Domain.Filtros;

namespace WebMotors.Domain.Interfaces.Repository
{
    public interface IModeloRepository
    {
        Task<List<ListarModeloQueryResult>> GetAll(Filtro filtro);
    }
}