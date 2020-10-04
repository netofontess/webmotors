using Flunt.Notifications;
using Flunt.Validations;
using WebMotors.Shared.Commands;

namespace WebMotors.Domain.Commands
{
    public class AnuncioWebMotorsCommand : Notifiable, ICommand
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Marca, nameof(Marca), "Marca deve ser preenchida.")
                .IsNotNullOrEmpty(Modelo, nameof(Modelo), "Modelo deve ser preenchido.")
                .IsNotNullOrEmpty(Versao, nameof(Versao), "Versão deve ser preenchida.")
                .IsGreaterThan(Ano, 0, nameof(Ano), "Ano deve ser preenchido.")
                .IsNotNullOrEmpty(Observacao, nameof(Observacao), "Observacao deve ser preenchida.")
            );
        }
    }
}
