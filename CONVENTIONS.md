# Repository Conventions

Simple rules for keeping this coursework repo (CSC367 – .NET Centric Computing) tidy.

## Layout

- Group projects by syllabus unit under `src/unit<N>/`, e.g. `src/unit1/EventExample/`.
- Every lab exercise or topic demo is its own project inside its unit directory.
- Every project is registered in `College.sln`:
  `dotnet sln add src/unit<N>/<ProjectName>/<ProjectName>.csproj`
- Keep each example small and self-contained — one concept per project.

## Naming

- Projects use PascalCase and are named after the concept they demonstrate:
  `DelegatesDemo`, `LinqBasics`, `FileIoExample` — not IDE defaults like `ConsoleApp9`.
- When ASP.NET Core units start, prefix web projects with the topic:
  `MvcHelloWorld`, `EfCoreCrud`, `IdentityAuthDemo`.

## Cross-platform

- This repo is developed on Ubuntu. Target plain `net8.0` only — no
  `net8.0-windows`, WinForms, or WPF (they break `dotnet build College.sln` on Linux).
  `src/unit1/ConsoleApp9` predates this rule and is the known exception.

## Commits

- Short imperative subject line: `Add LinqBasics project`, `Fix event unsubscribe in EventExample`.
- Commit per finished exercise, not per keystroke.
- Never commit `bin/`, `obj/`, or other build output (covered by `.gitignore`).
