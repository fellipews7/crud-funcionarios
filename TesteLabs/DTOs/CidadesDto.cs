namespace TesteLabs.DTOs
{
    public class CidadesDto
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public EstadosDto? Estado { get; set; }
        public int EstadoId { get; set; }
        public ICollection<FuncionariosEnderecosDto>? FuncionariosEnderecos { get; set; }

    }
}
