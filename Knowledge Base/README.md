# Knowledge base

This folder records facts discovered from the legacy source and SQL artifacts.
Statements are marked as:

- **Confirmed** - directly observed in source or `Database_Query.sql`.
- **Inferred** - a reasonable runtime relationship that needs validation.
- **Open** - must be answered before production migration.

Documents:

- `legacy-high-level-design.md` - class/file inventory and runtime behavior.
- `legacy-dependency-graph.md` - code, data, and request-flow dependencies.
- `schema-reconciliation.md` - conflicting database contracts to resolve.

The source paths in these documents are relative to the repository root.
