CustomersVRPF
=============

The project consists of two main parts:
- backend based on ASP.NET WebAPI
- frontend based on AngularJS in the form of a Single Page Application.

The WebAPI is defined in Controllers/CustomersController.cs
A general description of the API is as follows:


GET    api/customers      - Get all customers
GET    api/customers/{id} - Get one customer by ID
POST   api/customers      - Insert a new customer
PUT    api/customers/{id} - Update a customer
DELETE api/customers/{id} - delete a customer.

A customer is defined in Models/Customers.cs.
The operation are handled by the class Datastores/Datastore.cs which implements Interfaces/IUnitOfWork.cs.
In Datastore.cs the methods Customers returns an instance of Repositories/CustomerRepository.cs which implements Interfaces/ICustomerRepository.cs.
CustomerRepository.cs handles all the data related tasks, such as insertion, update, and deletion of customers.
In this case, the implementation is simple a non-persistent List with some sample data.
This can be easily replaced with database functionality.
With this structure one can easily extend to API to handle for example products or invoices for each customer.

When relevant I used some basic data mapping from domain objects, such as Customer.cs, to data transfer objects, to send over the network.
For a more robust solution one could make use of libraries such as Json.NET (http://james.newtonking.com/json)
and Automapper (http://automapper.org/), both available on NuGet.


On the front end the applications uses angularjs ui-router to handle the three views of the applications:
Customer List/Add New, Detailed Customer, and Edit Customer.

The frontend communicates with the backend using and service based on AngularJS Resources defined in app/services/customerResource.js.
There controllers, one for each view, are defined in app/customers and make use of the customerResoure to communicate with the API.
The front end is organized on a feature basis.
If one would need to implement product management, a folder app/products would contain controllers and views related with product management.

The applications communicates correctly with the backend, but since there is no persistence,
the customers information does not change between requests.
