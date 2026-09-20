# Architecture documentation

This folder contains the intended architecture for the modernized Movie Ticket
Management application. It is deliberately separate from the application
projects so that design decisions can be reviewed before implementation.

## Documents

- `target-architecture.md` - proposed ASP.NET Core 8 MVC and EF Core shape.
- `migration-principles.md` - constraints and decisions to preserve during the
  strangler-style migration.

The evidence about the legacy application is in `Knowledge Base/`. Migration
execution steps are in `Instructions/migration-execution-plan.md`.
