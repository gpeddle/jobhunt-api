# Step 1 - Analysis

## Overview

This section reviews the [API Code Assignment](/docs/api-code-assignment.md) and collects decisions and assumptions made for the project. [Original PDF here](/docs/API-Code-Assignment.pdf)

## Assumptions

1. There is no UI, and the API is tested manually. 
   - For our purpose, the request/response of the API is the only UI.
2. There is no separate database.
   - A real system would persist data and do additional processing. 
   - This example is limited to receiving and validating incoming records for accept/reject status.
3. A series of test questions and answers must be created.
   - A real system would require a full life-cycle for Questions. 
   - This example is limited to a single, static set of questions for use in validation.

## Bounded Context

- The API is focused upon receipt of **JobApplication** JSON data and immediate response with accept/reject status.
- The **Questions** are from a separate authority, available as a service. 

## Ubiquitous Language

- **JobApplication** - the submitted JSON data that contains answers to **Questions**
- **Question** - a request for information which has a pre-defined set of acceptable answers.
- **JobSeeker** - the person applying for a job.
- **Employer** - the business entity which considers **JobApplications** 
- **Validation** - a review of **JobApplication** data to determine if all of the answers provided are acceptable values for the **Questions** posed. 

## Domain Description

1. A **JobApplication** is a JSON document as described in the assignment.
3. Upon submission, each **JobApplication** is validated against the questions.
4. A **JobApplication** which passes validation is *Accepted*, with a JSON response.
5. Each *Accepted* **JobApplication** is persisted for additional processing.
6. All *Accepted* **JobApplications** will later be consumed by a downstream processing system.
7. A **JobApplication** which fails validation is *Rejected*, with a JSON response.
8. Each *Rejected* **JobApplication** is discarded.

## Technical Decisions

- Implement an API only service using .NET 6.0 webapi template
- Use Swagger to test the behavior of the API
- Use TDD approach based on Xunit, Moq and FluentAssertions
- Store persisted data in memory only. 
- Stopping the API service loses all persisted data
- Implement a local **Questions** service that loads from a static JSON file


## Other Notes

- A future implementation could employ a different storage service.
- **Questions** are managed by a different part of the overall system, but there are important concerns about them:
  - Can the text of a question be edited, after the answer is provided? What would this mean?
  - Should questions be expanded to allow True/False, Multiple-choice, or Short-answer?
- The **Question** entity has a mismatch between expected JSON and the more likely field name *Text* - Ie. the entity could have **Question.Text** and **Question.Answer** as more natural field names, avoiding the odd **Question.Question** that the JSON suggests. This example works around the problem by mapping the name during loading.
