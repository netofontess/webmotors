using System;

namespace WebMotors.Shared.Transactions
{
    public interface IUow : IDisposable
    {
        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}
