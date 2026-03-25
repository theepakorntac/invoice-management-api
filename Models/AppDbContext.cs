using invoice_management_api.Models;
using InvoiceManagementDB.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagementDB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<InvoiceStatus> InvoiceStatuses { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        //Views
        public DbSet<ReportCustomer> ReportCustomers { get; set; }
        public DbSet<ReportProduct> ReportProducts { get; set; }
        public DbSet<ReportOrder> ReportOrders { get; set; }
        public DbSet<ReportInvoice> ReportInvoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // แมพ Model เข้ากับ View ที่คุณสร้างไว้แล้ว
            modelBuilder.Entity<ReportCustomer>()
                .HasNoKey()
                .ToView("v_CustomerDetails");

            modelBuilder.Entity<ReportInvoice>()
                .HasNoKey()
                .ToView("v_InvoiceFullReport");

            modelBuilder.Entity<ReportOrder>()
                .HasNoKey()
                .ToView("v_OrderSummary");

            modelBuilder.Entity<ReportProduct>()
                .HasNoKey()
                .ToView("v_ProductDetails");
        }
    }
}