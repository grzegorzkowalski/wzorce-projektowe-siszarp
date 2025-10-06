namespace OrderBuilder
{
    public static class Print
    {
        public static void PrintOrder(Order order)
        {
            Console.WriteLine($"Order {order.Id}");
            Console.WriteLine($"Total: {order.Total}");
            Console.WriteLine($"Paid: {order.Paid} ({order.PaidType})");
            Console.WriteLine(new string('-', 30));
        }
    }
}