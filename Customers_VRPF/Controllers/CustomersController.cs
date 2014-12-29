using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using Customers_VRPF.Interfaces;
using Customers_VRPF.Datastores;
using Customers_VRPF.DataTransferObjects;
using Customers_VRPF.Models;

namespace Customers_VRPF.Controllers
{
    public class CustomersController : ApiController
    {
        private IUnitOfWork _unit;

        public CustomersController()
        {
            _unit = new DataStore();
        }

        public IHttpActionResult Get()
        {
            IQueryable<Customer> customers = _unit.Customers.All;

            var response = from b in customers
                        select new CustomerDto()
                        {
                            Id = b.Id,
                            Name = b.Name,
                            Address = b.Address,
                            City = b.City,
                            Country = b.Country
                        };

            return Ok(response);
        }

        public IHttpActionResult Get(int id)
        {
            var customer = _unit.Customers.GetOne(id);

            if (customer == null)
            {
                return NotFound();
            }

            var response = new CustomerDto()
                           {
                               Id = customer.Id,
                               Name = customer.Name,
                               Address = customer.Address,
                               City = customer.City,
                               Country = customer.Country
                           };

            return Ok(response);
        }

        public IHttpActionResult Post([FromBody]Customer customer)
        {
            try
            {
                var newCustomer = _unit.Customers.Add(customer);
                // _unit.Commit(); // We dont have a DB yet

                var url = Url.Link("DefaultApi", new { controller = "Customers", id = newCustomer.Id });

                return Created(url, newCustomer);
            }
            catch (Exception e)
            {
                Console.WriteLine("We need to hadle this!", e);
                return InternalServerError();
            }
        }

        //update customer
        public IHttpActionResult Put(int id, [FromBody]Customer updatedCustomer)
        {
            try
            {
                var customer = _unit.Customers.Update(id, updatedCustomer);
                // _unit.Commit(); // We dont have a DB yet
            }
            catch (Exception e)
            {
                Console.WriteLine("We need to hadle this!", e);
                return InternalServerError();
            }
            
            return Ok("Ok");
        }

        public IHttpActionResult Delete(int id)
        {
            _unit.Customers.Remove(id);
            // _unit.Commit(); // We dont have a DB yet

            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
