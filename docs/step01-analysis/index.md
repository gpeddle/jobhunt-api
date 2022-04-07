# Step 1 - Analysis

## Overview

This section reviews the [API Code Assignment](/docs/api-code-assignment.md)   and collects decisions and assumptions made for the project. [Original PDF here](/docs/API-Code-Assignment.pdf)

## Assumptions

1. There is no UI, and the API is tested manually. 
2. A series of test questions and answers must be created.
3. All submitted **Applications** are persisted.
4. The persisted **Applications** will later be consumed by a downstream processing system.
5. Because all **Applications** are persisted, the API will only return HTTP level status codes 
4. Each **Application** contains the submitted JSON data and a **ValidationStatus** field which contains *Accepted* or *Rejected* 
5. Downstream processing systems will use the **ValidationStatus** field to determine whether to display an **Application** to the **Employer**

## Decisions

- Implement an API only service using .NET6 webapi template
- Use Swagger to test the behavior of the API
- During local testing, store submitted data in a local output folder
- Once deployed, store submitted data in Amazon AWS S3 bucket
- Provide access to the S3 bucket for inspection by reviewers

## Ubiquitous Language

- **Application** - the submitted JSON data, along with its **ValidationStatus** 
- **Employer** - the business enttity that considerd **Applications** 
- **ValidationStatus** - review of the submitted JSON data to determine if it meets the minimum qualifications. 

