# Step 2 - Setup

Setup the API project and associated testing, along with necessary libraries.

## Prerequisites

- .NET 6 SDK
- Docker
- Visual Studio Code 
- Docker extension for VS Code
- Amazon AWS account at Free Tier

> *NOTE: This assignment is developed using Ubuntu 20.04. 
> Other Operating Systems will require adjusting these steps.*

## Create project and tests

```
mkdir src && cd src
dotnet new sln -o . -n JobHunt.Api
dotnet new webapi -o JobHunt.Api
dotnet new xunit -o JobHunt.Api.Tests
dotnet sln add **/*.csproj
dotnet restore
dotnet build
```
Confirm that no errors are displayed.

## Run the generated project

1. Start the service by:
   - `cd src/JobHunt.Api`
   - `dotnet run --urls=http://localhost:7777`
2. View the API using swagger by opening a browser to http://localhost:7777/swagger/index.html


## Add Testing Support

```
dotnet add JobHunt.Api.Tests/JobHunt.Api.Tests.csproj package Microsoft.AspNetCode.Mvc
dotnet add JobHunt.Api.Tests/JobHunt.Api.Tests.csproj package FluentAssertions
dotnet add JobHunt.Api.Tests/JobHunt.Api.Tests.csproj package Moq
dotnet restore
dotnet build
dotnet test
```


## Setup Docker files

1. Using VSCode, open the Command Palette (`Ctrl+Shift+P`)
2. Choose **Docker: Add Docker Files to Workspace** and follow the prompts:
   - Platform: *.NET: ASP.NET Core*
   - Project: `src/JobHunt.Api/JObHunt.Api.csproj`
   - Operating System: *Linux*
   - Port: *7777*
3. Inspect the new `Dockerfile` and `.dockerignore` files



## Build Docker Image

1. Using VSCode, open the Command Palette (`Ctrl+Shift+P`)
2. Choose **Docker Images: Build Image**
3. Open Docker Explorer and verifuy the new image (`jobhuntapi`) is visible

## Test Docker Image

1. In Docker Explorer.. Images, Right-click on `jobhuntapi` image and choose **Run**
2. Observe that the running container is displayed
3. Optional: Try out swagger with the default WeatherForecast app by visiting http://localhost:7777/swagger
4. In Docker Explorer.. Containers, Right-click on `jobhuntapi` and choose **Stop**

