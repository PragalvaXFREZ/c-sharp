# CLAUDE.md

Coursework repo for **CSC367 – .NET Centric Computing** (Semester VI). C# / .NET 8
example projects, one per topic, developed on Ubuntu with VS Code. Syllabus lives in
`syallubus.txt`; repo layout and naming rules live in `CONVENTIONS.md`; the unit-by-unit
plan with Linux library-compatibility notes lives in `ROADMAP.md`.

## Rules

1. **Never add Claude attribution or aliases anywhere.** No `Co-Authored-By: Claude`
   trailers, no "Generated with Claude Code" lines — not in commits, PRs, code
   comments, or docs.
2. Follow `CONVENTIONS.md`: new example = new PascalCase console project under `src/`,
   added to `College.sln` with `dotnet sln add`.
3. Stay cross-platform: target `net8.0` only. No `net8.0-windows`, WinForms, or WPF —
   they don't build on this machine. (`ConsoleApp9` is a pre-existing exception; build
   other projects individually with `dotnet build src/<Name>` if the solution build fails.)
4. This is a learning repo: prefer clear, idiomatic code over clever code, and keep a
   brief comment where it explains the concept being demonstrated.
5. Don't modify `syallubus.txt`.
6. `AGENTS.md` must be a byte-for-byte copy of this file. After any edit to
   `CLAUDE.md`, run `cp CLAUDE.md AGENTS.md` — CI goes red if they differ.

## Commands

- Run one project: `dotnet run --project src/<Name>`
- Build everything: `dotnet build College.sln`
- New console project: `dotnet new console -o src/<Name> && dotnet sln add src/<Name>`
