using Atividade03.Front.Dominio.ViewHelpers;

namespace Atividade03.Front.Aplicacao._Contato.Consultas
{
    public interface IContatoConsultas
    {
        public Task<IEnumerable<Contato>> ObterLista();
        public Task<Contato?> ObterPorId(string guid);
        public Task<IEnumerable<Contato>> ObterListaPorDDD(string ddd);
    }
}
