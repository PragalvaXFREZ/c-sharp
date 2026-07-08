# CSC367 Roadmap — unit by unit on Ubuntu

Working plan for the course. Each unit lists what to build, the libraries involved,
and whether they run on this machine (Ubuntu, .NET 8, VS Code). Legend:
✅ works natively · ⚠️ works with a substitution · ❌ Windows-only, theory for the exam.

## Known incompatibilities (read first)

| Library / tech | Status | What to do instead |
|---|---|---|
| `System.Windows.Forms`, WPF (`net8.0-windows`) | ❌ no Linux implementation | Rewrite demos as console apps (see `ConsoleApp9`) |
| `System.Drawing.Common` | ❌ Windows-only since .NET 7 | `SkiaSharp` or `ImageSharp` if graphics ever needed |
| SQL Server **LocalDB** (`(localdb)\mssqllocaldb`) | ❌ Windows-only | SQLite, or SQL Server in Docker |
| ASP.NET **Web Forms** | ❌ legacy, Windows-only | Theory only (Unit 2) — nothing to run |
| **IIS** hosting | ❌ Windows-only | Theory only (Unit 9); use Kestrel + Nginx instead |

Everything else in the syllabus is cross-platform.

---

## Unit 1 — Language Preliminaries (8 hrs) ✅

Console projects only, no external packages. Suggested projects (one concept each):

- [ ] `BasicConstructs` — constructors, properties, indexers, arrays/strings
- [ ] `InheritanceDemo` — base keyword, hiding vs overriding, polymorphism
- [ ] `TypesDemo` — structs, enums, abstract/sealed classes, interfaces, partial classes
- [ ] `DelegatesEvents` — delegates, events (console rewrite of `ConsoleApp9`, which is WinForms and doesn't build here)
- [ ] `CollectionsGenerics` — List/Dictionary, generic classes and methods
- [ ] `FileIoDemo` — File/Stream/Reader-Writer classes
- [ ] `LinqBasics` — lambdas, query vs method syntax
- [ ] `ExceptionsDemo` — try/catch/finally, custom exceptions
- [ ] `AttributesDemo` — attribute classes, named/positional params, targets
- [ ] `AsyncAwaitDemo` — Task, async/await, HttpClient example

## Unit 2 — Introduction to ASP.NET (3 hrs) ✅ (theory-heavy)

- [ ] Notes: .NET vs .NET Core vs Mono, CLI/MSIL/CLR compilation pipeline
- [ ] Practice the .NET CLI end to end: `dotnet new`, `build`, `run`, `test`, `publish`
- ⚠️ ASP.NET **Web Forms** is mentioned for contrast — Windows-only legacy, exam theory only.

## Unit 3 — HTTP and ASP.NET Core (3 hrs) ✅

- [ ] Inspect raw HTTP with `curl -v` against a scaffolded app
- [ ] `MvcHello` — first `dotnet new mvc` project; map the folder conventions to the MVC pattern
- Note: books target .NET Core 3.0 (`Startup.cs`); .NET 8 uses minimal hosting in `Program.cs`. Same concepts, different file.

## Unit 4 — ASP.NET Core MVC (10 hrs) ✅ — the core of the course

- [ ] `MvcControllers` — controllers, actions, ActionResult types
- [ ] `RazorViews` — Razor syntax, layouts, tag helpers
- [ ] `ModelBinding` — model binding + DataAnnotations validation
- [ ] `RoutingDemo` — conventional and attribute routing
- [ ] `ApiBasics` — `dotnet new webapi`, API controllers, JSON, test with `curl`
- [ ] `DiDemo` — dependency injection lifetimes (transient/scoped/singleton)
- All built-in (`Microsoft.AspNetCore.*` ships with the SDK). Debug with the C# Dev Kit extension.

## Unit 5 — Working with Database (6 hrs) ⚠️ substitutions needed

- [ ] `AdoBasics` — Connection/Command/Reader/Adapter using `Microsoft.Data.Sqlite`
- [ ] `EfCoreCrud` — MVC app with EF Core: model, DbContext, migrations, full CRUD
- Packages: `Microsoft.EntityFrameworkCore.Sqlite`, `Microsoft.EntityFrameworkCore.Design`, plus `dotnet tool install -g dotnet-ef`
- ⚠️ If class materials use LocalDB / `System.Data.SqlClient`: use **SQLite** (zero setup), or real SQL Server in Docker:
  `docker run -e ACCEPT_EULA=Y -e MSSQL_SA_PASSWORD=... -p 1433:1433 mcr.microsoft.com/mssql/server:2022-latest`
  with the `Microsoft.EntityFrameworkCore.SqlServer` provider — only the connection string changes.

## Unit 6 — State Management (4 hrs) ✅

- [ ] `StateDemo` — one MVC app exercising all of: Session (`AddSession`/`UseSession`), TempData,
      `HttpContext.Items`, in-memory cache, cookies, query strings, hidden fields
- All built into ASP.NET Core; nothing platform-specific.

## Unit 7 — Client-side Development (4 hrs) ✅ (needs Node.js)

- [ ] `JqueryForms` — jQuery + unobtrusive validation inside an MVC app (already in the default template)
- [ ] `ReactSpa` or `AngularSpa` — minimal SPA calling the Unit 4 Web API
- Install Node.js first (`sudo apt install nodejs npm` or via nvm). React via Vite is the lighter option.

## Unit 8 — Securing the Application (5 hrs) ✅

- [ ] `IdentityAuth` — ASP.NET Core Identity on SQLite: register/login, roles, claims, policies,
      `[Authorize]` on controllers and actions
- [ ] `VulnDemos` — deliberately broken pages showing XSS, SQL injection, CSRF, open redirect — then the fix for each
- Package: `Microsoft.AspNetCore.Identity.EntityFrameworkCore` (works fine on Linux with the SQLite provider).

## Unit 9 — Hosting and Deploying (2 hrs) ⚠️ IIS is theory-only

- [ ] Publish a build: `dotnet publish -c Release`
- [ ] Run behind **Nginx** as reverse proxy to Kestrel — Ubuntu is the ideal OS for this lab
- [ ] `Dockerfile` for one of the MVC apps; run it in a container
- [ ] Azure deploy (optional, needs account): `az webapp up`
- ❌ IIS + ASP.NET Core Module: Windows-only — learn the architecture for the exam, don't try to run it.
