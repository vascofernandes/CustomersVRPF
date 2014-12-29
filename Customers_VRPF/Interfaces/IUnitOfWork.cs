namespace Customers_VRPF.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();

        ICustomerRepository Customers { get; }
    }
}