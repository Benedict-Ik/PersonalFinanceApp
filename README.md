# Personal Finance App

Here is what we did in this branch:

- Installed AutoMapper via Package Manager Console:
```bash
Install-Package AutoMapper
```
- Created new model classes - `CreateExpenseDTO` and `UpdateExpenseDTO` to present the data we want the client to see.

- Created a Mapping Profile  
Create a class (e.g., AutoMapperProfiles.cs) inside a folder like Helpers, Profiles, or Mappings. For our project, we will create a `Mappings` folder.
```c#
public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Expenses, CreateExpenseDTO>().ReverseMap();
            CreateMap<Expenses, UpdateExpenseDTO>().ReverseMap();
        }
    }
```

- Registered AutoMapper in Program.cs
Add the below line just above the build() method:
```C#
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
```

- Injected and utilized the AutoMapper in the controller class.
- private readonly IMapper _mapper;

```C#
public ExpensesController(IMapper mapper)
{
    _mapper = mapper;
}
```

- Updated the `Edit.cshtml` and `Create.cshtml` views to use the respective DTO models (UpdateExpenseDTO & CreateExpenseDTO).
- To avoid routing conflicts, I modified the `Update` method's [HTTPPost] attribute in the controller class as seen below:
```C#
[HttpPost("Update")]
```