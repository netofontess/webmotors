using WebMotors.Shared.Transactions;
using WebMotors.Infra;

namespace WebMotors.Infra.Transactions
{
    public class Uow : IUow
    {

        private readonly WebMotorsContext _context;

        public Uow(WebMotorsContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
        }

        public void Rollback()
        {
        }
    }
}
