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

            // var response = customers.To<CustomerDto>();

            var response = from b in customers
                        select new CustomerDto()
                        {
                            Id = b.Id,
                            Name = b.Name,
                            Address = b.Address,
                            City = b.City,
                            Country = b.Country
                        };


            /*
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(IQueryable<Customer>));

            ser.WriteObject(stream1, customers);

            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            
            var response = sr.ReadToEnd();
            */
            return Ok(response);
        }

        public IHttpActionResult Get(int id)
        {
            var result = _unit.Customers.GetOne(id);

            if (result == null)
            {
                return NotFound();
            }

            var response = ""; // result.To<CustomerDto>();

            return Ok(response);
        }

        public IHttpActionResult Post([FromBody]Customer customer)
        {
            var newCustomer = _unit.Customers.Add(customer);
            _unit.Commit(); // Would do work if we had a DB

            var url = Url.Link("DefaultApi", new { controller = "Customers", id = newCustomer.Id });

            return Created(url, newCustomer);
        }

        //update customer
        public IHttpActionResult Put(int id, [FromBody]Customer updatedCustomer)
        {

            var customer = _unit.Customers.Update(id, updatedCustomer);
            _unit.Commit(); // Would do work if we had a DB

            return Ok("Ok");
        }

        public IHttpActionResult Delete(int id)
        {
            _unit.Customers.Remove(id);
            _unit.Commit(); // Would do work if we had a DB

            return StatusCode(HttpStatusCode.NoContent);
        }




        /*
        InventoryEntities db = new InventoryEntities();

        //get all customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return db.Customers.AsEnumerable();
        }

        //get customer by id
        public Customer Get(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return customer;
        }

        //insert customer
        public HttpResponseMessage Post(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, customer);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = customer.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        //update customer
        public HttpResponseMessage Put(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if (id != customer.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            db.Entry(customer).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //delete customer by id
        public HttpResponseMessage Delete(int id)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.Customers.Remove(customer);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }

        //prevent memory leak
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        */

    }
}
