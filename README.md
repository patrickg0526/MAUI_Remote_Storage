# MAUI Remote Storage

A .NET MAUI app that stores and retrieves people through a RESTful ASP.NET Core Web API instead of a local database.

## Projects

- **PeopleWebAPI**: ASP.NET Core Web API (HTTP, port 5080) with a `PersonController`:
  - `GET /api/Person` returns all people
  - `POST /api/Person` saves a person
  - Data is stored in SQLite on the server (`PeopleSQLite.db3` next to the API binaries) using the Week 3 data access code, converted to synchronous calls.
  - Swagger UI at `http://localhost:5080/swagger`
- **MAUI_Data_Access**: the Week 3 app, with `DataAccess/PersonData.cs` rewritten to call the API with `HttpClient` and Newtonsoft.Json.

## Running

1. Start the API: `dotnet run --launch-profile http` in `PeopleWebAPI` (or run it from Visual Studio).
2. Run `MAUI_Data_Access` on Windows Machine. People entered in the app are saved by the API and listed from it.
