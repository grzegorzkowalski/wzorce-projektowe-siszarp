using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBuilder
{
    public sealed class Order
    {
        public Guid Id { get; init; }
        public decimal Total { get; init; }
        public bool Paid { get; init; }
        public string PaidType { get; init; } = string.Empty; // "cach, card etc."
    }
}
