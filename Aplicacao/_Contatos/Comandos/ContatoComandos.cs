using Atividade03.Front.Dominio.Sistemicas;
using Atividade03.Front.Dominio.Validadores;
using Atividade03.Front.Dominio.ViewHelpers;
using Atividade03.Front.Services._Contatos;

namespace Atividade03.Front.Aplicacao._Contato.Comandos
{
    public class ContatoComandos : IContatoComandos
    {
        private IContatoServices _contatoServices;
        public ContatoComandos(IContatoServices contatoServices)
        {
            _contatoServices = contatoServices;
        }

        public async Task<ResultadoGenericoComandos> Criar(Contato contato)
        {
            try
            {

                ValidarCadastrarContato validarCadastrarContato = new();
                var validador = validarCadastrarContato.Validate(contato);

                if (validador.IsValid)
                {
                    return await _contatoServices.Inserir(contato);
                }

                return await Task.FromResult(new ResultadoGenericoComandos(false, "Erro ao criar contato!", validador.Errors));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<ResultadoGenericoComandos> Atualizar(Contato contato)
        {
            try
            {

                ValidarAtualizarContato validarAtualizarContato = new();
                var validador = validarAtualizarContato.Validate(contato);

                if (validador.IsValid)
                {
                    return await _contatoServices.Atualizar(contato);
                }

                return await Task.FromResult(new ResultadoGenericoComandos(false, "Erro ao atualizar contato!", validador.Errors));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        public async Task<ResultadoGenericoComandos> Excluir(string guid)
        {
            try
            {
                if (!string.IsNullOrEmpty(guid))
                {
                    return await _contatoServices.Excluir(guid);
                }

                return await Task.FromResult(new ResultadoGenericoComandos(false, "Erro ao excluir contato!"));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

    }
}
