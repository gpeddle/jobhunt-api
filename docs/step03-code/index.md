# Step 3 - Code

Establish the project structure, with skeleton testing in place.

## Overview

This implementation uses the *Controller-Service-Repository* pattern, which allows respects SOLID principles and enhances the ability to test individual classes. There is some overkill in structuring a trivial API this way, but APIs begin small and later grow, so let's respect first principles. 

Note that the repository here is EF DbContext, which is completely sufficient for our purposes.

## JobHunt.Api structure

This project is the entry point for the API and contains all code needed to deploy the solution.

1. Remove or rename the controller class to `JobHuntApiController`
2. Create project sub-folders for 'Models', 'Services' and 'Data'
3. Add Model class files for **JobApplication** and **Question** entities
4. Add Service class files for **JobApplicationService** and **QuestionService**
5. Add Data class file for **JobApplicationsDbContext**
5. Initialize the services in `Program.cs` by creating a *ConfigureServices()* method.
6. Throw *NotImplementedException* from service methods 

## JobHunt.Api.Tests structure

This project contain tests for the API, using a TDD approach. 

As we work through coding below, we need to: 

    - Create *Happy Path* tests for controller and service methods
    - Create *Failure* tests for controller and service methods
    

## Run Tests and see failures for initial structure

At this point, we don't have any code implemented, so the tests fail, as expected.

## Implement QuestionService and tests

We choose to implement QuestionService as a combination service and repository using a static list to keep things simple. For a tiny set of data, Linq queries are sufficently performant. A production implementation would be backed by a real Question repository.

The QuestionService requires little testing because it is trivial. Basic tests to confirm the presence or absence of data are enough.

## Implement DatabaseContext and tests

This is implemented using an EntityFramework in-memory store.

1. Add EF libraries: 
   - `cd src/JobHunt.Api`
   - `dotnet add JobHunt.Api.csproj package  Microsoft.EntityFrameworkCore`
   - `dotnet add JobHunt.Api.csproj package  Microsoft.EntityFrameworkCore.InMemory`

2. Add `Data/DatabaseContext.cs` with a DbContext subclass that exposes a DbSet of **JobApplications**.

3. In `Program.cs`, add code to *ConfigureServices()* thto initialze the in-memory store. 

## Implement JobApplicationService and Tests

The **JobApplicationService** is responsible for checking the validity of the supplied JSON answer data. It has two dependencies, both injected in the constructor:
    - **QuestionService**
    - **JobApplication**

1. In `TestJobApplicationService.cs`, create a shared *GetDatabaseContext()* method to eliminate boilerplate in test cases.
