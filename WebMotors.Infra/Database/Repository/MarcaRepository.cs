using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebMotors.Domain.Entities;
using WebMotors.Domain.Interfaces.Repository;

namespace WebMotors.Infra.Database.Repository
{
    public class MarcaRepository : IMarcaRepository
    {
        public async Task<List<ListarMarcaQueryResult>> GetAll()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri($"http://desafioonline.webmotors.com.br/api/");

            var marca = new List<ListarMarcaQueryResult>();

            var response = await client.GetAsync($"OnlineChallenge/Make");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();

                marca = JsonConvert.DeserializeObject<List<ListarMarcaQueryResult>>(jsonResponse);
            }

            return marca;
        }
    }
}
