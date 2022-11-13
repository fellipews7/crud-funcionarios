using TesteLabs.Domain;

namespace TesteLabs.Repository
{
    public interface IEstadosRepository : IRepository<Estados>
    {
        Task<IEnumerable<Estados>> GetEstadosCidades();
        IQueryable<Estados> GetEstadosCidadesById(int id);
    }
}
