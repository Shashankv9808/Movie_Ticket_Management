# Migration principles

1. Treat the legacy application as a behavior reference, not as a schema or
   security reference.
2. Establish a runnable baseline and characterization tests before changing
   booking, authentication, or seat behavior.
3. Migrate by vertical slices: catalog, identity, scheduling, booking, payment,
   then administration and feedback.
4. Keep old and new systems comparable during transition with explicit
   acceptance scenarios and reconciled data counts.
5. Prefer EF Core migrations for the new model, while using a controlled
   import process for legacy data. Do not let EF infer destructive changes from
   the legacy database.
6. Make every unresolved legacy assumption visible as a decision or a
   verification task in the knowledge base.
