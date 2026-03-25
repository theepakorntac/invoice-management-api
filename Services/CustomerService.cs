using invoice_management_api.Interfaces;
using invoice_management_api.Models;
using InvoiceManagementDB;
using InvoiceManagementDB.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace invoice_management_api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.FromSqlRaw("EXEC sp_GetAllCustomers").ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            var idParam = new SqlParameter("@CustomerID", id);
            var result = await _context.Customers
                .FromSqlRaw("EXEC sp_GetCustomerById @CustomerID", idParam)
                .ToListAsync();
            return result.FirstOrDefault();
        }

        public async Task<int> CreateAsync(Customer customer)
        {
            var p1 = new SqlParameter("@FirstName", customer.FirstName);
            var p2 = new SqlParameter("@LastName", customer.LastName);
            var p3 = new SqlParameter("@Email", customer.Email);
            var p4 = new SqlParameter("@Phone", (object?)customer.Phone ?? DBNull.Value);
            var p5 = new SqlParameter("@CityID", customer.CityID);

            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_InsertCustomer @FirstName, @LastName, @Email, @Phone, @CityID",
                p1, p2, p3, p4, p5);
        }

        public async Task<int> UpdateAsync(int id, Customer customer)
        {
            var p0 = new SqlParameter("@CustomerID", id);
            var p1 = new SqlParameter("@FirstName", customer.FirstName);
            var p2 = new SqlParameter("@LastName", customer.LastName);
            var p3 = new SqlParameter("@Email", customer.Email);
            var p4 = new SqlParameter("@Phone", (object?)customer.Phone ?? DBNull.Value);
            var p5 = new SqlParameter("@CityID", customer.CityID);

            return await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_UpdateCustomer @CustomerID, @FirstName, @LastName, @Email, @Phone, @CityID",
                p0, p1, p2, p3, p4, p5);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var idParam = new SqlParameter("@CustomerID", id);
            return await _context.Database.ExecuteSqlRawAsync("EXEC sp_DeleteCustomer @CustomerID", idParam);
        }
    }
}