using Microsoft.EntityFrameworkCore;
using TesteLabs.Data;
using TesteLabs.Domain;

namespace TesteLabs.Repository
{
    public class FuncionariosRepository : Repository<Funcionarios>, IFuncionariosRepository
    {
        public FuncionariosRepository(TesteLabsContext context) : base(context)
        {
        }

        public IQueryable<Funcionarios> GetFuncionariosEnderecos()
        {
            return GetAll().Include(x => x.Enderecos);
        }

        public IQueryable<Funcionarios> GetFuncionarioEnderecosById(int id)
        {
            return GetAll().Where(f => f.Id == id)
                           .Include(f => f.Enderecos);
        }

    }
}
