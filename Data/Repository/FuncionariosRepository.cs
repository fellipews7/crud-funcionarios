using Data.Data;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class FuncionariosRepository : Repository<Funcionario>, IFuncionariosRepository
    {
        public FuncionariosRepository(TesteLabsContext context) : base(context)
        {
        }

        public IQueryable<Funcionario> GetFuncionariosCargoById(int id)
        {
            return GetAll().Include(x => x.Cargos).Where(x => x.Id == id);
        }

        public IQueryable<Funcionario> GetFuncionariosCargo()
        {
            return GetAll().Include(x => x.Cargos);
        }


    }
}
