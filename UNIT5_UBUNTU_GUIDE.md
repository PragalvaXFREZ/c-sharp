# Unit 5 database setup on Ubuntu

This guide reproduces the repository's Unit 5 database environment on Ubuntu.
It replaces the Windows-only tools used in the class handout with supported
cross-platform equivalents while preserving the ADO.NET and Entity Framework
Core concepts being taught.

The result is:

- an ADO.NET console application backed by SQLite;
- an ASP.NET Core MVC application backed by EF Core and SQLite;
- a repository-local `dotnet-ef` command; and
- a repeatable migration and verification workflow.

This is the environment setup and foundation for Unit 5. It also documents the
database-first console exercise. The full MVC CRUD screens are separate
follow-up work.

## 1. Understand the platform substitutions

Do not try to install SQL Server LocalDB or use Visual Studio's Package Manager
Console on Ubuntu. Use the following equivalents:

| Class handout | Ubuntu equivalent |
|---|---|
| Visual Studio | VS Code with C# Dev Kit |
| Package Manager Console | `dotnet` and `dotnet ef` in a terminal |
| .NET/EF Core 5 | .NET/EF Core 8 |
| SQL Server LocalDB | SQLite |
| `System.Data.SqlClient` | `Microsoft.Data.Sqlite` |
| `SqlConnection` | `SqliteConnection` |
| `SqlCommand` | `SqliteCommand` |
| `SqlDataReader` | `SqliteDataReader` |
| `add-migration` | `dotnet ef migrations add` |
| `update-database` | `dotnet ef database update` |

`Microsoft.Data.Sqlite` does not provide a `DataAdapter`. The ADO.NET example
loads a reader into a `DataTable` instead. This still demonstrates the handout's
connected reader flow and a disconnected in-memory table without requiring a
Windows-only database.

## 2. Install the workstation tools

Open a terminal and install Git, curl, and the .NET 8 SDK:

```bash
sudo apt update
sudo apt install -y git curl dotnet-sdk-8.0
```

Confirm that the SDK is available:

```bash
dotnet --version
```

The output must start with `8.0`. A different patch number is fine.

Install VS Code if it is not already installed. Then install the C# extensions:

```bash
code --install-extension ms-dotnettools.csharp
code --install-extension ms-dotnettools.csdevkit
```

The editor is recommended, but all remaining steps work from the terminal.

## 3. Clone and enter the repository

```bash
git clone https://github.com/PragalvaXFREZ/c-sharp.git
cd c-sharp
```

Run every remaining command from the repository root, which contains
`College.sln`.

## 4. Restore the EF tool and project packages

Restore the repository-local EF Core command:

```bash
dotnet tool restore
dotnet ef --version
```

The EF command must report version `8.0.21`.

Restore the two Unit 5 projects individually:

```bash
dotnet restore src/AdoBasics/AdoBasics.csproj
dotnet restore src/EfCoreCrud/EfCoreCrud.csproj
```

The important dependencies are already recorded in the project files:

- `AdoBasics`: `Microsoft.Data.Sqlite` 8.0.21
- `EfCoreCrud`: `Microsoft.EntityFrameworkCore.Sqlite` 8.0.21
- `EfCoreCrud`: `Microsoft.EntityFrameworkCore.Design` 8.0.21

Do not replace those SQLite packages with LocalDB or `System.Data.SqlClient` on
Ubuntu.

## 5. Build both projects

```bash
dotnet build src/AdoBasics/AdoBasics.csproj
dotnet build src/EfCoreCrud/EfCoreCrud.csproj
```

Both commands must finish with `Build succeeded` and zero errors.

Do not use `dotnet build College.sln` as the Unit 5 verification command on
Ubuntu. The solution contains the pre-existing Windows Forms project
`ConsoleApp9`, which is intentionally Windows-only.

## 6. Verify the ADO.NET application

Run the console project:

```bash
dotnet run --project src/AdoBasics/AdoBasics.csproj
```

Expected output:

```text
Students in the SQLite database:
1: Pragalva - CSC367
```

The application performs the following sequence in
[`src/AdoBasics/Program.cs`](src/AdoBasics/Program.cs):

1. Opens a `SqliteConnection`.
2. Creates the `Students` table with `ExecuteNonQuery`.
3. Checks the row count with `ExecuteScalar`.
4. Inserts a parameterized row with `ExecuteNonQuery`.
5. Reads rows with `ExecuteReader`.
6. Loads those rows into a disconnected `DataTable`.

Its database is generated at
`src/AdoBasics/bin/Debug/net8.0/students.db`. It is a build artifact and must not
be committed.

## 7. Verify the EF Core migration

List the migration included in the repository:

```bash
dotnet ef migrations list \
  --project src/EfCoreCrud \
  --startup-project src/EfCoreCrud
```

The list must contain an `InitialCreate` migration.

Apply it to the SQLite database:

```bash
dotnet ef database update \
  --project src/EfCoreCrud \
  --startup-project src/EfCoreCrud
```

The first run creates `src/EfCoreCrud/EfCoreCrud.db` and its `Students` table.
Later runs should report that the database is already up to date. The database
file is local runtime data and must not be committed.

The EF Core setup consists of:

- [`Models/Student.cs`](src/EfCoreCrud/Models/Student.cs): the entity model;
- [`Data/CollegeContext.cs`](src/EfCoreCrud/Data/CollegeContext.cs): the
  `DbContext` and `Students` set;
- [`Data/Migrations/`](src/EfCoreCrud/Data/Migrations/): the generated code-first
  migration;
- [`appsettings.json`](src/EfCoreCrud/appsettings.json): the SQLite database
  filename; and
- [`Program.cs`](src/EfCoreCrud/Program.cs): dependency injection and the SQLite
  provider configuration.

## 8. Verify the MVC application

Start the application on a known HTTP port:

```bash
dotnet run --project src/EfCoreCrud/EfCoreCrud.csproj \
  --urls http://127.0.0.1:5079
```

Leave that terminal running. In a second terminal, enter the repository again
and request the home page:

```bash
cd c-sharp
curl --silent --show-error --output /dev/null \
  --write-out 'HTTP %{http_code}\n' \
  http://127.0.0.1:5079/
```

Expected output:

```text
HTTP 200
```

Return to the first terminal and press `Ctrl+C` to stop the server. An HTTPS
redirection warning can appear because this verification deliberately uses a
temporary HTTP-only address; it does not mean the application failed.

## 9. Database-first console exercise

The class handout's database-first example is kept in
`src/unit5/DatabaseWithCode_1318`. On Ubuntu, SQLite replaces the handout's
Windows-only LocalDB and Package Manager Console commands.

First, restore the local EF command and add the matching EF Core packages:

```bash
dotnet tool restore
dotnet add src/unit5/DatabaseWithCode_1318 \
  package Microsoft.EntityFrameworkCore.Sqlite --version 8.0.21
dotnet add src/unit5/DatabaseWithCode_1318 \
  package Microsoft.EntityFrameworkCore.Design --version 8.0.21
```

Create the database before scaffolding. At the `sqlite>` prompt, the final
column must not end with a comma:

```bash
sqlite3 src/unit5/DatabaseWithCode_1318/db_mydatabase_unit5.db
```

```sql
CREATE TABLE TbStudents (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Address TEXT NOT NULL,
    Gender TEXT NOT NULL,
    Salary NUMERIC NOT NULL
);

.tables
.quit
```

Generate the entity and `DbContext` classes from that existing schema:

```bash
dotnet tool run dotnet-ef dbcontext scaffold \
  "Data Source=db_mydatabase_unit5.db" \
  Microsoft.EntityFrameworkCore.Sqlite \
  --project src/unit5/DatabaseWithCode_1318 \
  --startup-project src/unit5/DatabaseWithCode_1318 \
  --output-dir Models \
  --context-dir Models \
  --context DbMydatabaseUnit5Context \
  --no-onconfiguring
```

The expected generated files are `Models/TbStudent.cs` and
`Models/DbMydatabaseUnit5Context.cs`. The scaffold command omits connection
configuration from generated source; `Program.cs` supplies the local database
path at runtime.

Build the project and run the PDF's save, update, load, and delete sequence:

```bash
dotnet build src/unit5/DatabaseWithCode_1318
find src/unit5/DatabaseWithCode_1318/Models -maxdepth 1 -type f | sort
dotnet run --project src/unit5/DatabaseWithCode_1318 -- \
  src/unit5/DatabaseWithCode_1318/db_mydatabase_unit5.db
```

The run creates one student, updates and prints it, then deletes the same row.
Using the generated identity value instead of a hardcoded ID makes repeated
runs safe.

If the database schema changes, run the same scaffold command with `--force`.
That overwrites generated files, so do not place handwritten changes in them.
The `.db` file is ignored by Git and should not be committed.

## 10. Troubleshooting

### `dotnet ef` is not found

Run this from the repository root:

```bash
dotnet tool restore
```

Do not rely on an unrelated global `dotnet-ef` installation.

### LocalDB connection errors appear

A copied Windows connection string usually contains
`(LocalDB)\MSSQLLocalDB`. Remove it and use the existing SQLite configuration.
LocalDB is not available on Ubuntu.

### The whole solution fails to build

Build the Unit 5 projects individually. `ConsoleApp9` is a Windows Forms project
and is the expected Linux exception.

### A migration reports a version mismatch

Confirm that the EF packages and `dotnet-ef` are all version `8.0.21`. Then run:

```bash
dotnet tool restore
dotnet restore src/EfCoreCrud/EfCoreCrud.csproj
```

### A clean database is needed

The databases contain sample data only. Stop running applications, remove the
generated files, and recreate them:

```bash
rm -f src/AdoBasics/bin/Debug/net8.0/students.db
rm -f src/EfCoreCrud/EfCoreCrud.db
dotnet run --project src/AdoBasics/AdoBasics.csproj
dotnet ef database update \
  --project src/EfCoreCrud \
  --startup-project src/EfCoreCrud
```

## Completion checklist

- [ ] `dotnet --version` starts with `8.0`.
- [ ] `dotnet tool restore` succeeds.
- [ ] Both Unit 5 projects build with zero errors.
- [ ] `AdoBasics` prints the expected student row.
- [ ] `dotnet ef migrations list` shows `InitialCreate`.
- [ ] `dotnet ef database update` succeeds.
- [ ] The MVC home page returns HTTP 200.
- [ ] The database-first scaffold generates `TbStudent` and
      `DbMydatabaseUnit5Context`.
- [ ] The database-first console project completes its CRUD demonstration.
- [ ] No generated `.db` file is staged for commit.

When every item is checked, the Ubuntu database environment is ready. Full MVC
CRUD actions and views are the next implementation milestone.
