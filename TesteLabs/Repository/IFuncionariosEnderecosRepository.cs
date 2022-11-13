using TesteLabs.Domain;

namespace TesteLabs.Repository
{
    public interface IFuncionariosEnderecosRepository : IRepository<FuncionariosEnderecos>
    {
        Task<IEnumerable<FuncionariosEnderecos>> GetEnderecosCompleto();
        Task<IEnumerable<FuncionariosEnderecos>> GetEnderecoCompletoById(int id);

    }
}
