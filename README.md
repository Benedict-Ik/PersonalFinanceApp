# Personal Finance App

Here is what we did in this branch:

- Here we made the Index and Create action methods asynchronous.
- This is to improve the performance of the application by allowing multiple requests to be processed simultaneously.
- Leaving it as it is would imply that the application may be stuck (blocking) while waiting for the database to respond, which can lead to poor performance and a bad user experience.
- In general, asynchronous codes are used in operations or tasks that may take a lot of time to complete, such as:
  - I/O operations (e.g., reading/writing files, making network requests such as API calls)
  - Database queries
  - Long-running computations etc.