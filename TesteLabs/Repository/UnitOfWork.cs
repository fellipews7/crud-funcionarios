using TesteLabs.Data;
using Microsoft.EntityFrameworkCore;

namespace TesteLabs.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public TesteLabsContext _context;
        public PaisesRepository _paisesRepository;
        public EstadosRepository _estadosRepository;
        public CidadesRepository _cidadesRepository;
        public FuncionariosEnderecosRepository _funcionariosEnderecosRepository;
        public FuncionariosRepository _funcionariosRepository;

        public UnitOfWork(TesteLabsContext context)
        {
            _context = context;
        }

        public IPaisesRepository PaisesRepository
        {
            get 
            { 
                return _paisesRepository = _paisesRepository ?? new PaisesRepository(_context); 
            }
        }

        public IEstadosRepository EstadosRepository
        {
            get 
            { 
                return _estadosRepository = _estadosRepository ?? new EstadosRepository(_context); 
            }
        }

        public ICidadesRepository CidadesRepository
        {
            get 
            { 
                return _cidadesRepository = _cidadesRepository ?? new CidadesRepository(_context); 
            }
        }

        public IFuncionariosEnderecosRepository FuncionariosEnderecosRepository
        {
            get
            {
                return _funcionariosEnderecosRepository = _funcionariosEnderecosRepository ?? new FuncionariosEnderecosRepository(_context);
            }
        }
        public IFuncionariosRepository FuncionariosRepository
        {
            get
            {
                return _funcionariosRepository = _funcionariosRepository ?? new FuncionariosRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
