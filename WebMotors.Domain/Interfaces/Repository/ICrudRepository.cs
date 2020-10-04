using System.Collections.Generic;

namespace WebMotors.Domain.Interfaces.Repository
{
    public interface ICrudRepository<T>
    {
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        IEnumerable<T> GetAll();
        T GetById(long id);
    }
}
