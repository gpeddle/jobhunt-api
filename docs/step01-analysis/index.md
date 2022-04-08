# Step 1 - Analysis

## Overview

This section reviews the [API Code Assignment](/docs/api-code-assignment.md)  and collects decisions and assumptions made for the project. [Original PDF here](/docs/API-Code-Assignment.pdf)

## Assumptions

1. There is no UI, and the API is tested manually. 
   - *For our purpose, the request/response of the API is the only UI.* 
2. There is no separate database.
   - *A real system would persist data and do additional processing. This example is limited to  receiving and validating incoming records for accept/reject status.*
3. A series of test questions and answers must be created.
   - *A real system would require a full life-cycle for Questions. This example is limited to a single, static question set for use in validation.*



## Ubiquitous Language

- **JobApplication** - the submitted JSON data with answers to **Questions**
- **Question** - a request for information which has a pre-defined set of acceptable answers.
- **Applicant** - the person applying for a job.
- **Employer** - the business entity which considers **JobApplications** 
- **Validation** - a review of **JobApplication** data to determine if the answers provided are all within the acceptable values for the **Questions** posed. 


## Domain Description

1. A **JobApplication** is a JSON document as described in the assignment.
3. Upon submission, each **JobApplication** is validated against the questions.
4. A **JobApplication** which passes validation is *Accepted*, with a JSON response.
5. Each *Accepted* **JobApplication** is persisted for additional processing.
6. All *Accepted* **JobApplications** will later be consumed by a downstream processing system.
7. A **JobApplication** which fails validation is *Rejected*, with a JSON response.
8. Each *Rejected* **JobApplication** is discarded.

## Bounded Context

The API will handle only the receipt of **JobApplication** JSON data and immediately respond with accept/reject status.
The **Questions** are a separate authority that is available as a service. 

## Technical Decisions

- Implement an API only service using .NET 6.0 webapi template
- Use Swagger to test the behavior of the API
- During testing, store submitted data in memory
- Stopping the API service loses all submitted data
