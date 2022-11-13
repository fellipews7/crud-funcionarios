using Microsoft.EntityFrameworkCore;
using TesteLabs.Data;
using TesteLabs.Domain;

namespace TesteLabs.Repository
{
    public class EstadosRepository : Repository<Estados>, IEstadosRepository
    {
        public EstadosRepository(TesteLabsContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Estados>> GetEstadosCidades()
        {
            return await GetAll().Include(x => x.Cidades).ToListAsync();
        }

        public IQueryable<Estados> GetEstadosCidadesById(int id)
        {
            return GetAll().Include(x => x.Cidades).Where(e => e.Id == id);
        }
    }
}
