using Microsoft.EntityFrameworkCore;
using TesteLabs.Data;
using TesteLabs.Domain;

namespace TesteLabs.Repository
{
    public class FuncionariosEnderecosRepository : Repository<FuncionariosEnderecos>, IFuncionariosEnderecosRepository
    {
        public FuncionariosEnderecosRepository(TesteLabsContext context) : base(context)
        {
        }
        public async Task<IEnumerable<FuncionariosEnderecos>> GetEnderecosCompleto()
        {
            return GetAll().Include(x => x.Cidade.Estado);
        }

        public async Task<IEnumerable<FuncionariosEnderecos>> GetEnderecoCompletoById(int id)
        {
            return GetAll().Where(e => e.Id == id).Include(e => e.Cidade);
        }
    }
}
