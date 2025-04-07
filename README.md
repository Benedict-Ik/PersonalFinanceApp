# Personal Finance App

Here is what we did in this branch:

- We added functionalities to **update** and **delete** expenses by defining them in the interface class and implementing them in the service class afterwards.
- We injected the newly added services in our controller class to implement functionalities and routes for `Edit`, `Update`, and `Delete`.
- Added a bootstrap icon stylesheet to the _Layout file to make use of specific icons.
- Updated `Index.cshtml` table to include the action icons with a confirmation popup on delete.
- Added a new view - `Edit.cshtml` - to edit the expense.
    - Model Binding: The view starts with @model Expenses, meaning it expects an instance of your Expenses model to populate the form.
    - Hidden ID Field: A hidden input for the Id ensures that the expense identifier is sent back when the form is posted.
    - Form Controls: Each field (Description, Amount, Category, Date) is rendered using the asp-for tag helper, which binds the control to the corresponding property on the model. This way, the existing values are automatically populated.
    - Validation: \<span asp-validation-for="..."> displays any validation errors. The validation scripts are included at the bottom via _ValidationScriptsPartial.
    - Buttons: The form includes a "Save Changes" submit button and a "Cancel" link that routes back to the Index action.
- Wrapped the delete icon in a small inline form so that clicking delete posts to the Delete action after confirmation.
- Modified the `UpdateExpenseAsync` service method.
- Added error handling in the controller class.