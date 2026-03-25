using invoice_management_api.Interfaces;
using invoice_management_api.Models;
using InvoiceManagementDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace invoice_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers() =>
            Ok(await _customerService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            return customer == null ? NotFound() : Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> PostCustomer(Customer customer)
        {
            await _customerService.CreateAsync(customer);
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerID) return BadRequest();
            var rowsAffected = await _customerService.UpdateAsync(id, customer);
            return rowsAffected == 0 ? NotFound() : NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var rowsAffected = await _customerService.DeleteAsync(id);
            return rowsAffected == 0 ? NotFound() : NoContent();
        }
    }
}