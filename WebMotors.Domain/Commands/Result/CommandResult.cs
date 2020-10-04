using WebMotors.Shared.Entities;
using WebMotors.Shared.Commands;

namespace WebMotors.Domain.Commands.Result
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(long id, string message)
        {
            this.Id = id;
            this.Message = message;
        }

        public CommandResult(Entity entity, string message)
        {
            _entity = entity;
            this.Message = message;
        }

        public CommandResult(long id, string message, object obj)
        {
            this.Id = id;
            this.Message = message;
            this.Object = obj;
        }

        private readonly Entity _entity;
        private long _id;

        public long Id
        {
            get => _id == 0 ? _entity.Id : _id;
            set => _id = value;
        }

        public string Message { get; set; }

        public object Object { get; set; }
    }
}
