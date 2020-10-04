using Flunt.Notifications;
using Flunt.Validations;
using WebMotors.Shared.Commands;

namespace WebMotors.Domain.Commands
{
    public class UpdateAnuncioWebMotorsCommand : Notifiable, ICommand
    {
        public long Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }

        public void Validate()
        {
        }
    }
}
