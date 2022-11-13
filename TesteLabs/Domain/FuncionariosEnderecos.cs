using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TesteLabs.Domain
{
    public class FuncionariosEnderecos
    {
        [Key]
        public int Id { get; set; }
        [JsonIgnore]
        public Cidades? Cidade { get; set; }
        [Required]
        public int CidadeId { get; set; }
        [Required]
        public string Logradouro { get; set; }

        public int? Numero { get; set; }
        [Required]
        [StringLength(45)]
        public string Bairro { get; set; }
        [StringLength(100)]
        public string? Complemento { get; set; }
        [Required]
        public bool EnderecoPrincipal { get; set; }
        [Required] 
        public int FuncionarioId { get; set; }
        public Funcionarios? Funcionario { get; set; }

    }
}
