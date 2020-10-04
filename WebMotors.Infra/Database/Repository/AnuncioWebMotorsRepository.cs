using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebMotors.Domain.Entities;
using WebMotors.Domain.Interfaces.Repository;

namespace WebMotors.Infra.Database.Repository
{
    public class AnuncioWebMotorsRepository : IAnuncioWebMotorsRepository
    {
        private readonly WebMotorsContext _writerContext;

        public AnuncioWebMotorsRepository(WebMotorsContext writerContext)
        {
            _writerContext = writerContext;
        }

        public void Create(AnuncioWebmotors item)
        {
            _writerContext.AnuncioWebmotors.Add(item);
        }

        public void Delete(AnuncioWebmotors item)
        {
            _writerContext.AnuncioWebmotors.Remove(item);
        }

        public void Update(AnuncioWebmotors item)
        {
            _writerContext.AnuncioWebmotors.Update(item);
        }

        public IEnumerable<AnuncioWebmotors> GetAll()
        {
            return _writerContext.AnuncioWebmotors.AsNoTracking().ToList();
        }

        public AnuncioWebmotors GetById(long id)
        {
            return _writerContext.AnuncioWebmotors.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
