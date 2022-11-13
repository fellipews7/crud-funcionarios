using TesteLabs.Domain;

namespace TesteLabs.Repository
{
    public interface IPaisesRepository : IRepository<Paises>
    {
        Task<IEnumerable<Paises>> GetPaisesEstados();
        IQueryable<Paises> GetPaisEstadosById(int id);
    }
}
