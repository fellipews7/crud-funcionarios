namespace TesteLabs.Repository
{
    public interface IUnitOfWork
    {
        IPaisesRepository PaisesRepository { get; }
        IEstadosRepository EstadosRepository { get; }
        ICidadesRepository CidadesRepository { get; }
        IFuncionariosEnderecosRepository FuncionariosEnderecosRepository { get; }
        IFuncionariosRepository FuncionariosRepository { get; }
        Task Commit();
    }
}
