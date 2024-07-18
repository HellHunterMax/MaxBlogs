# Application layer
This together with the domain layer is called the application core.

## Responsebilities
- Fetch the domain objects
- Manipulating the entities
- Orchestrating the manipulation

## Facts
- should point inwards to the domain layer

## Tips
- Add a Unit of work.
this can be handy for making sure all database transations are completed together. Or non at all.
- Add Repository pattern
because the Application layer does not need to know where the data comes from this could be any source.


## Error handling
- Validation of Domain object (not always sometimes in presentation layer)
- Unauthorized errors
    - user trying to update a object of which it is not the owner.
- pass infrastucture errors back to the presentation layer in a fitting way.
- Be mindfull of called layers and the errors they might throw.
    - might change the error before returning to the presentation layer.

## Repository pattern
a repository pattern is like a wrapper around your database so you can use it like its in memory.

- preferably the repository sits in the application layer
- When you need the repository in the Domain layer it is allowed to be put in the Domain layer.

### Disconnected Domain
This is when you need to update a different aggregate from a aggregate.
So you pass the repository  to the method to update the other aggregate by calling the repository.
This seems like bad practice and should be solved differently

# orchestrating Events in de Application layer
This is one way to handle saving aggregates to the database and making sure its all done in a transaction style.
This way the application layer and the handlers are responsible to make all the database changes needed.

This could be very hard for example when deleting something like a user you need a lot of repositories connected to the handler.
and when you add some other aggregate and forget to add it do the deletion handler it wont get deleted.

## Eventual consistency
With Eventual consistency we only do the main action in the database and the system will then propegate the action to other Aggregates when needed in a seperate flow.
This takes time.