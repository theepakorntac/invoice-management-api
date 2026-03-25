-- 1. Get All Companies
CREATE PROCEDURE sp_GetAllCompanies
AS
BEGIN
    SELECT * FROM Companies;
END
GO

-- 2. Get Company By ID
CREATE PROCEDURE sp_GetCompanyById
    @CompanyID INT
AS
BEGIN
    SELECT * FROM Companies WHERE CompanyID = @CompanyID;
END
GO

-- 3. Insert Company
CREATE PROCEDURE sp_InsertCompany
    @CompanyName NVARCHAR(200),
    @RegistrationNo NVARCHAR(50),
    @Industry NVARCHAR(100),
    @Country NVARCHAR(100),
    @Phone NVARCHAR(20),
    @Email NVARCHAR(255),
    @EstablishedYear INT
AS
BEGIN
    INSERT INTO Companies (CompanyName, RegistrationNo, Industry, Country, Phone, Email, EstablishedYear)
    VALUES (@CompanyName, @RegistrationNo, @Industry, @Country, @Phone, @Email, @EstablishedYear);
END
GO

-- 4. Update Company
CREATE PROCEDURE sp_UpdateCompany
    @CompanyID INT,
    @CompanyName NVARCHAR(200),
    @RegistrationNo NVARCHAR(50),
    @Industry NVARCHAR(100),
    @Country NVARCHAR(100),
    @Phone NVARCHAR(20),
    @Email NVARCHAR(255),
    @EstablishedYear INT
AS
BEGIN
    UPDATE Companies 
    SET CompanyName = @CompanyName,
        RegistrationNo = @RegistrationNo,
        Industry = @Industry,
        Country = @Country,
        Phone = @Phone,
        Email = @Email,
        EstablishedYear = @EstablishedYear
    WHERE CompanyID = @CompanyID;
END
GO

-- 5. Delete Company
CREATE PROCEDURE sp_DeleteCompany
    @CompanyID INT
AS
BEGIN
    DELETE FROM Companies WHERE CompanyID = @CompanyID;
END
GO