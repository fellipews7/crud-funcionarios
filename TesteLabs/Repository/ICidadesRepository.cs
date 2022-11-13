using TesteLabs.Domain;

namespace TesteLabs.Repository
{
    public interface ICidadesRepository : IRepository<Cidades>
    {
        Task<IEnumerable<Cidades>> GetCidadesEnderecos();
        Task<IEnumerable<Cidades>> GetEstadosCidadesById(int id);
    }
}
