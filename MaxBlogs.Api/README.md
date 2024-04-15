# Presentation layer as WebApi
The presentation layer should translate what it has recieved into a language that the application layer (it is connected to) understands.

## Facts
- Should be facing inwards towards other applications
- Can have a Contracts project which it points to that can be used for outside communication
- Will be the layer which is interacted with


## project References
Only has a reference to Infrastructure to be able to inject tje services.