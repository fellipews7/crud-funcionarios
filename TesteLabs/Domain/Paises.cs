using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TesteLabs.Domain
{
    public class Paises
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(45)]
        public string Name { get; set; }
        public ICollection<Estados>? Estados { get; set; }

    }
}
