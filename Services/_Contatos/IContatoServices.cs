using Atividade03.Front.Dominio.Sistemicas;
using Atividade03.Front.Dominio.ViewHelpers;

namespace Atividade03.Front.Services._Contatos
{
    public interface IContatoServices
    {
        public Task<IEnumerable<Contato>> ObterLista();
        public Task<IEnumerable<Contato>> ObterListaPorDDD(string ddd);
        public Task<Contato?> ObterContato(string guid);
        public Task<ResultadoGenericoComandos> Inserir(Contato contato);
        public Task<ResultadoGenericoComandos> Atualizar(Contato contato);
        public Task<ResultadoGenericoComandos> Excluir(string guid);
    }
}
