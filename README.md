# Airline Booking System (Mini Web App)

A beginner-friendly Airline Booking System that lets users browse flights and manage bookings. The frontend uses simple React pages (no build step) and the backend is an ASP.NET Core Web API. SQL Server is used to persist bookings.

## Project Structure
- `frontend/` - React pages (Flight list, Book flight, Edit booking)
- `backend/` - ASP.NET Core Web API (Flights + Bookings endpoints)
- `database/` - SQL Server scripts (tables, sample data, sample query)

## How to Run Locally

### Frontend (React)
1. Open `frontend/flights.html` in your browser.
2. Use the navigation to reach `book.html` and `edit.html`.

Tip: If you want live reload, open the folder in VS Code and use the Live Server extension.

### Backend (ASP.NET Core)
1. Update the connection string in `backend/appsettings.json` if needed.
2. Open a terminal in `backend/`.
3. Run:
   ```bash
   dotnet run
   ```
4. The API will be available at `http://localhost:5143`.

Endpoints:
- `GET /api/flights` - list flights
- `GET /api/bookings` - list bookings
- `POST /api/bookings` - create a booking
- `PUT /api/bookings/{id}` - update a booking
- `DELETE /api/bookings/{id}` - cancel a booking

### Database (SQL Server)
1. Create a database in SQL Server (e.g., `AirlineBooking`).
2. Run `database/create_tables.sql`.
3. Run `database/insert_sample_data.sql`.
4. Try the sample query in `database/select_flights_by_destination.sql`.

Note: The API saves bookings to SQL Server. Make sure SQL Server is running and the connection string is correct.

## Technologies Used
- HTML, CSS, JavaScript (React via CDN)
- C# ASP.NET Core Web API
- SQL Server
- Git & GitHub

## Author
- martin cene

## Git & GitHub (Step-by-Step)
1. Initialize the repository:
   ```bash
   git init
   ```
2. Add files and make the first commit:
   ```bash
   git add .
   git commit -m "Initial project structure"
   ```
3. Continue committing in small steps (example sequence):
   ```bash
   git commit -am "Add React flight list page"
   git commit -am "Add booking and edit pages with validation"
   git commit -am "Create ASP.NET Core API endpoints"
   git commit -am "Add SQL Server scripts and README"
   ```
4. Create a new GitHub repo (empty, no README).
5. Connect and push:
   ```bash
   git remote add origin https://github.com/your-username/airline-booking-system.git
   git branch -M main
   git push -u origin main
   ```
   
## Helpful SQL Command
```bash
sqlcmd -S "(localdb)\\MSSQLLocalDB" -d "AirlineBooking" -Q "SELECT BookingId, FlightId, PassengerName, Email, SeatNumber, BookingDate FROM Bookings ORDER BY BookingDate DESC;"
```
