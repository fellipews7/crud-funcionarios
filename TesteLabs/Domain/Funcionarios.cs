using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using TesteLabs.Domain.Enums;

namespace TesteLabs.Domain
{
    public class Funcionarios
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(45)]
        public string Nome { get; set; }
        [Required]
        [Range(16, 100)]
        public int Idade { get; set; }
        [Required, StringLength(14)]
        public string DocFederal { get; set; }
        [Required]
        public IdentificadorPessoa TipoPessoa { get; set; }
        [Required, StringLength(30)]
        public string Email { get; set; }
        [Required, StringLength(15)]
        public string Telefone { get; set; }
        public ICollection<FuncionariosEnderecos>? Enderecos { get; set; }

    }
}
