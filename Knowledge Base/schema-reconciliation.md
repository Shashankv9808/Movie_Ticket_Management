# Schema reconciliation register

The repository contains two database contracts. They must not be silently
merged.

## Contract A: `Database_Query.sql` (confirmed documented schema)

It defines `UserAccount`, `Genres`, `Movies`, `MovieCast`, `Feedback`,
`MovieBookedInfo`, `PaymentInfo`, `MovieSeatStatus`, and `ErrorLog`, plus
procedures for account registration/authentication and movie/seat retrieval.

Notable constraints include:

- `Movies` references cast and genre IDs but the script does not declare foreign
  keys.
- `MovieSeatStatus` stores 30 seat values as columns.
- Payment stores card number and CVV, which must not be carried into the new
  design.
- `spGetMovieSeatStatusDetails` selects `SeatStatus`, although that column is
  not declared, and repeats `s1`; this script requires correction before use.

## Contract B: page-level SQL (confirmed source references)

Page code references tables/columns including `register`, `movielist`,
`bookedinfo`, `cardinfo`, and `Seatstatus`, with columns such as `name`, `date`,
and `time`. These names do not match Contract A.

## Required resolution

Before importing data or creating EF migrations:

1. Obtain the actual production/test database schema, including foreign keys,
   indexes, triggers, procedures, and row counts.
2. Map each legacy table and column to a canonical target model.
3. Decide whether Contract A is a newer intended schema, an incomplete script,
   or a separate database version.
4. Produce a repeatable, idempotent import script and validate counts and
   booking/seat invariants.
5. Rotate any exposed/shared credentials and remove raw card/CVV data from the
   migration scope unless a compliant payment provider owns it.
