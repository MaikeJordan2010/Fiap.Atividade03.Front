using Atividade03.Front.Dominio.Sistemicas;
using Atividade03.Front.Dominio.ViewHelpers;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace Atividade03.Front.Services._Contatos
{
    public class ContatoServices : IContatoServices
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly string _url = "http://host.docker.internal:5075";
        public ContatoServices(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResultadoGenericoComandos> Atualizar(Contato contato)
        {
            try
            {
                var client = _httpClient.CreateClient();

                using StringContent jsonContent = new(JsonConvert.SerializeObject(contato), Encoding.UTF8, "application/json");

                var result = await client.PutAsync($"{_url}/api/Contato/Atualizar", jsonContent);

                if (result.IsSuccessStatusCode)
                {
                    var resultado = await result.Content.ReadAsStringAsync();

                    return await Task.FromResult(JsonConvert.DeserializeObject<ResultadoGenericoComandos>(resultado)!);
                }

                return await Task.FromResult(new ResultadoGenericoComandos(false, "Erro ao tentar Atualizar dados!"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResultadoGenericoComandos> Excluir(string guid)
        {
            try
            {
                var client = _httpClient.CreateClient();


                var result = await client.DeleteAsync($"{_url}/api/Contato/Excluir/{guid}");

                if (result.IsSuccessStatusCode)
                {
                    var resultado = await result.Content.ReadAsStringAsync();

                    if(resultado != null)
                    {
                        return await Task.FromResult(JsonConvert.DeserializeObject<ResultadoGenericoComandos>(resultado)!);
                    }
                }

                return await Task.FromResult(new ResultadoGenericoComandos(false, "Erro ao tentar Excluir dados!"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResultadoGenericoComandos> Inserir(Contato contato)
        {
            try
            {
                var client = _httpClient.CreateClient();

                using StringContent jsonContent = new(JsonConvert.SerializeObject(contato), Encoding.UTF8, "application/json");

                var result = await client.PostAsync($"{_url}/api/Contato/Criar", jsonContent);

                if (result.IsSuccessStatusCode)
                {
                    var resultado = await result.Content.ReadAsStringAsync();

                    return await Task.FromResult(JsonConvert.DeserializeObject<ResultadoGenericoComandos>(resultado)!);
                }

                return await Task.FromResult(new ResultadoGenericoComandos(false, "Erro ao tentar Inserir dados!"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Contato>> ObterLista()
        {
            try
            {
                var client = _httpClient.CreateClient();

                var result = await client.GetAsync($"{Configuracoes.UrlAPI}/api/Contato/ObterLista");

                if (result.IsSuccessStatusCode)
                {

                    var resultado = await result.Content.ReadAsStringAsync();

                    return await Task.FromResult(JsonConvert.DeserializeObject<IEnumerable<Contato>>(resultado)!);
                }

                return Enumerable.Empty<Contato>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Contato>> ObterListaPorDDD(string ddd)
        {
            try
            {
                var client = _httpClient.CreateClient();

                var result = await client.GetAsync($"{_url}/api/Contato/ObterListaPorDDD/{ddd}");

                if (result.IsSuccessStatusCode)
                {

                    var resultado = await result.Content.ReadAsStringAsync();

                    return await Task.FromResult(JsonConvert.DeserializeObject<IEnumerable<Contato>>(resultado)!);
                }

                return Enumerable.Empty<Contato>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Contato?> ObterContato(string guid)
        {
            try
            {
                var client = _httpClient.CreateClient();

                var result = await client.GetAsync($"{_url}/api/Contato/ObterContato/{guid}");

                if (result.IsSuccessStatusCode)
                {

                    var resultado = await result.Content.ReadAsStringAsync();

                    return await Task.FromResult(JsonConvert.DeserializeObject<Contato>(resultado));
                }

                return default;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
