using Atividade03.Front.Dominio.ViewHelpers;
using Atividade03.Front.Services._Contatos;

namespace Atividade03.Front.Aplicacao._Contato.Consultas
{
    public class ContatoConsultas : IContatoConsultas
    {
        private readonly IContatoServices _contatoServices;

        public ContatoConsultas(IContatoServices contatoServices)
        {
            _contatoServices = contatoServices;
        }
        public Task<IEnumerable<Contato>> ObterLista()
        {
            try
            {
                return _contatoServices.ObterLista();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<Contato>> ObterListaPorDDD(string ddd)
        {
            try
            {
                if (!string.IsNullOrEmpty(ddd))
                {
                    return await _contatoServices.ObterListaPorDDD(ddd);
                }

                return await ObterLista();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Contato?> ObterPorId(string guid)
        {
            try
            {
                if (!string.IsNullOrEmpty(guid))
                {
                    return await _contatoServices.ObterContato(guid);
                }

                return default;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
