-- 1. Get All Invoices
CREATE PROCEDURE sp_GetAllInvoices
AS
BEGIN
    SELECT * FROM Invoices;
END
GO

-- 2. Get Invoice By ID
CREATE PROCEDURE sp_GetInvoiceById
    @InvoiceID INT
AS
BEGIN
    SELECT * FROM Invoices WHERE InvoiceID = @InvoiceID;
END
GO

-- 3. Insert Invoice
CREATE PROCEDURE sp_InsertInvoice
    @OrderID INT,
    @InvoiceDate DATETIME,
    @DueDate DATETIME,
    @PaidDate DATETIME,
    @InvoiceStatusID INT,
    @TotalAmount DECIMAL(18,2)
AS
BEGIN
    INSERT INTO Invoices (OrderID, InvoiceDate, DueDate, PaidDate, InvoiceStatusID, TotalAmount)
    VALUES (@OrderID, @InvoiceDate, @DueDate, @PaidDate, @InvoiceStatusID, @TotalAmount);
END
GO

-- 4. Update Invoice
CREATE PROCEDURE sp_UpdateInvoice
    @InvoiceID INT,
    @OrderID INT,
    @InvoiceDate DATETIME,
    @DueDate DATETIME,
    @PaidDate DATETIME,
    @InvoiceStatusID INT,
    @TotalAmount DECIMAL(18,2)
AS
BEGIN
    UPDATE Invoices 
    SET OrderID = @OrderID,
        InvoiceDate = @InvoiceDate,
        DueDate = @DueDate,
        PaidDate = @PaidDate,
        InvoiceStatusID = @InvoiceStatusID,
        TotalAmount = @TotalAmount
    WHERE InvoiceID = @InvoiceID;
END
GO

-- 5. Delete Invoice
CREATE PROCEDURE sp_DeleteInvoice
    @InvoiceID INT
AS
BEGIN
    DELETE FROM Invoices WHERE InvoiceID = @InvoiceID;
END
GO