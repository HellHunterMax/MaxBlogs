# MaxBlogs
In this project I will try out different stuff to learn from.
This project can be used as reference for myself.

## techniques and Tech
- [x] SOLID ✅
- [x] Clean Architecture ✅
- [ ] Test Driven Development ❌
- [ ] Domain Driven Design 
- [ ] Modular Monolith ❌
- [ ] Logging ❌
- [ ] GraphQl ❌
- [ ] Blazor ❌
- [ ] Indentity management ❌
- [ ] Event driven ❌
- [X] Entity Framework ✅
- [ ] ...

## How to
When learning from this project you can use the README files in each section to see what the section is about.
In the README you will also find the reasoning behind certain decisions or alternatives. 
There should be instructions for running each Presentation layer.

# Validation
## Validation Types
- Model validation
    - this validation sits in the presentation layer/Application layer
    - text can only be x long
    - age must always be over 0 and under 150 (normal rules for age)
- Business Validation
    - this validation sits in the Domain layer.
    - Rules that are difined by the business
    - age > 18 (business rule)

## Validation Principles
- Fail Fast and Hard!

## possibilities
1. Split double validation
    - Model validation gives a human readable result (error)
    - Business Validation Gives an exception
1. Domain Value object Vallidation
    - All hard rules are defined in the domain object and this is created and validated and always valid.
    - using value objects inside domain to make sure it cannot be false.

