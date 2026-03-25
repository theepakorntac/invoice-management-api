-- 1. Get All Invoice Statuses
CREATE PROCEDURE sp_GetAllInvoiceStatuses
AS
BEGIN
    SELECT * FROM InvoiceStatuses;
END
GO

-- 2. Get Invoice Status By ID
CREATE PROCEDURE sp_GetInvoiceStatusById
    @InvoiceStatusID INT
AS
BEGIN
    SELECT * FROM InvoiceStatuses WHERE InvoiceStatusID = @InvoiceStatusID;
END
GO

-- 3. Insert Invoice Status
CREATE PROCEDURE sp_InsertInvoiceStatus
    @StatusName NVARCHAR(50)
AS
BEGIN
    INSERT INTO InvoiceStatuses (StatusName)
    VALUES (@StatusName);
END
GO

-- 4. Update Invoice Status
CREATE PROCEDURE sp_UpdateInvoiceStatus
    @InvoiceStatusID INT,
    @StatusName NVARCHAR(50)
AS
BEGIN
    UPDATE InvoiceStatuses 
    SET StatusName = @StatusName
    WHERE InvoiceStatusID = @InvoiceStatusID;
END
GO

-- 5. Delete Invoice Status
CREATE PROCEDURE sp_DeleteInvoiceStatus
    @InvoiceStatusID INT
AS
BEGIN
    DELETE FROM InvoiceStatuses WHERE InvoiceStatusID = @InvoiceStatusID;
END
GO