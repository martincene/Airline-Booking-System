INSERT INTO Flights (FlightNumber, Origin, Destination, DepartureTime, SeatsAvailable)
VALUES
('AL101', 'Tirana (TIA)', 'Rome (FCO)', '2026-01-30 08:30:00', 12),
('AL202', 'Tirana (TIA)', 'Vienna (VIE)', '2026-01-30 11:15:00', 5),
('AL303', 'Tirana (TIA)', 'Istanbul (IST)', '2026-01-30 15:45:00', 20);

INSERT INTO Bookings (FlightId, PassengerName, Email, SeatNumber)
VALUES
(1, 'Alex Johnson', 'alex@email.com', '12A'),
(2, 'Riley Chen', 'riley@email.com', '7C');
