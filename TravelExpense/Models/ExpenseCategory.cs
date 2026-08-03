using System.ComponentModel.DataAnnotations;

namespace TravelExpense.Models
{
    public class ExpenseCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

    }
}
