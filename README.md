# ServiceDesk

ServiceDesk is an ASP.NET Core MVC web application for managing repair requests in a service center for office equipment — printers, multifunction devices (MFC), laptops and desktop computers.

A service center registers incoming repair requests, links each one to the customer's device, assigns it to a technician and tracks it through its lifecycle until it is completed or cancelled.

## Features

- **Dashboard** — the home page shows how many requests are new, in progress, waiting for parts and completed.
- **Service requests (full CRUD)**
  - List of all requests, newest first, with a colored status badge
  - Details page with device, customer, technician, dates and estimated price
  - Create and edit forms with drop-downs for device, technician and status
  - Delete with a confirmation page
  - The completion date is set automatically when a request is marked as `Completed` and cleared if it is reopened
- **Technicians**
  - List of technicians with the number of their active (not completed / not cancelled) requests
  - Add a new technician
- **Validation** — server-side (Data Annotations + `ModelState`) and client-side (jQuery Validation), with error messages in Bulgarian
- **Seed data** — the database is created with sample customers, devices, technicians and requests, so the application is not empty on first run

## Technologies

- .NET 8, ASP.NET Core MVC
- Entity Framework Core 8 (code-first, migrations)
- Microsoft SQL Server (LocalDB)
- Razor views, partial views, Bootstrap 5
- jQuery Validation / jQuery Validation Unobtrusive

## Architecture

```
ServiceDesk/
├── Common/            Validation constants (string lengths, price range)
├── Controllers/       Thin MVC controllers — they only call services
├── Data/
│   ├── Models/        Entities: Customer, Device, Technician, ServiceRequest (+ enums)
│   ├── Configurations/ IEntityTypeConfiguration classes with seed data
│   ├── Migrations/    EF Core migrations
│   └── ApplicationDbContext.cs
├── Services/          Business logic (ServiceRequestService, TechnicianService)
│   └── Interfaces/    Service contracts, registered in Program.cs (DI)
├── ViewModels/        Models passed to the views — entities are never sent to views directly
└── Views/             Razor views, _Layout, partials (_StatusBadge)
```

### Database relations

- `Customer` 1 — N `Device`
- `Device` 1 — N `ServiceRequest`
- `Technician` 1 — N `ServiceRequest` (a request may have no technician yet)

## Getting started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server LocalDB (installed with Visual Studio, or via the SQL Server Express installer)
- EF Core CLI tools:

```bash
dotnet tool install --global dotnet-ef --version 8.0.32
```

### Setup

1. Clone the repository:

```bash
git clone https://github.com/AtanasAngelovCSharp/ServiceDesk.git
cd ServiceDesk
```

2. Restore packages:

```bash
dotnet restore
```

3. Create the database and apply the migrations (this also inserts the seed data):

```bash
dotnet ef database update
```

4. Run the application:

```bash
dotnet run
```

5. Open `http://localhost:5091` in a browser.

### Connection string

The connection string is in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=ServiceDesk;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

It uses **Windows authentication** (`Trusted_Connection=True`), so **no username or password is needed**. If you use a full SQL Server instance instead of LocalDB, change the `Server=` part, for example `Server=.;` or `Server=.\SQLEXPRESS;`.

### Credentials

The application has no user accounts or login — no credentials are required.
