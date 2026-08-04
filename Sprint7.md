# Sprint 7 – Work Order Management

**Project:** Aircraft Maintenance Management System (AMMS)

**Sprint Length:** 2 Weeks

**Sprint Goal**

Implement the complete Work Order lifecycle by allowing Maintenance Requests to become Work Orders, automatically generating sequential identifiers, assigning technicians, tracking progress, and archiving completed work instead of deleting records.

---

# Sprint Objectives

At the end of Sprint 7 users will be able to:

- Generate Work Orders from approved Maintenance Requests
- Automatically generate unique Work Order Numbers
- Automatically generate Maintenance Numbers
- Assign technicians
- Track Work Order status
- Archive completed Work Orders
- Maintain a full audit trail

---

# User Stories

## Story 1
**As a Maintenance Planner**

I want Work Order Numbers to be generated automatically

So that every work order has a unique identifier.

### Acceptance Criteria

- Work Order Number generated automatically
- Cannot be manually edited
- No duplicate numbers
- Numbers continue after server restart

Example

WO-000001

WO-000002

WO-000003

---

## Story 2

**As a Planner**

I want Maintenance Numbers generated automatically

So maintenance activities have their own reference.

Example

MX-000001

MX-000002

MX-000003

---

## Story 3

**As a Planner**

I want to create a Work Order from an approved Maintenance Request

So technicians can begin maintenance.

Acceptance Criteria

- Cannot create Work Order from Cancelled Request
- Cannot create Work Order twice
- Request status changes to

Assigned

---

## Story 4

**As a Planner**

I want to assign technicians

So maintenance responsibility is tracked.

Acceptance Criteria

- Assign one or more technicians
- Assignment date stored
- Assigned By stored
- Technician can view assigned work

---

## Story 5

**As a Technician**

I want to update Work Order status

So everyone knows maintenance progress.

Statuses

- Open
- Assigned
- In Progress
- Waiting Parts
- Inspection
- Completed
- Archived

---

## Story 6

**As an Administrator**

I want completed Work Orders archived

So historical maintenance remains available.

Acceptance Criteria

- No physical deletion
- Archive date stored
- Archived By stored
- Searchable from archive

---

# Database Design

## WorkOrders

| Column | Type |
|---------|------|
| Id | Guid |
| WorkOrderNumber | string |
| MaintenanceNumber | string |
| MaintenanceRequestId | Guid |
| AircraftId | Guid |
| AssignedTechnicianId | Guid |
| Priority | int |
| Status | int |
| ScheduledStart | DateTime |
| ScheduledEnd | DateTime |
| ActualStart | DateTime? |
| ActualEnd | DateTime? |
| Archived | bool |
| ArchivedDate | DateTime? |
| ArchivedBy | string |
| Notes | string |
| Created | DateTime |
| CreatedBy | string |

---

## TechnicianAssignments

| Column | Type |
|---------|------|
| Id | Guid |
| WorkOrderId | Guid |
| TechnicianId | Guid |
| AssignedDate | DateTime |
| AssignedBy | string |

Allows multiple technicians per Work Order.

---

# SQL Sequences

Instead of manually incrementing numbers, SQL Server sequences will generate identifiers.

## Work Order Sequence

```sql
CREATE SEQUENCE WorkOrderSequence
AS INT
START WITH 1
INCREMENT BY 1;
```

## Maintenance Sequence

```sql
CREATE SEQUENCE MaintenanceSequence
AS INT
START WITH 1
INCREMENT BY 1;
```

Example usage

```sql
SELECT NEXT VALUE FOR WorkOrderSequence;
```

returns

```
1
2
3
```

Application formats the number

```
WO-000001
```

---

# Domain Layer

## Entity

```
WorkOrder
```

Properties

- WorkOrderNumber
- MaintenanceNumber
- Status
- Priority
- ScheduledStart
- ScheduledEnd
- ActualStart
- ActualEnd
- Archived
- Notes

Methods

```
AssignTechnician()

Start()

Complete()

Archive()

UpdateStatus()
```

---

# Application Layer

Commands

```
CreateWorkOrderCommand

AssignTechnicianCommand

StartWorkOrderCommand

CompleteWorkOrderCommand

ArchiveWorkOrderCommand

UpdateWorkOrderStatusCommand
```

Queries

```
GetWorkOrderById

GetWorkOrders

GetAssignedWorkOrders

GetArchivedWorkOrders
```

---

# Infrastructure Layer

Repositories

```
IWorkOrderRepository
```

Implementation

```
WorkOrderRepository
```

Responsibilities

- Create
- Update
- Archive
- Search

---

# API Endpoints

## Create Work Order

```
POST

/api/workorders
```

---

## Assign Technician

```
PUT

/api/workorders/{id}/assign
```

---

## Update Status

```
PUT

/api/workorders/{id}/status
```

---

## Complete

```
PUT

/api/workorders/{id}/complete
```

---

## Archive

```
PUT

/api/workorders/{id}/archive
```

---

## Get All

```
GET

/api/workorders
```

---

## Get Archived

```
GET

/api/workorders/archived
```

---

# Blazor Pages

```
Pages/

WorkOrders/

    Index.razor

    Create.razor

    Details.razor

    Edit.razor

    Archive.razor

    AssignTechnician.razor
```

---

# Workflow

```text
Maintenance Request

        │

        ▼

Approved

        │

        ▼

Create Work Order

        │

        ▼

Generate

WO Number

MX Number

        │

        ▼

Assign Technician

        │

        ▼

In Progress

        │

        ▼

Completed

        │

        ▼

Archive
```

---

# Business Rules

✔ Work Orders originate only from approved Maintenance Requests

✔ One Maintenance Request creates one Work Order

✔ Work Order Number cannot change

✔ Maintenance Number cannot change

✔ Completed Work Orders cannot be deleted

✔ Archived Work Orders remain searchable

✔ Every assignment is audited

✔ Status history is preserved

---

# Definition of Done

- SQL sequences implemented
- Automatic Work Order numbering
- Automatic Maintenance numbering
- Work Order entity completed
- Maintenance Request conversion implemented
- Technician assignment working
- Status updates functioning
- Archive functionality implemented
- API endpoints tested
- Blazor UI complete
- Unit tests passing
- Integration tests passing
- Documentation updated

---

# Estimated Story Points

| Story | Points |
|--------|-------:|
| SQL Sequences | 3 |
| Work Order Creation | 5 |
| Maintenance Request Conversion | 5 |
| Technician Assignment | 5 |
| Status Workflow | 3 |
| Archive Functionality | 3 |
| Testing | 5 |

**Total:** **29 Story Points**

---

# Future Enhancements (Sprint 8+)

- Digital technician sign-off
- Labor hour tracking
- Tool and equipment tracking
- Parts consumption from inventory
- Attach maintenance manuals and documents
- Electronic work packages
- Digital inspection checklists
- Supervisor approval workflow
- Aircraft return-to-service certification