-- Create or update Manufacturer table
CREATE TABLE IF NOT EXISTS Manufacturer (
    ManufacturerID INT PRIMARY KEY,
    ManufacturerName VARCHAR(100)
);

-- Insert or update sample data into Manufacturer table
INSERT INTO Manufacturer (ManufacturerID, ManufacturerName) VALUES
(1, 'Manufacturer A'),
(2, 'Manufacturer B'),
(3, 'Manufacturer C')
ON DUPLICATE KEY UPDATE ManufacturerName = VALUES(ManufacturerName);

-- Create or update Product table
CREATE TABLE IF NOT EXISTS Product (
    ID INT PRIMARY KEY,
    Name VARCHAR(100),
    Price DECIMAL(10, 2),
    Country VARCHAR(50),
    ExpireDate DATE,
    Contact VARCHAR(100),
    ManufacturerID INT,
    FOREIGN KEY (ManufacturerID) REFERENCES Manufacturer(ManufacturerID)
);

-- Insert sample data into Product table
INSERT INTO Product (ID, Name, Price, Country, ExpireDate, Contact, ManufacturerID) VALUES
(1, 'Product A', 10.99, 'Country A', '2024-04-30', 'contactA@example.com', 1),
(2, 'Product B', 20.49, 'Country B', '2024-05-15', 'contactB@example.com', 2),
(3, 'Product C', 15.75, 'Country C', '2024-06-01', 'contactC@example.com', 3)
ON DUPLICATE KEY UPDATE 
    Name = VALUES(Name),
    Price = VALUES(Price),
    Country = VALUES(Country),
    ExpireDate = VALUES(ExpireDate),
    Contact = VALUES(Contact),
    ManufacturerID = VALUES(ManufacturerID);
