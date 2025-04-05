# Personal Finance App

Here is what we did in this branch:

- Added a new controller `ExpensesController`.
- The newly added controller comes with a default action method `index`.
- Created a constructor that can be used to inject the DbContext.
- Added a new folder, `Expenses`, to the `Views` folder.
- Within the `Expenses` folder, created a new view named `Index.cshtml`.
- Modified the `Index` action method to retrieve a list of expenses from the database.
- Modified the `Index.cshtml` view (in the Expenses folder) to display a list of expenses.
- Modified the `_Layout.cshtml` in the Shared folder to include a link to the Expenses page.
- Added a new action method in the Expenses' Controller called `Create()` that helps redirect the user to the `Create.cshtml` page.
- Just like we did for the Index.cshtml page, we will create a new view called `Create.cshtml` in the `Expenses` folder.
- Modified the `Index.cshtml` view (in the Expenses folder) by including a button that can route clients to the `Create.cshtml` page..