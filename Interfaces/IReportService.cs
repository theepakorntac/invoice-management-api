using invoice_management_api.Models;

namespace invoice_management_api.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<ReportCustomer>> GetCustomerDetailsReportAsync();

        Task<IEnumerable<ReportInvoice>> GetInvoiceFullReportAsync();

        Task<IEnumerable<ReportOrder>> GetOrderSummaryReportAsync();

        Task<IEnumerable<ReportProduct>> GetProductDetailsReportAsync();
    }
}