# Domain Layer
Start building from domain.
## Responsibilities
- Defining Domain Models
- Defining Domain Errors (Application Specific)
- Executing business logic
- Enforcing business rules



# Domain-Driven Design

## domain model
- A domain model holds both Data and behavior

### Rich Domain modal
- They contain the data and the behavior

- make as private as possible
- expose only when needed
- expose only what's needed

### Anemic Domain modal
- expose their data so external services can manipulate the data.
- Antipattern.

## Error handling
- invariants. Object validation errors. DDD Business rules (user can only have 1 of something depending on state of the user)
- Has a set of defined Errors that can be referenced so the layers that use this layer know what to expect.

# Domain Events pattern
"Something interesting, form a business point of view, that **happend** within the system."

when you delete a user and it happend you raise an event UserDeletedEvent.
Then some way you can create listeners to this event
- hangfire
- servicebus
- MediatR
- ...

## What is an Entity
"An entity has a Identity (Id)"

Two Entities with the same Id IS the same Entity even if the other data is different

## Aggregates
"One or more Domain Objects that always need to stay consisten as a whole"

### Aggregate root
Every aggregate holds a Aggregate root which is the Root of the Aggregate

### Common Entity
A Entity that is shared over multiple Aggregates ia a Common Entity


## Domain Services
"Domain Services hold Logic that does not fit within 1 single Aggregate"

sidenot: sometimes seen as a flaw in the domain design.
Maybe you need a new aggregate to encapsulate the logic or requirement.
