CREATE PROCEDURE sp_GetCustomerReport AS BEGIN SELECT * FROM v_CustomerDetails; END;
GO
CREATE PROCEDURE sp_GetProductReport AS BEGIN SELECT * FROM v_ProductDetails; END;
GO
CREATE PROCEDURE sp_GetOrderReport AS BEGIN SELECT * FROM v_OrderSummary; END;
GO
CREATE PROCEDURE sp_GetInvoiceReport AS BEGIN SELECT * FROM v_InvoiceFullReport; END;
GO