using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Cargo
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Nome { get; set; }

        [Required]
        public decimal Salario { get; set; }
        public NivelCargo NivelCargo { get; set; }
        public List<FuncionarioCargo> FuncionarioCargoList { get; set; }
    }
}
