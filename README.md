# Orchestrations
Sample Orchestration Implementation

## What is an Orchestration / Provider Implementation? ##
A contract layer that expose all the business logic by grouping them by domains. These domains are called orchastraters and defined by normal interfaces easily readable by businesses people. It is a easy starting point to create the interfaces and write their TDD test cases.

## What is included? ##
* Orchestrations
    * Sample orchestration DTO's, nested for maximum reuse and declaritive structure
    * Constructor dependency injection (Adapters) for easy DAL configuration and DAL Mocking
    * Automapper DTO's between DAL and orchastraters reducing maintenance effort
    * Orchestration Logic/Worker design to ensure Worker SRP, Logic Readability, low cyclic complexity and worker unit test code isolation
* DAL Contracting (Adapers)
    * Adapers expose DAL logic using Orchestration DTO's so no technology specific dependencies required i.e. ORM entities andinner workings do not bleed into Orchestrations
* Unit testing
    * Test Data generation (Builders & Object Mother)
    * Easy stubbing (Test data DI) during staggered development through layers
    * Easy Adaper Mocking (RhinoMocks) by stubbing and injecting Adapers before running orchestration

## Adventagous ##
* Cross Cutting Concerns
    * Instrumentation (External Repository) for logging and Monitoring
    * Originating Identity (Service/user) with .NET Membership and originating user identifier required on all orchestration calls
    * Audit: Low Adapter level TT expansion of marked entities to add audit events for add, edit, delete

