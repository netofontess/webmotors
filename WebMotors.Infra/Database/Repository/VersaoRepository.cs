using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebMotors.Domain.Entities;
using WebMotors.Domain.Filtros;
using WebMotors.Domain.Interfaces.Repository;

namespace WebMotors.Infra.Database.Repository
{
    public class VersaoRepository : IVersaoRepository
    {
        public async Task<List<ListarVersaoQueryResult>> GetAll(Filtro filtro)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri($"http://desafioonline.webmotors.com.br/api/");

            var versao = new List<ListarVersaoQueryResult>();

            var response = await client.GetAsync($"OnlineChallenge/Version?ModelID={filtro.Id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();

                versao = JsonConvert.DeserializeObject<List<ListarVersaoQueryResult>>(jsonResponse);
            }

            return versao;
        }
    }
}
