using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TesteLabs.Domain
{
    public class Cidades
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(45)]
        public string Nome { get; set; }
        [JsonIgnore]
        public Estados? Estado { get; set; }
        [Required]
        public int EstadoId { get; set; }
        public ICollection<FuncionariosEnderecos>? FuncionariosEnderecos { get; set; }

    }
}
