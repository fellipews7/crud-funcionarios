using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TesteLabs.DTOs
{
    public class PaisesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EstadosDto>? Estados { get; set; }

    }
}
