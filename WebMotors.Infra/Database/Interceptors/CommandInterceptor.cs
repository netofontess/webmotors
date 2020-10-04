using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Diagnostics;

namespace WebMotors.Infra.Database.Interceptors
{
    public class CommandInterceptor : DbCommandInterceptor
    {

        public override InterceptionResult DataReaderDisposing(DbCommand command, DataReaderDisposingEventData eventData, InterceptionResult result)
        {
            Debug.WriteLine(command.CommandText);
            return base.DataReaderDisposing(command, eventData, result);
        }

        public override int NonQueryExecuted(DbCommand command, CommandExecutedEventData eventData, int result)
        {
            Debug.WriteLine(command.CommandText);
            return base.NonQueryExecuted(command, eventData, result);
        }

        public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
        {
            Debug.WriteLine(command.CommandText);
            return base.ReaderExecuted(command, eventData, result);
        }

        public override object ScalarExecuted(DbCommand command, CommandExecutedEventData eventData, object result)
        {
            Debug.WriteLine(command.CommandText);
            return base.ScalarExecuted(command, eventData, result);
        }
    }
}
