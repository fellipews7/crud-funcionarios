using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TesteLabs.Domain
{
    public class Estados
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Nome { get; set; }
        [Required]
        [StringLength(2)]
        public string Sigla { get; set; }
        [Required]
        public int PaisId { get; set; }
        public Paises? Pais { get; set; }
        public ICollection<Cidades>? Cidades { get; set; }

    }
}
