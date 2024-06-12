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

### Persistence ignorance

## Error handling
- invariants. Object validation errors. DDD Business rules (user can only have 1 of something depending on state of the user)
- Has a set of defined Errors that can be referenced so the layers that use this layer know what to expect.
