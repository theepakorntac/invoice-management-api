using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers
                .FromSqlRaw("EXEC sp_GetAllCustomers")
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var idParam = new SqlParameter("@CustomerID", id);
            var customers = await _context.Customers
                .FromSqlRaw("EXEC sp_GetCustomerById @CustomerID", idParam)
                .ToListAsync();

            var customer = customers.FirstOrDefault();
            if (customer == null) return NotFound();
            return customer;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            var p1 = new SqlParameter("@FirstName", customer.FirstName);
            var p2 = new SqlParameter("@LastName", customer.LastName);
            var p3 = new SqlParameter("@Email", customer.Email);
            var p4 = new SqlParameter("@Phone", (object?)customer.Phone ?? DBNull.Value);
            var p5 = new SqlParameter("@CityID", customer.CityID);

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertCustomer @FirstName, @LastName, @Email, @Phone, @CityID",
                p1, p2, p3, p4, p5);

            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerID) return BadRequest();

            var p0 = new SqlParameter("@CustomerID", id);
            var p1 = new SqlParameter("@FirstName", customer.FirstName);
            var p2 = new SqlParameter("@LastName", customer.LastName);
            var p3 = new SqlParameter("@Email", customer.Email);
            var p4 = new SqlParameter("@Phone", (object?)customer.Phone ?? DBNull.Value);
            var p5 = new SqlParameter("@CityID", customer.CityID);

            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateCustomer @CustomerID, @FirstName, @LastName, @Email, @Phone, @CityID",
                p0, p1, p2, p3, p4, p5);

            if (rowsAffected == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var idParam = new SqlParameter("@CustomerID", id);
            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_DeleteCustomer @CustomerID", idParam);

            if (rowsAffected == 0) return NotFound();
            return NoContent();
        }
    }
}