param(
    [string]$DbName = "AirlineBooking",
    [string]$Instance = "(localdb)\\MSSQLLocalDB"
)

$ErrorActionPreference = "Stop"

Write-Host "Starting LocalDB instance..."
sqllocaldb start MSSQLLocalDB | Out-Null

Write-Host "Creating database if missing..."
sqlcmd -S $Instance -Q "IF DB_ID('$DbName') IS NULL CREATE DATABASE [$DbName];"

Write-Host "Running create_tables.sql..."
sqlcmd -S $Instance -d $DbName -i "$(Join-Path $PSScriptRoot 'create_tables.sql')"

Write-Host "Running insert_sample_data.sql..."
sqlcmd -S $Instance -d $DbName -i "$(Join-Path $PSScriptRoot 'insert_sample_data.sql')"

Write-Host "Showing recent bookings..."
sqlcmd -S $Instance -d $DbName -Q "SELECT TOP 10 BookingId, FlightId, PassengerName, Email, SeatNumber, BookingDate FROM Bookings ORDER BY BookingDate DESC;"

Write-Host "Done. Database ready: $DbName on $Instance"
