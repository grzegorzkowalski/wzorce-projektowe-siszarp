namespace InvoiceMother
{
    public class InvoiceService
    {
        // Metoda do testowania: sprawdza, czy faktura może być zaksięgowana w systemie
        public bool CanBeBooked(Invoice invoice)
        {
            // Fakturę można zaksięgować, jeśli:
            // 1. Jest zatwierdzona (`IsApproved == true`).
            // 2. Nie jest jeszcze opłacona (`IsPaid == false`).
            // 3. Jest w walucie PLN lub EUR.
            return invoice.IsApproved && !invoice.IsPaid &&
                   (invoice.Currency == "PLN" || invoice.Currency == "EUR");
        }
    }
}
