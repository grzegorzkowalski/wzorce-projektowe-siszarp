// Domyślny obiekt (Total=100, Paid=false)
var defaultOrder = new OrderBuilder.Builder().Build();

// Niestandardowa kwota
var bigOrder = new OrderBuilder.Builder()
    .WithTotal(1500m)
    .Build();

// Opłacone zamówienie kartą
var paidOrder = new OrderBuilder.Builder()
    .HasBeenPaid("card")
    .WithTotal(250m)
    .Build();

// Wypisanie efektów
OrderBuilder.Print.PrintOrder(defaultOrder);
OrderBuilder.Print.PrintOrder(bigOrder);
OrderBuilder.Print.PrintOrder(paidOrder);

