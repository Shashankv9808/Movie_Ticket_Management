# Legacy Movie Ticket Management: high-level design

## System profile

**Confirmed.** The legacy project is an ASP.NET Web Forms application targeting
.NET Framework 4.8 (`Legacy Movie Ticket Management/Movie Ticket Management/
Movie Ticket Management.csproj`). It is hosted through IIS/IIS Express,
configured by `Global.asax`, `Web.config`, and page code-behind files. It uses
System.Data.SqlClient, SQL Server, ASP.NET Session, Web Forms controls, and
AjaxControlToolkit. The project also references old MVC/WebPages assemblies,
but the user-facing pages are Web Forms.

The database connection is a machine-specific integrated-security connection to
the `Test` database in `Web.config`. This is not suitable for migration
configuration and must be replaced with environment-specific settings.

## Class and file inventory

### Application bootstrap and shared classes

| File | Class | Responsibility |
|---|---|---|
| `Global.asax.cs` | `MvcApplication` | ASP.NET application lifecycle/bootstrap. |
| `Registration.cs` | `Registration` | Shared registration/data object used by registration flow. |
| `RegistrationService.asmx.cs` | `RegistrationService` | Legacy SOAP-style registration endpoint. |
| `Properties/AssemblyInfo.cs` | none | Assembly metadata. |

### Data access and data-transfer classes

| File | Class | Responsibility |
|---|---|---|
| `DataAccess/LoginDataAccess.cs` | `LoginDataAccess` | Login/authentication database operations. |
| `DataAccess/RegisterDataAccess.cs` | `RegisterDataAccess` | Registration and duplicate-account checks. |
| `DataAccess/MovieDetailsDataAccess.cs` | `MovieDetailsDataAccess` | Movie detail retrieval. |
| `DataAccess/MovieTableInfos.cs` | `MovieTableInfos`, `MovieSeatStatus` | Movie and seat-status row-shaped data objects. |
| `DataAccess/UserAccountInfos.cs` | `UserAccountInfos` | User account row-shaped data object. |

These classes are the clearest reusable boundary in the legacy code, but they
are still tightly coupled to SQL/client configuration and should be translated
to EF entities, DTOs, repositories, and application services rather than
copied verbatim.

Important confirmed methods and transformations:

- `LoginDataAccess.IsUserAuthencication(UserAccountInfos, out bool)` calls
  `spUserAccountAuthenication`.
- `RegisterDataAccess.RegisterNewUserAccount(UserAccountInfos, out string)` and
  `GetUserAccountDataList()` call the registration/account procedures.
- `MovieDetailsDataAccess.GetMovieDataList()`,
  `GetMovieDataByID(long)`, and `GetSeatStatusDataByMovieID(long)` call the
  corresponding movie and seat procedures.
- `UserAccountInfos.Encrypt()` applies unsalted SHA-256 and Base64 encoding to
  the password before comparison.
- `MovieTableInfos.Encrypt/Decrypt` applies an AES-based transformation to
  movie IDs used in query-string navigation. This is obfuscation, not an
  authorization boundary.

### User-facing page code-behind

| Page/class | Primary capability |
|---|---|
| `HomePage.aspx.cs` / `WebForm1` | Home/landing navigation and movie entry point. |
| `abt.aspx.cs` / `abt` | About page and shared navigation/session state. |
| `Contact.aspx.cs` / `Contact` | Contact information/navigation. |
| `LoginPage.aspx.cs` / `logorsingup` | Login and account navigation. |
| `registration.aspx.cs` / `registration` | New user registration. |
| `forgotpass.aspx.cs` / `forgotpass` | Password-recovery UI flow. |
| `profile.aspx.cs` / `profile` | User profile display/update. |
| `feedback.aspx.cs` / `feedback` | Feedback submission. |
| `MovieDetails.aspx.cs` / `MovieDetails` | Movie details and booking entry point. |
| `movielist.aspx.cs` / `movielist` | Movie listing/search/display. |
| `moviereop.aspx.cs` / `moviereop` | Movie reporting/administrative movie view. |
| `booked.aspx.cs` / `booked` | Booking/payment completion or booked-ticket view. |
| `bookhistory.aspx.cs` / `bookhistory` | User booking history. |

The corresponding `.designer.cs` files are generated partial definitions for
Web Forms controls, not independent business components. The page classes mix
event handling, navigation, session state, validation, and (in several pages)
direct SQL.

### Administration page code-behind

| Page/class | Primary capability |
|---|---|
| `adminpage.aspx.cs` / `adminpage` | Admin dashboard/counts. |
| `adminmovie.aspx.cs` / `adminmovie` | Admin movie navigation. |
| `adminmovies.aspx.cs` / `adminmovies` | Admin movie listing. |
| `addmovie.aspx.cs` / `addmovie` | Movie/image/seat/showtime insertion. |
| `adminuserview.aspx.cs` / `adminuserview` | Admin user view. |
| `admincomplaints.aspx.cs` / `admincomplaints` | Admin complaint/feedback view. |

`addmovie.aspx.cs` is especially important: it opens SQL connections, checks
movie names, uploads images, inserts movie data, and creates seat-status rows.
This is a vertical slice that should become a transactionally tested catalog +
scheduling use case.

### Placeholder/generated pages

`WebForm2.aspx.cs`, `WebForm3.aspx.cs`, and `WebForm4.aspx.cs` are Web Forms
classes with generated designer counterparts. Their exact business meaning is
not reliable from names alone and is an **Open** mapping task; inspect their
markup and reachable links before retiring them.

## Runtime behavior

1. `HomePage.aspx` loads movies through
   `MovieDetailsDataAccess.GetMovieDataList()`. Its repeater builds cards and
   navigates to `MovieDetails.aspx?MovieDetails=<encrypted-id>`.
2. Registration validates form fields, calls
   `RegistrationService.asmx/UserNameExists` through jQuery, then calls
   `RegisterDataAccess.RegisterNewUserAccount`. Duplicate username, email, and
   phone are rejected by the stored procedure.
3. Login hashes the submitted password with the legacy SHA-256/Base64 helper,
   calls `LoginDataAccess`, sets `Session["user"]`, and redirects admins to
   `adminpage.aspx` and other users to `HomePage.aspx`.
4. `MovieDetails.aspx` decrypts the movie query parameter, loads movie and seat
   data, renders 30 individual seat handlers (`s1_Click` through `s30_Click`),
   and uses Session/ViewState values for date, time, movie, payment, and
   selection state.
5. All page lifecycle events use `Session["user"]`, `Session["page"]`, and
   `Session["pay"]` for authentication/navigation state, and pages navigate by
   `Response.Redirect`, so URLs and state transitions are
   coupled to physical `.aspx` filenames.
6. Login/registration and movie details use data-access helpers in some paths,
   while administrative and booking pages issue SQL directly in code-behind.
7. Images are stored or handled as binary data in the database in the documented
   schema; the page layer also serves static image assets.
8. The registration SOAP endpoint is a separate integration surface that must
   be inventoried before removal.

## Key risks and modernization findings

- Direct string concatenation appears in page-level SQL, creating injection
  risk and making query behavior difficult to test.
- Authentication is represented by session values and database password
  comparisons rather than a modern identity boundary. SHA-256 without a salt or
  work factor is not an acceptable password-storage strategy for the new system.
- Admin authorization is primarily represented by a database flag and redirects;
  every target admin action requires explicit authorization policy checks.
- Seat state is encoded as many columns (`s1` through `s30`) and is updated by
  page code, which makes concurrency and invariants difficult to enforce.
- The ASMX username-availability endpoint is a separate compatibility surface
  and must be replaced by a versioned MVC/API endpoint or removed after the
  registration flow is migrated.
- Database names and contracts are inconsistent between the supplied SQL script
  and older page queries; see `schema-reconciliation.md`.
- Generated designer files and old client libraries should not be migrated as
  application architecture.
