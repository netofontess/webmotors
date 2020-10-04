using Flunt.Notifications;
using WebMotors.Domain.Commands;
using WebMotors.Domain.Commands.Result;
using WebMotors.Domain.Entities;
using WebMotors.Domain.Interfaces.Repository;
using WebMotors.Shared.Commands;

namespace WebMotors.Domain.Handlers
{
    public class AnuncioWebMotorsCommandHandler : Notifiable
    {
        private readonly IAnuncioWebMotorsRepository _repository;
        public AnuncioWebMotorsCommandHandler(IAnuncioWebMotorsRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateAnuncioWebMotorsCommand command)
        {
            //Valida command (fast validation)
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return null;
            }

            //Cria anúncio
            AnuncioWebmotors anuncio = new AnuncioWebmotors(command.Marca, command.Modelo, command.Versao, command.Ano, command.Quilometragem, command.Observacao);

            //Valida campos
            if (anuncio.Invalid)
            {
                AddNotifications(anuncio);
                return null;
            }

            _repository.Create(anuncio);

            return new CommandResult(anuncio, "Anúncio criado com sucesso");
        }

        public ICommandResult Handle(UpdateAnuncioWebMotorsCommand command)
        {
            //Valida command (fast validation)
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return null;
            }

            var anuncio = _repository.GetById(command.Id);

            if (anuncio == null)
                return null;

            //Atualiza anúncio
            anuncio.Update(command.Marca, command.Modelo, command.Versao, command.Ano, command.Quilometragem, command.Observacao);

            //Valida campos
            if (anuncio.Invalid)
            {
                AddNotifications(anuncio);
                return null;
            }

            _repository.Update(anuncio);

            return new CommandResult(anuncio, "Anúncio atualizado com sucesso");
        }

        public ICommandResult Handle(DeleteAnuncioWebMotorsCommand command)
        {
            var anuncio = _repository.GetById(command.Id);

            if (anuncio == null)
                return null;

            _repository.Delete(anuncio);

            return new CommandResult(anuncio, "Anúncio removido com sucesso");
        }
    }
}