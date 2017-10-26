namespace CustomerSystemDAL
{
    public interface IDALFacade
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
