using Atividade03.Front.Dominio.ViewHelpers;
using System.Text.Json;

namespace Atividade03.Front.Services._Municipios
{
    public class ObterMunicipios : IObterMunicipios
    {
        private readonly IHttpClientFactory _httpClient;

        public ObterMunicipios(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Municipios?> Get(string ddd)
        {
            try
            {
                var client = _httpClient.CreateClient();

                var result = await client.GetAsync($"https://brasilapi.com.br/api/ddd/v1/{ddd}");

                if (result.IsSuccessStatusCode)
                {

                    var resultado = await result.Content.ReadAsStringAsync();

                    return await Task.FromResult(JsonSerializer.Deserialize<Municipios>(resultado));
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
