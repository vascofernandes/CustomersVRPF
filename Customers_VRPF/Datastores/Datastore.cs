using Customers_VRPF.Interfaces;
using Customers_VRPF.Repositories;

namespace Customers_VRPF.Datastores
{
    public class DataStore : IUnitOfWork
    {
        private ICustomerRepository _customers;

        public void Commit()
        {

        }

        public ICustomerRepository Customers
        {
            get
            {
                if (_customers == null) {
                    _customers = new CustomerRepository();
                }

                return _customers;
            }
        }
    }
}