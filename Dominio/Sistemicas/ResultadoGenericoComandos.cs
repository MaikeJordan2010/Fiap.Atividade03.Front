namespace Atividade03.Front.Dominio.Sistemicas
{
    public class ResultadoGenericoComandos
    {
        public bool Sucesso { get; set; }
        public string? Mensagem { get; set; }
        public object? Dados { get; set; }

        public ResultadoGenericoComandos()
        {
            
        }
        public ResultadoGenericoComandos(bool sucesso, string mensagem, object? dados = null)
        {
            this.Sucesso = sucesso;
            this.Mensagem = mensagem;
            this.Dados = dados;
        }
    }
}
