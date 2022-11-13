using TesteLabs.Domain;

namespace TesteLabs.Repository
{
    public interface IFuncionariosRepository : IRepository<Funcionarios>
    {
        IQueryable<Funcionarios> GetFuncionariosEnderecos();
        IQueryable<Funcionarios> GetFuncionarioEnderecosById(int id);
    }
}
