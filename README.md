# CSC367 — C# / .NET Coursework

Example projects for the ".NET Centric Computing" course, one small project per topic
under `src/`. Everything here runs with the free .NET SDK and a terminal —
**you do not need Visual Studio.**

## 1. Install the .NET 8 SDK

**Ubuntu / Debian**

```bash
sudo apt update && sudo apt install dotnet-sdk-8.0
```

**Other Linux distros** — Fedora: `sudo dnf install dotnet-sdk-8.0`.
Anything else: https://learn.microsoft.com/dotnet/core/install/linux

**Windows**

```powershell
winget install Microsoft.DotNet.SDK.8
```

Check it worked (any OS):

```bash
dotnet --version   # should print 8.0.something
```

## 2. Get the code

```bash
git clone https://github.com/PragalvaXFREZ/c-sharp.git
cd c-sharp
```

## 3. Run a project

```bash
dotnet run --project src/College
dotnet run --project src/EventExample
```

That's it. `dotnet` compiles and runs in one step.

## 4. Editor (optional but recommended)

Any text editor works, but VS Code gives you IntelliSense and a debugger:

1. Install VS Code: https://code.visualstudio.com (or `winget install Microsoft.VisualStudioCode`)
2. Install the **C# Dev Kit** extension
3. Open this folder, open any `Program.cs`, press **F5** to debug

## Honest notes / known issues

- `src/ConsoleApp9` is a **Windows Forms** app — it only builds and runs on Windows.
  Because of it, `dotnet build College.sln` **fails on Linux**; build or run projects
  individually instead (as shown above). Every other project is fully cross-platform.
- No Visual Studio, ever: `dotnet new`, `build`, `run`, and `publish` from the
  terminal cover everything this course needs.
- See `ROADMAP.md` for the unit-by-unit plan and which course libraries need
  substitutes on Linux (e.g. SQLite instead of SQL Server LocalDB).
