# Step 3 - Code

Establish the project structure, with skeleton testing in place.

## JobHunt.Api structure

This project is the entry point for the API and contains all code needed to deploy the solution.

1. Create project folders for 'Models' and 'Services'
2. Add model class files for **JobApplication** and **Question** entities
3. Add service class files for **JobApplicationService** and **QuestionService**
4. Initialize the services in `Program.cs` by creating a *ConfigureServices()* method.
5. Throw *NotImplementedException* from service methods 

## JobHunt.Api.Tests structure

This project contain tests for the API, using a TDD approach. 

1. Create *Happy Path* tests for api methods
2. Create *Failure* tests for api methods

## Run Tests and see failures for initial structure

At this point, we don't have any code implemented, so the tests fail, as expected

## Implement QuestionService and tests

We choose to implement QuestionService as a static list to keep things simple. In a tiny set of data, Linq queries are sufficently performant. A better implementation would use an real Question repository.

The QuestionService requires little testing because it is trivial. Basic tests that confirm the presence or absence of data are enough.

