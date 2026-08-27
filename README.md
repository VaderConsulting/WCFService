# WCFService

VB.NET Visual Studio 2008 WCF web application that exposes a CADS4 configuration service over basicHttpBinding. `ConfigService` hosts `CADS4.svc` implementing `IConfig`: the constructor loads a master config file (default `C:\Temp\Master.config`, with `%APPPATH%` expansion) and `GetConfigCollection` resolves named collections (`server`, `root`, `attribute`, `search`, `security`, `detail`) to further files through the sibling Framework `Utility` `ConfigFile` helper; `SetConfigCollection` is still a TODO stub. `ConfigClientTest` is a WinForms client with generated service references to a remote Config endpoint and a local Cassini host on port 8439 (`/Config`); `Button1` calls `GetConfigCollection("server")`. A leftover `WCFService` class-library template (`IService1` / `Service1`) shares the service folder but is not in the solution.

**Source last updated:** 2008-10-02 · **Language:** VB.NET · **Target:** .NET Framework 3.5 · **Output:** WCF ASP.NET web application library (`ConfigService`) and WinForms executable (`ConfigClientTest`)

## Solution structure

| Project | Language | Type | Purpose |
|---------|----------|------|---------|
| `ConfigService` (`WCFService/ConfigService.vbproj`) | VB.NET | WCF web application (`Library`, `.svc`, net35) | Hosts `CADS4.svc` / `IConfig` named config collections over `basicHttpBinding` plus MEX. |
| `ConfigClientTest` (`ConfigClientTest/ConfigClientTest.vbproj`) | VB.NET | WinForms exe (`WinExe`, net35) | Test client; remote and local `ConfigClient` proxies; `Button1` loads the `server` collection. |
| `WCFService` (`WCFService/WCFService.vbproj`, not in `.sln`) | VB.NET | WCF class library (`Library`, net35) | VS 2008 template `IService1` / `Service1` leftover sharing the service folder. |
| `Utility` (`..\Framework\Utility\Utility.vbproj`, not in this zip) | VB.NET | Class library | Sibling Historical Dev `Framework` project referenced for `ConfigFile` / error types. |

## How to open

Open `WCFService.sln` in Visual Studio 2008 or later (solution format 10.00 / ToolsVersion 3.5). Restore the sibling `Framework\Utility` project (solution path `..\Framework\Utility\Utility.vbproj`) or the `ConfigService` and `ConfigClientTest` projects will not build. `ConfigService` is a web application using the VS development server on port 8439, virtual path `/Config` (`CADS4.svc`). Default master config path is `C:\Temp\Master.config`. Requires .NET Framework 3.5 and `System.ServiceModel`. Files that contained an internal hostname or Windows username are gitignored; use the matching `*.example` copies.

## Attribution and provenance

Working copy from Dave Robinson's OneDrive Historical Dev folder `WCFService`. `ConfigService` assembly company/copyright is Stratatel 2008 (`AssemblyTitle` ConfigService). `ConfigClientTest` still has the Visual Studio template defaults (Microsoft 2008). Service type `ConfigService.CADS4`; contract `IConfig`; namespaces `ConfigService` / `ConfigClientTest`.

## License

MIT © 2026 VaderConsulting. See `LICENSE`.
