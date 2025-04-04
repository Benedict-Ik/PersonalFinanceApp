# Personal Finance App

Here is what we did in this branch:

- Added a new folder called `Data` which will house our `DbContext` class.
- Created a new class called `FinanceAppDbContext.cs` which will serve as the bridge between our project and the database with the help of a tool called Entity Framework (EF) Core.
- In order to use EF Core, the following packages have to be installed (via the Package Manager Console or by right-clicking on Dependencies > Manage Nuget Packages):
	- Microsoft.EntityFrameworkCore.SqlServer (For SQL Server Databases)
	- Microsoft.EntityFrameworkCore.Tools
	- Microsoft.EntityFrameworkCore.Design (optional)
> If an error in thrown in any installation, ensure the versions installed corresponds with the version of your Dot Net running on your local. You may also need to pay attention to the 'Dependencies' section in each of these packages to ensure all is in order.  

- In the newly created DbContext class, `FinanceAppDbContext`, inherit the base `DbContext` class.
- Add a constructor that takes in `DbContextOptions<FinanceAppDbContext>options` and passes it to the base class.
- Added the DbSet - `Expenses`.
- Once the initial configuaration has been made to the `FinanceAppDbContext` class, we can now create the database and the tables that will be used to store our data.
- On VS Code, click on the 'View' tab > 'Server Explorer' > Right click on 'Data Connections' > Add Connection.
- This should show the below as a dialog box:
 ![File](file.png)
    - Server name: The name of your local SQL Server instance. It is usually displayed as a pop up box for authentication once your SSMS is launched.
	- Encrypt: Optional (False). This would give you access to explore tables in the database.
	- Trust Server Certificate: Tick box (True). 
	- Database name: From the list of databases displayes, pick the DB you wish to connect to.
	- Finally, click on "Ok".
- Once the connection has been made, you should see the database in the 'Data Connections' section of the Server Explorer.
- To get the connection string, right click on the database and select 'Properties'. This should show a dialog box with the connection string. Copy this string and paste it in the `appsettings.json` file in the `ConnectionStrings` section.
- Should you run into any error with the connection string copied (as it appears different from the regular), modify it to the one below:
```Json
 "ConnectionStrings": {
    "DefaultConnection": "Server=<Server Name>;Database=<Database Name>;Trusted_Connection=True;TrustServerCertificate=true"
  },
```
- Now, in our `Program.cs` file, we need to add the following code to register the DbContext with the dependency injection container:
```C#
builder.Services.AddDbContext<FinanceAppDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```
- Finally we run migrations to create the tables in the database. In the Package Manager Console, run the following commands:
```bash
Add-Migration InitialCreate
Update-Database
```
- This should create a new folder called `Migrations` in the project directory. This folder contains the migration files that EF Core uses to create the database and tables.
- This type of approach is called the `Code First` approach. It allows us to create the database and tables from our code rather than having to create them manually in the database.