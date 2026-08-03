using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExpense.Models
{
    public class ExpenseClaim
    {
        [Key]
        public int ClaimId { get; set; }

        public string EmployeeId { get; set; }

        public string CategoryId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
