# Infrastructure
This is your gateway to external stuff fe: Database, external Api's...

## Responsebilities
- Interacting with Persistence
- interacting with other services
- interacting with system (Time, Files....)
- Identity concerns?


## Facts
- Infrastructure points inwards.
- There can be multiple infrastructure projects Each for their own connection.


# Databases
When using entityFramework, you can use the IEntityTypeConfiguration and OnModelCreation (inside the context) To change what is saved to the database.