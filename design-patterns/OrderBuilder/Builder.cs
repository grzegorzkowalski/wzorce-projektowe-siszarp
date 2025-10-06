namespace OrderBuilder
{
    public sealed class Builder
    {
        private Guid _id = Guid.NewGuid();
        private decimal _total = 100m;
        private bool _paid = false;
        private string _paidType = "cash";

        public Builder WithTotal(decimal total)
        {
            _total = total;
            return this;
        }

        public Builder WithPaidType(string paidType)
        {
            _paidType = paidType;
            return this;
        }

        public Builder HasBeenPaid(string? paidType = null)
        {
            _paid = true;
            if (!string.IsNullOrWhiteSpace(paidType))
                _paidType = paidType;
            return this;
        }

        public Order Build() =>
        new()
        {
            Id = _id,
            Total = _total,
            Paid = _paid,
            PaidType = _paidType
        };
    }
}
