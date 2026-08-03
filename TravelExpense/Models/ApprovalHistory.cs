using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExpense.Models
{
    public class ApprovalHistory
    {
        [Key]
        public int HistoryId { get; set; }

        [Required]
        public int ClaimId { get; set; }

        [ForeignKey("ClaimId")]
        public ExpenseClaim ExpenseClaim { get; set; }

        [Required]
        public int ActionBy { get; set; }

        [ForeignKey("ActionBy")]
        public User User { get; set; }

        [Required]
        public string Action { get; set; }

        public string? Remarks { get; set; }

        public DateTime ActionDate { get; set; } = DateTime.Now;
    }
}
