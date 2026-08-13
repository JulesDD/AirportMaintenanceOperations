Sprint 8

Sprint Goal

Finish the remaining Sprint 7 work, harden the existing application, then begin Inventory.

After completing Sprint 7 and testing every API endpoint, we uncovered several areas that should be finished before expanding the system.

Sprint 8 will therefore begin with Sprint 7 leftovers and cleanup, followed by testing/hardening, and then move into the Inventory work.

Phase 1 — Sprint 7 Leftovers

1. Work Order PATCH / Update

This is the first functional item to complete.

Create UpdateWorkOrderCommand

Define which Work Order properties can be updated

Create validation

Create handler

Apply updates through domain behavior

Add the Work Order PATCH endpoint

Test successful updates

Test invalid updates

Test missing Work Orders

2. Review Work Order Lifecycle

Review the current Work Order status model and make sure the allowed transitions are intentional.

Review WorkOrderStatus

Review existing Work Order domain methods

Define valid transitions

Prevent invalid transitions

Confirm documentation requirements for status changes

Confirm completion requirements

Test valid transitions

Test invalid transitions

Important: Do not create additional lifecycle commands simply for completeness. Add them when the application workflow actually requires them.

3. Review Maintenance Request Lifecycle

Sprint 7 added the ability to move a Maintenance Request from Open to InProgress.

Review StartMaintenanceCommand

Review the POST /api/maintenance/{id}/start endpoint

Ensure Open -> InProgress is the intended transition

Remove duplicate lifecycle methods if any remain

Review other Maintenance Request transitions

Prevent invalid transitions where appropriate

The current intended workflow is:

Open
  ↓
Start
  ↓
InProgress
  ↓
Create Work Order

4. Work Order Documentation

Sprint 7 established that LaborNotes is required by the database.

Confirm Work Order creation supplies required notes

Confirm status changes document the relevant work

Review whether LaborNotes should eventually be renamed to WorkOrderNotes

Defer broader MaintenanceNotes design until the notes model is intentionally planned

Phase 2 — Database and Code Cleanup

5. Review Sprint 7 Migration Changes

Sprint 7 included a migration with several changes beyond the employment-status work.

Review:

MaintenanceRequests.RequestNumber uniqueness

RequestNumber column length

Users.Status / EmploymentStatus mapping

Work Order Title

Work Order Description

Current migration snapshot

Future migrations should follow:

Create migration
      ↓
Review generated changes
      ↓
Confirm only intended changes are included
      ↓
Apply migration
      ↓
Test

6. Code Cleanup

Remove unused methods

Remove duplicate domain methods

Remove obsolete status enums

Remove unused configuration

Review nullable reference warnings

Review TODOs

Review dead code

Run a full solution build

Keep cleanup targeted. Avoid a broad refactor before the functional work is stable.

Phase 3 — Testing and Hardening

7. Automated Testing

Sprint 7 relied heavily on manual API testing. Sprint 8 should begin turning the important discoveries into automated tests.

Domain Tests

Maintenance Request Open -> InProgress

Invalid Maintenance Request transitions

Work Order lifecycle transitions

Invalid Work Order transitions

Required Work Order notes

Employment Status behavior

Handler Tests

Create Work Order

Update Work Order

Start Maintenance Request

Not-found scenarios

Invalid lifecycle scenarios

API / Integration Tests

Create Maintenance Request

Start Maintenance Request

Create Work Order

Update Work Order

Get Maintenance Requests

Get Technicians

Get Work Orders

8. Number Generator Hardening

Sprint 7 deliberately simplified the number generator rather than retaining incomplete retry logic.

Sprint 8 should revisit concurrency properly.

Review INumberGenerator

Review counter persistence

Determine the concurrency strategy

Test concurrent number generation

Ensure duplicate numbers cannot be generated

Keep the implementation simple and explicit

Do not reintroduce retry/detach logic without a defined concurrency strategy.

Phase 4 — Inventory

Inventory begins after the most important Sprint 7 leftovers are under control.

Before writing entities or endpoints:

Review the Inventory requirements/specification

Define the Inventory domain model

Identify inventory types/categories

Identify quantity and availability requirements

Identify locations/storage requirements

Identify reorder/stock requirements if applicable

Identify relationships with Aircraft, Maintenance Requests, Work Orders, and Technicians

Define Inventory status concepts

Decide which concepts belong in the Domain layer

Define the first Inventory use cases

Inventory Implementation Order

Requirements
    ↓
Domain Model
    ↓
Entities / Value Objects / Enums
    ↓
EF Core Configuration
    ↓
Commands / Queries
    ↓
Handlers / Validation
    ↓
API Endpoints
    ↓
Testing

Do not invent Inventory requirements before reviewing the project's existing Inventory notes/specification.

Sprint 8 Priorities

Priority 1 — Finish Sprint 7 leftovers

Work Order PATCH

Work Order lifecycle review

Maintenance Request lifecycle cleanup

Work Order documentation review

Priority 2 — Harden the existing system

Migration/database cleanup

Code cleanup

Automated tests

Number-generator concurrency

Priority 3 — Begin Inventory

Inventory requirements

Inventory domain model

First Inventory use cases

Inventory implementation

Sprint 8 Definition of Done

Sprint 8 should be considered complete when:

Work Order PATCH is implemented and tested

Work Order lifecycle rules are explicit

Maintenance Request lifecycle is clean and intentional

Work Order documentation rules are enforced

Sprint 7 migration/database cleanup is addressed

Core automated tests exist

Number generation has a defined concurrency strategy

Inventory requirements are documented

Inventory domain model is established

Initial Inventory use cases are implemented and tested

Full solution builds successfully

Tests pass

README is updated

Sprint 8 retrospective is completed

Sprint 8 Guiding Principle

Finish, harden, then expand.

Sprint 7 proved that end-to-end testing exposes important domain gaps. Sprint 8 should use those lessons to stabilize the existing system before expanding into Inventory.

The goal is not to make Sprint 8 another massive sprint.

The order is:

Sprint 7 leftovers
        ↓
Cleanup
        ↓
Testing / Hardening
        ↓
Inventory