namespace TravelExpense.ViewModels
{
    public class AdminDashboardViewModel
    {
        public int TotalUsers { get; set; }

        public int TotalClaims { get; set; }

        public int PendingClaims { get; set; }

        public int ApprovedClaims { get; set; }

        public int PaidClaims { get; set; }
    }
}