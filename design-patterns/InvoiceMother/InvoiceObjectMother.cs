namespace InvoiceMother
{
    public class InvoiceObjectMother
    {
        private static int _nextId = 1000;

        // Prywatna metoda bazowa, która ustawia domyślne, nieistotne pola
        private static Invoice CreateBase()
        {
            return new Invoice
            {
                Id = _nextId++,
                Amount = 100.00M,
                IssueDate = DateTime.Now.AddDays(-15),
                DueDate = DateTime.Now.AddDays(15),
                IsApproved = false,
                IsPaid = false,
                Currency = "PLN"
            };
        }

        // SCENARIUSZ 1: Faktura gotowa do zaksięgowania (PLN)
        public static Invoice CreateValidPLN()
        {
            var invoice = CreateBase();
            invoice.Amount = 1000.00M;
            invoice.IsApproved = true; // Kluczowy warunek
            invoice.IsPaid = false;    // Kluczowy warunek
            invoice.Currency = "PLN";  // Kluczowy warunek
            return invoice;
        }

        // SCENARI2USZ 2: Faktura oczekująca na kontrolę (niezatwierdzona)
        public static Invoice CreateUnapproved()
        {
            var invoice = CreateBase();
            invoice.Amount = 500.00M;
            invoice.IsApproved = false; // Kluczowy warunek
            return invoice;
        }

        // SCENARIUSZ 3: Faktura już opłacona
        public static Invoice CreatePaid()
        {
            var invoice = CreateValidPLN(); // Zaczynamy od faktury ważnej
            invoice.Amount = 200.00M;
            invoice.IsPaid = true; // Kluczowy warunek
            return invoice;
        }

        // SCENARIUSZ 4: Faktura w nieobsługiwanej walucie
        public static Invoice CreateInvalidCurrency()
        {
            var invoice = CreateValidPLN(); // Zaczynamy od faktury ważnej
            invoice.Amount = 800.00M;
            invoice.Currency = "USD"; // Kluczowy warunek
            return invoice;
        }

        // SCENARIUSZ 5: Faktura spełniająca warunki, ale droga (EUR)
        public static Invoice CreateHighValueEUR()
        {
            var invoice = CreateValidPLN(); // Zaczynamy od faktury ważnej
            invoice.Amount = 50000.00M;
            invoice.Currency = "EUR"; // Kluczowy warunek
            return invoice;
        }
    }
}
