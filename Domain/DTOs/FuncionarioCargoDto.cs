namespace Domain.DTOs
{
    public class FuncionarioCargoDto
    {
        public int Id { get; set; }
        public decimal Salario { get; set; }
        public int CargoId { get; set; }
        public int FuncionarioId { get; set; }
        public bool Ativo { get; set; }
    }
}
