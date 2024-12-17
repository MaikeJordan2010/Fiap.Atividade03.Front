using System.Text.Json.Serialization;

namespace Atividade03.Front.Dominio.ViewHelpers
{
    public class Municipios
    {
        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("cities")]
        public string[]? Cities { get; set; } = [];
    }
}
