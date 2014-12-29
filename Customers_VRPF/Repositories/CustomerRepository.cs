using System.Collections.Generic;
using System.Linq;
using Customers_VRPF.Interfaces;
using Customers_VRPF.Models;

namespace Customers_VRPF.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> _customers;

        public CustomerRepository()
        {
            _customers = new List<Customer>{
                new Customer { Id = 1, Name = "Mette", Address = "Reidulvs gate 1", City = "Trondheim", Country = "Norge" },
                new Customer { Id = 2, Name = "Vasco", Address = "Reidulvs gate 2", City = "Trondheim", Country = "Norge" },
                new Customer { Id = 3, Name = "Anne",  Address = "Reidulvs gate 3", City = "Trondheim", Country = "Norge" },
                new Customer { Id = 4, Name = "Hilde", Address = "Reidulvs gate 4", City = "Trondheim", Country = "Norge" },
                new Customer { Id = 5, Name = "Zé",    Address = "Reidulvs gate 5", City = "Trondheim", Country = "Norge" },
            };
        }

        public IQueryable<Customer> All
        {
            get { return _customers.AsQueryable(); }
        }

        public Customer GetOne(int id)
        {
            return _customers.SingleOrDefault(c => c.Id == id);
        }

        public Customer Add(Customer customer)
        {
            var currentCount = _customers.Count;

            customer.Id = currentCount + 1;

            _customers.Add(customer);
            return _customers[_customers.Count-1];
        }

        public Customer Remove(int id)
        {
            var customer = _customers.SingleOrDefault(r => r.Id == id);
            if (customer != null)
            {
                _customers.Remove(customer);
                return customer;
            }
            return null;
        }

        public Customer Update(int id, Customer updatedCustomer)
        {
            int index = _customers.FindIndex(r => r.Id == id);

            if (index != -1)
            {
                _customers[index] = updatedCustomer;
                return _customers[index];
            }

            return null;
        }
    }
}




       
       
