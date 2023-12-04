using Domain.Enums;
using Domain.Model;

namespace Domain.DTOs
{
    public class FuncionarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string DocFederal { get; set; }
        public IdentificadorPessoa TipoPessoa { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

    }
}
