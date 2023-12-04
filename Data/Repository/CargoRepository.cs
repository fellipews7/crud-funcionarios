using Data.Data;
using Domain.Model;

namespace Data.Repository
{
    public class CargoRepository : Repository<Cargo>, ICargoRepository
    {
        public CargoRepository(TesteLabsContext context) : base(context)
        {
        }
    }
}
