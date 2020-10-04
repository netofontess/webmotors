using Flunt.Notifications;
using Flunt.Validations;
using WebMotors.Shared.Commands;

namespace WebMotors.Domain.Commands
{
    public class DeleteAnuncioWebMotorsCommand : Notifiable, ICommand
    {
        public long Id { get; set; }

        public void Validate()
        {
        }
    }
}
