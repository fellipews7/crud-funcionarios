namespace TesteLabs.DTOs
{
    public class FuncionariosEnderecosDto
    {
        public int Id { get; set; }
        public CidadesDto? Cidade { get; set; }
        public string Logradouro { get; set; }
        public int? Numero { get; set; }
        public string Bairro { get; set; }
        public string? Complemento { get; set; }
        public bool EnderecoPrincipal { get; set; }
        public FuncionariosDto? Funcionario { get; set; }

    }
}
