# CLAUDE.md

Coursework repo for **CSC367 – .NET Centric Computing** (Semester VI). C# / .NET 8
example projects, one per topic, developed on Ubuntu with VS Code. Syllabus lives in
`syallubus.txt`; repo layout and naming rules live in `CONVENTIONS.md`; the unit-by-unit
plan with Linux library-compatibility notes lives in `ROADMAP.md`.

## Rules

1. **Never add AI-assistant attribution or aliases anywhere.** No Claude or Codex
   names, abbreviations, `Co-Authored-By` trailers, or generated-by lines — not in
   branch names, commits, PRs, code comments, or docs.
2. Follow `CONVENTIONS.md`: new example = new PascalCase console project under `src/`,
   added to `College.sln` with `dotnet sln add`.
3. Stay cross-platform: target `net8.0` only. No `net8.0-windows`, WinForms, or WPF —
   they don't build on this machine. (`ConsoleApp9` is a pre-existing exception; build
   other projects individually with `dotnet build src/<Name>` if the solution build fails.)
   When an exercise demands a GUI (WinForms), keep a console adaptation as the project's
   `Program.cs` and put the real WinForms source in a `winforms/` subfolder excluded from
   the build (`<Compile Remove="winforms/**" />` in the csproj). Run that version with
   Mono, not `dotnet run` — .NET 8 has no WinForms on Linux:
   `mcs -r:System.Windows.Forms -r:System.Drawing <file>.cs -out:app.exe && mono app.exe`.
   See `src/ButtonEventDemo_1318/` for the pattern.
4. Lab-exercise projects are named `<Concept>_1318` (PascalCase concept + roll number),
   with the same `_1318` suffix on their namespaces — the lab reports require it. The
   plain concept-only naming in `CONVENTIONS.md` applies to non-lab demo projects.
5. This is a learning repo: prefer clear, idiomatic code over clever code, and keep a
   brief comment where it explains the concept being demonstrated.
6. Don't modify `syallubus.txt`.
7. `AGENTS.md` must be a byte-for-byte copy of this file. After any edit to
   `CLAUDE.md`, run `cp CLAUDE.md AGENTS.md` — CI goes red if they differ.

## Commands

- Run one project: `dotnet run --project src/<Name>`
- Build everything: `dotnet build College.sln`
- New console project: `dotnet new console -o src/<Name> && dotnet sln add src/<Name>`
