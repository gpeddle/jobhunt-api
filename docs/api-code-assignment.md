# API Code Assigmnent


Being able to automatically filter out applications from unqualified applicants can save busy hiring managers a lot of time. They only need to spend time looking at applicants who meet their minimum qualifications. Why waste time reading through delivery driver applications from people who don’t have a vehicle if you require drivers to use their own vehicle?

Implement code that determines whether a job application meets a set of minimum qualifications. The job application will be a list of questions, each of which has a question id and an answer. The qualifications will be a list of question ids, each associated with a list of acceptable answers. If an application fails to answer any one of these questions with an acceptable answer, the application should be rejected. Otherwise the application should be accepted. The employer should be able to view only the accepted applications.

Implement a solution that:

- Contains a list of Questions with an acceptable answer for each question:
  - `[ { Id: "id1", Question: "string", "Answer": "string" }, { Id: "id2", Question: "string", "Answer": "string" }, … ]`

- Receives job applications where each application is a JSON document conforming to this design:
  - `{ Name: "string", Questions: [ { Id: "id10", Answer: "string" }, { Id: "id20", Answer: "string" }, … ] }`

- The program should decide to accept or reject each application.
- Accepted applications must answer all questions correctly.
- Accepted applications must be shown to the employer.
- Unaccepted applications must not be shown to the employer.

As with any project, there are some missing requirements or specifications:

- The product owner does not know what the questions or answers are at this time.
-  There is no UI designer.
-  There is no database designer.

You may implement this code in the language of your choice. It should be code that actually runs, not pseudocode. You may choose any mechanism for storing accepted applications. You are welcome to use the standard tools you would use in developing code - language references, stack overflow, books, etc. These tools should be used to answer specific implementation details (for example, *“how do I save a file to disk in python?”*). They should not be used to find complete answers to similar programming problems.

Please upload your source code somewhere publicly accessible, such as a github repository, and email a link to api-dev-interviews@snagajob.com by 4pm the day before your interview. During your interview, we will want to see the code run. You should create a machine in the cloud that can run your code. Make sure the cloud machine is publically accessible and contact us so we can at least get a login prior to your interview day.
