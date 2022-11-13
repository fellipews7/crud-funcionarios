using Microsoft.EntityFrameworkCore;
using TesteLabs.Data;
using TesteLabs.Domain;

namespace TesteLabs.Repository
{
    public class PaisesRepository : Repository<Paises>, IPaisesRepository
    {
        public PaisesRepository(TesteLabsContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Paises>> GetPaisesEstados()
        {
            return await GetAll().Include(x => x.Estados).ToListAsync();
        }

        public IQueryable<Paises> GetPaisEstadosById(int id)
        {
            return GetAll().Include(x => x.Estados)
                           .Where(e => e.Id == id);
        }
    }
}
