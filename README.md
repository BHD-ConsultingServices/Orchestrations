## What is included? ##
* __BL Contract Layer__ (Orchestrations)
    * Sample orchestration DTO's, nested for maximum reuse with declaritive structure
    * Constructor dependency injection (Adapters) for easy DAL configuration and DAL Mocking
    * Automapper DTO's between DAL and orchastraters reducing maintenance effort
    * Orchestration Logic/Worker design to ensure Worker SRP, Logic Readability, low cyclic complexity and worker unit test code isolation
* __DAL Contract Layer__ (Adapers)
    * Adapers expose DAL logic using Orchestration DTO's so no technology specific dependencies required i.e. ORM entities andinner workings do not bleed into Orchestrations

## Important Constructs to Grasp ##
* __Builders__ - Fluent test data generators, re-usable, readable and adjustable to different scenarios
* __Query Objects__ - Fluent builders, easy modular design with centralized paging and filter blocks
* __Mappers__ - Extention methods that maps between Orchestration and Adapter DTO's (Use Automapper for straight forward maps)
* __Aspect Oriented Programming__ - 
* __ObjectMother__ - A test data class that reflects the database state with a matching POCO graph
* __Mocking / Stubbing__ - Replacing actual logic with simple echo back responses to simulate testing against a contract

* Contract Layers (Using domain specific interfaces easily configurable through DI)
  These contract layers inforces high cohesion loose coupling. Ensuring SOC between tiers and easy mocking/stubbing.
    * __Orchestrations__ (BL Contracts)
_A contract layer that expose all the business logic by grouping them by domains. These domains are called orchastraters and defined by normal interfaces easily readable by businesses people. It is a easy starting point to create the interfaces and write their TDD test cases._
    * __Adapters__ (DAL Contracts)
        * Database Adapters - Adapters that adapt out to database (Entity Framework Code First)
        * External Adapters - Adapters that adapt out to 3rd party systems

* __Testing__
    * __Integration Tests__ - (Acceptance test cases) High level orchastration tests with a narrow vertical end to end test cases to test how all the different layers fit together
    * __Mocked Tests__ - (Most BL coverage) Orchastration tests that mocks internal adapters so that only orchatration logic is tested
    * __Rollback Tests__ - (Health Checks) Adapter tests that runs testing in transaction and rolls it back after assertions
    * __Test Data__ - (Local testing & CI) Using the Object Mother the test database can be cleared and populated

## Adventagous ##
* Cross Cutting Concerns
    * Instrumentation (External Repository) for logging and Monitoring
    * Originating Identity (Service/user) with .NET Membership and originating user identifier required on all orchestration calls
    * Audit: Low Adapter level TT expansion of marked entities to add audit events for add, edit, delete

