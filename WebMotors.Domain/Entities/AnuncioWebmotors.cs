using Flunt.Validations;
using WebMotors.Shared.Entities;

namespace WebMotors.Domain.Entities
{
    public class AnuncioWebmotors : Entity
    {
        public AnuncioWebmotors(string marca,
                             string modelo,
                             string versao,
                             int ano,
                             int quilometragem,
                             string observacao)
        {
            Marca = marca;
            Modelo = modelo;
            Versao = versao;
            Ano = ano;
            Quilometragem = quilometragem;
            Observacao = observacao;
            Validate();
        }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }

        public void Update(string marca,
                        string modelo,
                        string versao,
                        int ano,
                        int quilometragem,
                        string observacao)
        {
            Marca = marca;
            Modelo = modelo;
            Versao = versao;
            Ano = ano;
            Quilometragem = quilometragem;
            Observacao = observacao;
            Validate();
        }

        protected override void Validate()
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
