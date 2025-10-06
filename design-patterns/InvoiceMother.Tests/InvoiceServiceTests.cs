using InvoiceMother;

namespace InvoiceMother.Tests
{
    public class InvoiceServiceTests
    {
        private readonly InvoiceService _service = new InvoiceService();

        // TEST 1: Sprawdza przypadek pozytywny
        [Fact]
        public void CanBeBooked_ShouldReturnTrue_ForValidPLNInvoice()
        {
            // ARRANGE
            var validInvoice = InvoiceObjectMother.CreateValidPLN();

            // ACT
            var result = _service.CanBeBooked(validInvoice);

            // ASSERT
            Assert.True(result);
        }

        // TEST 2: Sprawdza przypadek negatywny (brak zatwierdzenia)
        [Fact]
        public void CanBeBooked_ShouldReturnFalse_ForUnapprovedInvoice()
        {
            // ARRANGE
            var unapprovedInvoice = InvoiceObjectMother.CreateUnapproved();

            // ACT
            var result = _service.CanBeBooked(unapprovedInvoice);

            // ASSERT
            Assert.False(result);
        }

        [Fact]
        public void CanBeBooked_ShouldReturnFalse_ForPaidInvoice()
        {
            // ARRANGE
            var paidInvoice = InvoiceObjectMother.CreatePaid();

            // ACT
            var result = _service.CanBeBooked(paidInvoice);

            // ASSERT
            Assert.False(result);
        }
    }
}