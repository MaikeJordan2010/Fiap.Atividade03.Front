using Atividade03.Front.Dominio.ViewHelpers;

namespace Atividade03.Front.Services._Municipios
{
    public interface IObterMunicipios
    {
        public Task<Municipios?> Get(string ddd);
    }
}
