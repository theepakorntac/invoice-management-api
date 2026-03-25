-- ดึงข้อมูลแบบระบุชื่อคอลัมน์ชัดเจน ป้องกัน Error
ALTER PROCEDURE sp_GetAllInvoices
AS
BEGIN
    SELECT InvoiceID, OrderID, InvoiceDate, DueDate, PaidDate, InvoiceStatusID, TotalAmount 
    FROM Invoices;
END
GO

ALTER PROCEDURE sp_GetInvoiceById
    @InvoiceID INT
AS
BEGIN
    SELECT InvoiceID, OrderID, InvoiceDate, DueDate, PaidDate, InvoiceStatusID, TotalAmount 
    FROM Invoices WHERE InvoiceID = @InvoiceID;
END
GO

ALTER PROCEDURE sp_InsertInvoice
    @OrderID INT, @InvoiceDate DATETIME, @DueDate DATETIME, @PaidDate DATETIME, @InvoiceStatusID INT, @TotalAmount DECIMAL(18,2)
AS
BEGIN
    INSERT INTO Invoices (OrderID, InvoiceDate, DueDate, PaidDate, InvoiceStatusID, TotalAmount)
    VALUES (@OrderID, @InvoiceDate, @DueDate, @PaidDate, @InvoiceStatusID, @TotalAmount);
END
GO

ALTER PROCEDURE sp_UpdateInvoice
    @InvoiceID INT, @OrderID INT, @InvoiceDate DATETIME, @DueDate DATETIME, @PaidDate DATETIME, @InvoiceStatusID INT, @TotalAmount DECIMAL(18,2)
AS
BEGIN
    UPDATE Invoices 
    SET OrderID = @OrderID, InvoiceDate = @InvoiceDate, DueDate = @DueDate, PaidDate = @PaidDate, InvoiceStatusID = @InvoiceStatusID, TotalAmount = @TotalAmount
    WHERE InvoiceID = @InvoiceID;
END
GO