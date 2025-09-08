CREATE TABLE Users (
  Id INT IDENTITY PRIMARY KEY,
  Username NVARCHAR(100) NOT NULL,
  Email NVARCHAR(200) NOT NULL,
  PasswordHash NVARCHAR(MAX) NOT NULL,
  Role NVARCHAR(50) NOT NULL DEFAULT 'User'
);

CREATE TABLE Products (
  Id INT IDENTITY PRIMARY KEY,
  Name NVARCHAR(200) NOT NULL,
  Description NVARCHAR(MAX),
  Category NVARCHAR(100),
  Price DECIMAL(18,2),
  Stock INT,
  ImageUrl NVARCHAR(500),
  Rating FLOAT
);

CREATE TABLE CartItems1 (
  Id INT IDENTITY PRIMARY KEY,
  UserId INT,
  ProductId INT,
  Quantity INT
);

CREATE TABLE Coupons (
  Id INT IDENTITY PRIMARY KEY,
  Code NVARCHAR(100),
  DiscountAmount DECIMAL(18,2),
  ValidFrom DATETIME,
  ValidTo DATETIME,
  AssignedUserId INT NULL -- optional, for user-specific coupons
);

CREATE TABLE Orders (
  Id INT IDENTITY PRIMARY KEY,
  UserId INT,
  Total DECIMAL(18,2),
  CreatedAt DATETIME DEFAULT GETUTCDATE()
);
