using Data.Data;

namespace Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public TesteLabsContext _context;
        public FuncionariosRepository _funcionariosRepository;
        public CargoRepository _cargoRepository;
        public FuncionarioCargoRepository _funcionarioCargoRepository;

        public UnitOfWork(TesteLabsContext context)
        {
            _context = context;
        }

        public IFuncionariosRepository FuncionariosRepository
        {
            get
            {
                return _funcionariosRepository = _funcionariosRepository ?? new FuncionariosRepository(_context);
            }
        }

        public ICargoRepository CargoRepository
        {
            get
            {
                return _cargoRepository = _cargoRepository ?? new CargoRepository(_context);
            }
        }

        public IFuncionarioCargoRepository FuncionarioCargoRepository
        {
            get
            {
                return _funcionarioCargoRepository = _funcionarioCargoRepository ?? new FuncionarioCargoRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
