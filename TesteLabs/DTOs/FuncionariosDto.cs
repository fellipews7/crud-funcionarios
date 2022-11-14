using TesteLabs.Domain.Enums;

namespace TesteLabs.DTOs
{
    public class FuncionariosDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string DocFederal { get; set; }
        public IdentificadorPessoa TipoPessoa { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public byte[]? Imagem { get; set; }
        public ICollection<FuncionariosEnderecosDto>? Enderecos { get; set; }

    }
}
