# .NET 8 MVC and EF Core migration execution plan

## Outcome

Replace the legacy Web Forms runtime with the `BangloreTalkies` ASP.NET Core 8
MVC application while preserving validated user-facing behavior and creating a
maintainable EF Core/SQL Server boundary.

## Phase 0: baseline and decisions

**Exit gate:** a signed-off behavior baseline and known database contract.

- Inventory all `.aspx` links, forms, postbacks, session keys, SQL statements,
  stored procedures, reports, images, and the SOAP registration endpoint.
- Run the legacy application against a non-production database and capture
  characterization scenarios for registration, login, movie search/details,
  admin movie creation, seat selection, booking, payment result, history,
  feedback, and password recovery.
- Obtain the real schema and reconcile it using
  `Knowledge Base/schema-reconciliation.md`.
- Decide the canonical URL, authentication, payment-provider, timezone, and
  cancellation policies.

## Phase 1: production-grade Core 8 foundation

**Exit gate:** the target builds, starts, and has automated health/configuration
checks.

- Keep the existing MVC/Razor shell and remove sample-data calls only behind
  interfaces.
- Add environment-specific configuration, SQL Server connection health checks,
  structured logging, exception handling, authorization, and secure cookies.
- Add EF Core SQL Server, a `DbContext`, entity configurations, migrations, and
  an initial test database.
- Add unit and integration test projects with a disposable or isolated SQL
  database strategy.

## Phase 2: catalog vertical slice

**Exit gate:** public movie listing and details use EF Core and match the
baseline.

- Implement `Movie`, `Genre`, `Person/Cast`, image metadata, and ratings.
- Add application services and query DTOs for listing, filtering, details, and
  search.
- Migrate `Home`, `Movies`, and movie detail views from `SampleData`.
- Validate result counts, ordering, image behavior, and error/empty states.

## Phase 3: identity and profile

**Exit gate:** users can register, authenticate, recover access, and manage a
  profile without legacy session coupling.

- Map `UserAccount`/`register` data after schema reconciliation.
- Use a modern password hasher and claims/cookie authentication.
- Add role-based admin authorization and antiforgery-protected forms.
- Import users only with a verified password migration strategy; otherwise
  require a controlled reset.
- Migrate profile, feedback, and account-related pages.

## Phase 4: scheduling and seat inventory

**Exit gate:** showtimes and seats are modeled relationally and concurrent
  reservation behavior is tested.

- Replace the 30-column seat representation with `Cinema`, `Screen`,
  `Showtime`, `Seat`, and `SeatReservation` (or a documented equivalent).
- Define unique constraints for showtime/seat and a hold expiry policy.
- Implement transactional seat availability and concurrency handling.
- Migrate admin movie/showtime setup and public showtime selection.

## Phase 5: booking, payment, and history

**Exit gate:** an end-to-end booking is atomic, auditable, and does not store
  prohibited card data.

- Implement booking state transitions and idempotency keys.
- Integrate a PCI-compliant payment provider; store provider tokens/results,
  never raw card number or CVV.
- Add confirmation, cancellation/refund policy, booking history, and receipts.
- Reconcile old booking/payment records with explicit privacy/retention rules.

## Phase 6: administration and remaining surfaces

**Exit gate:** every retained legacy capability has a target route, owner, and
  acceptance test.

- Migrate user/movie/feedback administration with authorization and audit logs.
- Replace reports and dashboard count queries with application queries.
- Decide the fate of About, Contact, placeholder WebForms 2-4, and the SOAP
  registration service.
- Migrate only required static assets; remove obsolete libraries and page files.

## Phase 7: coexistence, cutover, and retirement

- Run the new catalog/read paths against reconciled data while legacy writes
  remain controlled.
- Perform rehearsal imports and compare users, movies, bookings, payments,
  seats, and feedback by stable identifiers and totals.
- Freeze legacy writes, execute final import, verify smoke scenarios, and
  switch traffic.
- Monitor errors, booking failures, payment callbacks, and seat contention.
- Retain a read-only legacy snapshot for the agreed audit period, then retire
  IIS/Web Forms and revoke old credentials.

## Definition of done

- No production request reaches a Web Forms page or legacy direct SQL path.
- EF Core migrations and data import are repeatable and documented.
- Authentication, authorization, booking, payment, and seat concurrency have
  automated coverage.
- Security review confirms no raw credentials, passwords, card numbers, or CVV
  values are introduced into the new application.
- Functional acceptance scenarios pass against the agreed baseline.
