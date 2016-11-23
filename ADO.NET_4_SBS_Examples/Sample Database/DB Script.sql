USE StepSample
GO

/* ----- Table: StateRegion */
CREATE TABLE StateRegion
(
  ID            bigint       PRIMARY KEY IDENTITY(1,1),
  FullName      varchar(50)  NOT NULL,
  Abbreviation  varchar(2)   NOT NULL,
  RegionType    smallint     NOT NULL,
  Admitted      date         NULL,
  Capital       varchar(50)  NULL
);
GO

INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Alabama', 'AL', 1, '1819-Dec-14', 'Montgomery');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Alaska', 'AK', 1, '1959-Jan-03', 'Juneau');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Arizona', 'AZ', 1, '1912-Feb-14', 'Phoenix');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Arkansas', 'AR', 1, '1836-Jun-15', 'Little Rock');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('California', 'CA', 1, '1850-Sep-09', 'Sacramento');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Colorado', 'CO', 1, '1876-Aug-01', 'Denver');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Connecticut', 'CT', 1, '1788-Jan-09', 'Hartford');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Delaware', 'DE', 1, '1787-Dec-07', 'Dover');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Florida', 'FL', 1, '1845-Mar-03', 'Tallahassee');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Georgia', 'GA', 1, '1788-Jan-02', 'Atlanta');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Hawaii', 'HI', 1, '1959-Aug-21', 'Honolulu');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Idaho', 'ID', 1, '1890-Jul-03', 'Boise');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Illinois', 'IL', 1, '1818-Dec-03', 'Springfield');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Indiana', 'IN', 1, '1816-Dec-11', 'Indianapolis');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Iowa', 'IA', 1, '1846-Dec-28', 'Des Moines');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Kansas', 'KS', 1, '1861-Jan-29', 'Topeka');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Kentucky', 'KY', 1, '1792-Jun-01', 'Frankfort');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Louisiana', 'LA', 1, '1812-Apr-30', 'Baton Rouge');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Maine', 'ME', 1, '1820-Mar-15', 'Augusta');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Maryland', 'MD', 1, '1788-Apr-28', 'Annapolis');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Massachusetts', 'MA', 1, '1788-Feb-06', 'Boston');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Michigan', 'MI', 1, '1837-Jan-26', 'Lansing');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Minnesota', 'MN', 1, '1858-May-11', 'St. Paul');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Mississippi', 'MS', 1, '1817-Dec-10', 'Jackson');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Missouri', 'MO', 1, '1821-Aug-10', 'Jefferson City');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Montana', 'MT', 1, '1889-Nov-08', 'Helena');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Nebraska', 'NE', 1, '1867-Mar-01', 'Lincoln');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Nevada', 'NV', 1, '1864-Oct-31', 'Carson City');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('New Hampshire', 'NH', 1, '1788-Jun-21', 'Concord');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('New Jersey', 'NJ', 1, '1787-Dec-18', 'Trenton');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('New Mexico', 'NM', 1, '1912-Jan-06', 'Santa Fe');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('New York', 'NY', 1, '1788-Jul-26', 'Albany');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('North Carolina', 'NC', 1, '1789-Nov-21', 'Raleigh');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('North Dakota', 'ND', 1, '1889-Nov-02', 'Bismarck');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Ohio', 'OH', 1, '1803-Mar-01', 'Columbus');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Oklahoma', 'OK', 1, '1907-Nov-16', 'Oklahoma City');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Oregon', 'OR', 1, '1859-Feb-14', 'Salem');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Pennsylvania', 'PA', 1, '1787-Dec-12', 'Harrisburg');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Rhode Island', 'RI', 1, '1790-May-29', 'Providence');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('South Carolina', 'SC', 1, '1788-May-23', 'Columbia');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('South Dakota', 'SD', 1, '1889-Nov-02', 'Pierre');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Tennessee', 'TN', 1, '1796-Jun-01', 'Nashville');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Texas', 'TX', 1, '1845-Dec-29', 'Austin');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Utah', 'UT', 1, '1896-Jan-04', 'Salt Lake City');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Vermont', 'VT', 1, '1791-Mar-04', 'Montpelier');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Virginia', 'VA', 1, '1788-Jun-25', 'Richmond');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Washington', 'WA', 1, '1889-Nov-11', 'Olympia');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('West Virginia', 'WV', 1, '1863-Jun-20', 'Charleston');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Wisconsin', 'WI', 1, '1848-May-29', 'Madison');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('Wyoming', 'WY', 1, '1890-Jul-10', 'Cheyenne');
INSERT INTO StateRegion (FullName, Abbreviation, RegionType, Admitted, Capital) VALUES
  ('District of Columbia', 'DC', 2, NULL, NULL);
GO

/* ----- Table: Customer */
CREATE TABLE Customer
(
  ID            bigint        PRIMARY KEY IDENTITY(1,1),
  FullName      varchar(50)   NOT NULL,
  Address1      varchar(50)   NULL,
  Address2      varchar(50)   NULL,
  City          varchar(25)   NULL,
  StateRegion   bigint        NULL FOREIGN KEY REFERENCES StateRegion (ID),
  PostalCode    varchar(10)   NULL,
  PhoneNumber   varchar(15)   NULL,
  WebSite       varchar(150)  NULL,
  AnnualFee     money         NOT NULL CONSTRAINT DefaultAnnualFee DEFAULT 0
);
GO

SET IDENTITY_INSERT Customer ON;
GO

INSERT INTO Customer (ID, FullName, WebSite, AnnualFee,
  Address1, City, PostalCode, StateRegion) VALUES
  (1, 'Coho Vineyard', 'http://www.cohovineyard.com', 200,
  '123 Main Street', 'Albany', '85000',
  (SELECT ID FROM StateRegion WHERE Abbreviation = 'NY'));
INSERT INTO Customer (ID, FullName, WebSite, AnnualFee,
  Address1, City, PostalCode, StateRegion) VALUES
  (2, 'Fourth Coffee', 'http://www.fourthcoffee.com', 200,
  '9876 Oak Boulevard', 'Los Angeles', '00110',
  (SELECT ID FROM StateRegion WHERE Abbreviation = 'CA'));
INSERT INTO Customer (ID, FullName, WebSite, AnnualFee,
  Address1, City, PostalCode, StateRegion) VALUES
  (3, 'Tailspin Toys', 'http://www.tailspintoys.com', 150,
  '23 Jefferson Avenue', 'Hamilton', '77002',
  (SELECT ID FROM StateRegion WHERE Abbreviation = 'MT'));
GO

SET IDENTITY_INSERT Customer OFF;
GO

/* ----- Table: OrderEntry */
CREATE TABLE OrderEntry
(
  ID            bigint        PRIMARY KEY IDENTITY(1,1),
  Customer      bigint        NOT NULL FOREIGN KEY REFERENCES Customer (ID),
  OrderDate     date          NOT NULL,
  ShipDate      date          NULL,
  Subtotal      money         NOT NULL,
  SalesTax      money         NOT NULL,
  Total         money         NOT NULL,
  StatusCode    varchar(1)    NOT NULL  /* P=Pending, C=Complete, X=Canceled */
);
GO

INSERT INTO OrderEntry (Customer, OrderDate, ShipDate, Subtotal, SalesTax, Total, StatusCode) VALUES
  (1, '5-Jan-2010', '9-Jan-2010', 392.04, 34.30, 426.34, 'C');
INSERT INTO OrderEntry (Customer, OrderDate, Subtotal, SalesTax, Total, StatusCode) VALUES
  (1, '10-Mar-2010', 900.00, 78.75, 978.75, 'X');
INSERT INTO OrderEntry (Customer, OrderDate, Subtotal, SalesTax, Total, StatusCode) VALUES
  (2, '23-Feb-2010', 197.88, 17.31, 215.19, 'C');
GO

/* ----- Stored procedure that returns customer record and related orders. */
CREATE PROCEDURE dbo.GetCustomerOrders(@customerID bigint) AS
BEGIN
  SELECT * FROM Customer WHERE ID = @customerID;
  SELECT * FROM OrderEntry WHERE Customer = @customerID ORDER BY OrderDate;
END;
GO

/* ----- Stored procedure that removes an order. */
CREATE PROCEDURE dbo.CancelOrder(@orderID bigint) AS
BEGIN
  DELETE FROM OrderEntry WHERE ID = @orderID;
END;
GO

/* ----- Table: UnitOfMeasure */
CREATE TABLE UnitOfMeasure
(
  ID            bigint       PRIMARY KEY IDENTITY(1,1),
  ShortName     varchar(15)  NOT NULL,
  FullName      varchar(50)  NOT NULL
);
GO

INSERT INTO UnitOfMeasure (ShortName, FullName) VALUES ('kg', 'kilogram');
INSERT INTO UnitOfMeasure (ShortName, FullName) VALUES ('oz', 'ounce');
INSERT INTO UnitOfMeasure (ShortName, FullName) VALUES ('lb', 'pound');
GO

/* ----- Table: BankAccount */
CREATE TABLE BankAccount
(
  AccountNumber   varchar(15)  PRIMARY KEY,
  AccountName     varchar(50)  NOT NULL,
  AccountType     varchar(1)   NOT NULL
    CONSTRAINT CheckingSavings CHECK (AccountType = 'C' OR AccountType = 'S'),
  Balance         money        NOT NULL
    CONSTRAINT NoNegativeBalance CHECK (Balance >= 0)
);
GO

INSERT INTO BankAccount (AccountNumber, AccountName, AccountType, Balance)
  VALUES ('123456789', 'John Smith', 'C', 500);
INSERT INTO BankAccount (AccountNumber, AccountName, AccountType, Balance)
  VALUES ('987654321', 'John Smith', 'S', 10000);
GO

/* ----- Table: CourseCatalog */
CREATE TABLE CourseCatalog
(
  CourseID        varchar(6)   PRIMARY KEY,
  CourseName      varchar(50)  NOT NULL,
  OfferedFall     bit          NOT NULL,
  OfferedSpring   bit          NOT NULL,
  CreditHours     smallint     NOT NULL,
  Prerequisite    varchar(6)   NULL
);
GO

INSERT INTO CourseCatalog (CourseID, CourseName, OfferedFall, OfferedSpring, CreditHours, Prerequisite)
  VALUES ('CS101', 'Introduction to Computer Science I', 'TRUE', 'TRUE', 5, NULL);
INSERT INTO CourseCatalog (CourseID, CourseName, OfferedFall, OfferedSpring, CreditHours, Prerequisite)
  VALUES ('CS102', 'Introduction to Computer Science II', 'TRUE', 'TRUE', 5, 'CS101');
INSERT INTO CourseCatalog (CourseID, CourseName, OfferedFall, OfferedSpring, CreditHours, Prerequisite)
  VALUES ('CS208', 'Database Systems', 'TRUE', 'FALSE', 5, 'CS102');
GO

/* ----- Miscellaneous functions */
CREATE FUNCTION MostRecentState(@asOfDate AS DATETIME)
RETURNS varchar(50) AS
BEGIN
  ----- Return the name of the last state to be admitted to
  --    the union as of the specified date.
  DECLARE @result varchar(50);

  SELECT @result = FullName FROM StateRegion
    WHERE Admitted <= @asOfDate;
  IF (@@ROWCOUNT = 0)
    SET @result = 'None';
  RETURN @result;
END
GO

CREATE FUNCTION AdmittedInYear(@whichDate AS DATETIME)
RETURNS int AS
BEGIN
  ----- Return the number of states admitted to the union
  --    during the year of the specified date.
  DECLARE @result int;

  SELECT @result = COUNT(*) FROM StateRegion
    WHERE DATEPART(year, Admitted) = DATEPART(year, @whichDate);
  RETURN @result;
END
GO

