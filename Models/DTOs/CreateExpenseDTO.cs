using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceApp.Models.DTOs
{
    public class CreateExpenseDTO
    {
        public string? Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }
        [Required]
        public string? Category { get; set; }
    }
}
