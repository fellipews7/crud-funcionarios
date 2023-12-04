using Data.Data;
using Domain.Model;

namespace Data.Repository
{
    public class FuncionarioCargoRepository : Repository<FuncionarioCargo>, IFuncionarioCargoRepository
    {
        public FuncionarioCargoRepository(TesteLabsContext context) : base(context)
        {
        }
    }
}
