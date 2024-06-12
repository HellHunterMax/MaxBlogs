# Application layer
This together with the domain layer is called the application core.

## Responsebilities
- Fetch the domain objects
- Manipulating the entities

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