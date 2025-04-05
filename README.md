# Personal Finance App

Here is what we did in this branch:

- It is generally considered a bad practice to access the database directly from the controller class.
- A service class is a separate class used to access the database and perform business logic.
- We will create a new folder called `Services` to help store our service classes.
- When defining a service, we first define an `Interface`, which is a contract that the service class must implement, then the actual `Service` class, which serves as the actual implementation of the defined contract.
- By convention, when creating your interfaces, it is best to name each method signatures with the suffix `async`.
- In the main `Service` class, we will inherit from the `Interface` class and implement all the methods defined in the interface.
- Next, in the `Program.cs` file, we will register the service class with the dependency injection container by adding the below line before the `build` method:
```C#
builder.Services.AddScoped<IExpensesService, ExpensesService>();
```
- This will ensure that when the `IExpensesService` is injected into the controller class and requested, the `ExpensesService` functionalities will be provided.
- Finally, we will inject the Iservice class into the controller class constructor and assign it to a private field. This allows us to use the service class methods in our controller methods.
- Summary of code change:
    - Interface (IExpensesService): Declares the contract for expense operations.
    - Service (ExpensesService): Implements the business logic using the DbContext.
    - Controller: Now depends on the service interface and remains lean.
    - DI Registration: Ensures the service is available for injection.