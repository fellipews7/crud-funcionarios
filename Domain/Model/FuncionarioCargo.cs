using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class FuncionarioCargo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Salario { get; set; }
        public int CargoId { get; set; }
        public int FuncionarioId { get; set; }
        public bool Ativo { get; set; }

        public Funcionario Funcionario { get; set; }
        public Cargo Cargo { get; set; }
    }
}
