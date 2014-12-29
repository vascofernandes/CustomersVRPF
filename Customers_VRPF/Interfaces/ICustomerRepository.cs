using System.Linq;
using Customers_VRPF.Models;

namespace Customers_VRPF.Interfaces
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> All { get; }

        Customer GetOne(int id);

        Customer Add(Customer customer);

        Customer Remove(int id);
        
        Customer Update(int id, Customer customer);
    }
}