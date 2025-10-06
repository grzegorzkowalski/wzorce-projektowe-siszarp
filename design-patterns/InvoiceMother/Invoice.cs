namespace InvoiceMother
{
    public class Invoice
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsApproved { get; set; } // Czy zatwierdzona przez dział kontroli
        public bool IsPaid { get; set; } // Czy opłacona
        public string Currency { get; set; } // np. "PLN", "EUR", "USD"
    }
}
