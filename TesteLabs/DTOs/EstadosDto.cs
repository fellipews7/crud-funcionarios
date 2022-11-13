using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TesteLabs.DTOs
{
    public class EstadosDto
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public PaisesDto? Pais { get; set; }
        public ICollection<CidadesDto>? Cidades { get; set; }

    }
}
