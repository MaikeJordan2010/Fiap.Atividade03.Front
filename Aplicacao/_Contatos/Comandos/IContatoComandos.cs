using Atividade03.Front.Dominio.Sistemicas;
using Atividade03.Front.Dominio.ViewHelpers;

namespace Atividade03.Front.Aplicacao._Contato.Comandos
{
    public interface IContatoComandos
    {
        public Task<ResultadoGenericoComandos> Criar(Contato contato);
        public Task<ResultadoGenericoComandos> Atualizar(Contato contato);
        public Task<ResultadoGenericoComandos> Excluir(string guid);

    }
}
