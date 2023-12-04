using Domain.Enums;

namespace Domain.DTOs
{
    public class CargosDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public NivelCargo NivelCargo { get; set; }
    }
}
