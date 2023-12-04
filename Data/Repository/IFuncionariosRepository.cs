using Domain.Model;

namespace Data.Repository
{
    public interface IFuncionariosRepository : IRepository<Funcionario>
    {
        IQueryable<Funcionario> GetFuncionariosCargoById(int id);
        IQueryable<Funcionario> GetFuncionariosCargo();
    }
}
