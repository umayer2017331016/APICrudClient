using ApiCrudClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudClient.Controllers
{
    public class CustomerController : Controller
    {

        private readonly APIGateway apiGateway;

        public CustomerController(APIGateway apiGateway)
        {
            this.apiGateway = apiGateway;
        }

        public IActionResult Index()
        {
            List<Customer> customers;
            //API get will come
            customers = apiGateway.ListCustomers();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            apiGateway.CreateCustomer(customer);
            //do API Create Action and send the control to index action
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Customer customer = new Customer();
            customer = apiGateway.GetCustomer(id);
            //fetch the customer from the api and show the customer details in the details view
            return View(customer);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Customer customer ;
            //fetch the customer from the api and show the customer details in the edit view
            customer = apiGateway.GetCustomer(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            //do API Edit Action and send the control to index action
            apiGateway.UpdateCustomer(customer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Customer customer;
            customer = apiGateway.GetCustomer(id);
            //fetch the customer from the api and show the customer details in the delete view
            return View(customer);
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            apiGateway.DeleteCustomer(customer.Id);
            //do API Delete Action and send the control to index action
            return RedirectToAction("Index");
        }
    }
}
