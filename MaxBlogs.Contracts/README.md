# Contracts
A contracts project is used for applications pointing outside.

# contents
- Requests
- Responses

# project References
This project should have no references.


###  Common
But there is 1 issue with this, when difining an **enum** for example you have 3 choices.
1. Make a copy of the domain **enum** inside the contracts project
   - imo this is prone to errors and incomplete mapping f.e.
1. Make Domain reference the contracts and only have the enum inside the Contract.
   - this way you have access to the **enum** in the project and outside projects.
1. If its an domain **enum** that is used in multiple projects or solutions the **enum** should be placed in a `Common.Domain` project.
   - Then the contracts can reference the `Common.Domain`. 
   though also this should be used with caution and maybe you need a third project called `Common.Domain.Contracts`
