using AutoMapper;
using PersonalFinanceApp.Models.Domain;
using PersonalFinanceApp.Models.DTOs;

namespace PersonalFinanceApp.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Expenses, CreateExpenseDTO>().ReverseMap();
            CreateMap<Expenses, UpdateExpenseDTO>().ReverseMap();
        }
    }
}
