using Microsoft.EntityFrameworkCore;
using TesteLabs.Data;
using TesteLabs.Domain;

namespace TesteLabs.Repository
{
    public class CidadesRepository : Repository<Cidades>, ICidadesRepository
    {
        public CidadesRepository(TesteLabsContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Cidades>> GetCidadesEnderecos()
        {
            return await GetAll().Include(x => x.FuncionariosEnderecos).ToListAsync();
        }

        public async Task<IEnumerable<Cidades>> GetEstadosCidadesById(int id)
        {
            return await GetAll().Include(x => x.FuncionariosEnderecos)
                                 .Where(e => e.Id == id)
                                 .ToListAsync();
        }
    }
}
