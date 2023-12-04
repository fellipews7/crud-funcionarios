namespace Data.Repository
{
    public interface IUnitOfWork
    {
        ICargoRepository CargoRepository { get; }
        IFuncionariosRepository FuncionariosRepository { get; }
        IFuncionarioCargoRepository FuncionarioCargoRepository { get; }
        Task Commit();
    }
}
