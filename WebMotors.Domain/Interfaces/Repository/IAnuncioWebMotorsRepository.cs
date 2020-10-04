using WebMotors.Domain.Entities;
using WebMotors.Domain.Filtros;

namespace WebMotors.Domain.Interfaces.Repository
{
    public interface IAnuncioWebMotorsRepository : ICrudRepository<AnuncioWebmotors>
    {
        AnuncioWebmotors GetAll(Filtro filtro);
    }
}