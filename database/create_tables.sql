CREATE TABLE Flights (
    FlightId INT IDENTITY(1,1) PRIMARY KEY,
    FlightNumber NVARCHAR(10) NOT NULL UNIQUE,
    Origin NVARCHAR(100) NOT NULL,
    Destination NVARCHAR(100) NOT NULL,
    DepartureTime DATETIME NOT NULL,
    SeatsAvailable INT NOT NULL
);

CREATE TABLE Bookings (
    BookingId INT IDENTITY(1,1) PRIMARY KEY,
    FlightId INT NOT NULL,
    PassengerName NVARCHAR(120) NOT NULL,
    Email NVARCHAR(120) NOT NULL,
    SeatNumber NVARCHAR(5) NOT NULL,
    BookingDate DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Bookings_Flights FOREIGN KEY (FlightId) REFERENCES Flights(FlightId),
    CONSTRAINT UQ_Bookings_FlightSeat UNIQUE (FlightId, SeatNumber)
);
