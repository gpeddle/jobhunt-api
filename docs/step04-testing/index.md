# Step 4 - Testing

Perform testing with the Swagger API UI.

1. Start the project locally with `dotnet run`

## View Applications


At any point, you can view the list of *Accepted* JobApplications by:

- Expand the Get `/api/JObApplication` section
- Click **Try it out**
- Click **Execute**

Observe the list of records in the database.


## Test Submission #1 - Valid Data

Expand the Post `/api/JobApplication` section, and submit the following JSON:

```JSON
{
  "name": "Job Seeker 1, No Felony, can work",
  "answers": [
    {
      "questionId": "id1",
      "answer": "No"
    },
    {
      "questionId": "id2",
      "answer": "Yes"
    }
  ]
}
```

Observe that:
  - HTTP response code is 200 
  - Response body contains the new GUID value for the created record.

## Test Submission #2 - Invalid Data

Expand the Post `/api/JobApplication` section, and submit the following JSON:

```JSON
{
  "name": "Job Seeker 2, Felony, cannot work",
  "answers": [
    {
      "questionId": "id1",
      "answer": "Yes"
    },
    {
      "questionId": "id2",
      "answer": "No"
    }
  ]
}
```

Observe that:
  - HTTP response code is 400 
  - Response body contains *"All answers must be valid"*.

## Test Submission #3 - Valid Data

Expand the Post `/api/JobApplication` section, and submit the following JSON:

```JSON
{
  "name": "Job Seeker 3, No Felony, can work, has drivers license, will work weekends, can lift 40, is adult",
  "answers": [
    {
      "questionId": "id1",
      "answer": "No"
    },
    {
      "questionId": "id2",
      "answer": "Yes"
    },
    {
      "questionId": "id3",
      "answer": "Yes"
    },
    {
      "questionId": "id4",
      "answer": "Yes"
    },{
      "questionId": "id5",
      "answer": "Yes"
    },
    {
      "questionId": "id6",
      "answer": "Yes"
    }
  ]
}
```
Observe that:
  - HTTP response code is 200 
  - Response body contains the new GUID value for the created record.


## Test Submission #4 - Unknown Question Id

Expand the Post `/api/JobApplication` section, and submit the following JSON:
```JSON
{
  "name": "Job Seeker 4, Unknown Question",
  "answers": [
    {
      "questionId": "qqq",
      "answer": "Yes"
    }
  ]
}
```

Observe that:
  - HTTP response code is 400 
  - Response body contains *"All answers must be valid"*.

