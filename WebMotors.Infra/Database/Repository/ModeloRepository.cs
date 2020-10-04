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
    public class ModeloRepository : IModeloRepository
    {
        public async Task<List<ListarModeloQueryResult>> GetAll(Filtro filtro)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri($"http://desafioonline.webmotors.com.br/api/");

            var modelo = new List<ListarModeloQueryResult>();

            var response = await client.GetAsync($"OnlineChallenge/Model?MakeID={filtro.Id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();

                modelo = JsonConvert.DeserializeObject<List<ListarModeloQueryResult>>(jsonResponse);
            }

            return modelo;
        }
    }
}
