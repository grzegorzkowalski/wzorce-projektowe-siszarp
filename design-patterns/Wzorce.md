## W Folderze Samples s� dost�pne przyk�ady dla wszystkich klasycznychwzorc� projektowych Gangu Czworga.

## W folderze Tasks s� dost�pne przyk�adowe rozwi�zania poni�szych zada� z wzorc�w.

## Singleton *

### Zadanie 1
1. Stw�rz now� aplikacj� konsolow� `SingletonVault`
1. Stw�rz klas� o nazwie `Vault`. Zadaniem tej klasy jest zwr�cenie cyfrowego klucza dost�powego do skarbca.
1. Dlatego upewnij si�, �e jeste� w stanie zwr�ci� klucz tylko raz.

## Factory

### Zadanie 1
1. Stw�rzy klas� Wojownik. Utw�rz klasy dziedzicz�ce Piechur, Strzelec, Konny.
1. Stw�rz klas� garnizon, kt�ra na podstawie nazwy profesji wyszkoli i zwr�ci nam obiekt odpowiedniego wojownika.
1. Stw�rz tablic� zawieraj�c� 3 piechur�w, 3 konnych i 4 strzelc�w.

## Builder

### Zadanie 1
1. Utw�rz klas� abstrakcyjn� WarriorBuilder.
1. Utw�rz klasy PiechurBuilder, StrzelecBuilder, KonnyBuilder.
1. Stw�rz klas� Garnizon, kt�rej zadaniem b�dzie szkolenie wojownik�w o odpowiedniej profesji.
1. Szkolenie powinno przebiega� w 3 krokach. Zapisanie si� do armii (utworzenie obiektu odpowiedniego typu), pobranie broni, trening walki.
1. Wykorzystaj klasy wojownik�w z poprzedniego zadania. 
1. Stw�rz nowy garnizon i dodaj tam 2 piechur�w, 2 konnych i 2 strzelc�w. 
1. Mo�esz wykorzysta� interface `IWarrior` i list� generyczn� `List<IWarrior>`;

## TestDataBuilder

### Zadanie 1
1. Zaimplementuj OrderBuilder dla klasy:
```
public sealed class Order {
    public Guid Id { get; init; }
    public decimal Total { get; init; }
    public bool Paid { get; init; }
    public string PaidType { get; init; } = string.Empty; // "cach, card etc."
}

```

1. Ustaw warto�ci domy�lne Total = 100m, Paid = false.
1. Dodaj metody WithTotal(decimal), WithPaidType, HasBeenPaid().

## ObjectMother 

### Zadanie 1 

Zadanie do Samodzielnego Wykonania
Cel: Dodaj now� metod� do klasy ReservationMother, kt�ra obs�u�y nowy, konkretny scenariusz.

Scenariusz: "Rezerwacja Last Minute"

Imi�/Nazwisko: "Tomasz Szybki"

Data zameldowania: Dzi� (DateTime.Now)

Data wymeldowania: Jutro (DateTime.Now.AddDays(1))

Cena ca�kowita: 100.00M (bardzo niska)

Status: "Confirmed"

P�atno��: Prawda (HasPaid = true)

Twoje zadanie:
Napisz kod metody CreateLastMinuteReservation() i umie�� j� w klasie ReservationMother.

### Zadanie 2

Scenariusz Zadania: Testowanie Serwisu Faktur
Kontekst: Mamy system ksi�gowy, w kt�rym faktury musz� przechodzi� przez r�ne stany weryfikacji i p�atno�ci.

1. Model Danych (Klasy Produkcyjne)
Za��my, �e mamy nast�puj�c� klas� `Invoice`:
```
public class Invoice
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsApproved { get; set; } // Czy zatwierdzona przez dzia� kontroli
    public bool IsPaid { get; set; } // Czy op�acona
    public string Currency { get; set; } // np. "PLN", "EUR", "USD"
}

public class InvoiceService
{
    // Metoda do testowania: sprawdza, czy faktura mo�e by� zaksi�gowana w systemie
    public bool CanBeBooked(Invoice invoice)
    {
        // Faktur� mo�na zaksi�gowa�, je�li:
        // 1. Jest zatwierdzona (`IsApproved == true`).
        // 2. Nie jest jeszcze op�acona (`IsPaid == false`).
        // 3. Jest w walucie PLN lub EUR.
        return invoice.IsApproved && !invoice.IsPaid && 
               (invoice.Currency == "PLN" || invoice.Currency == "EUR");
    }
}
```

2. Twoim zadaniem jest stworzenie statycznej klasy `InvoiceMother i zaimplementowanie w niej metod, kt�re b�d� zwraca� faktury skonfigurowane dla konkretnych scenariuszy testowych.

Metody do Utworzenia w `InvoiceMother`:
Nazwa Metody	Opis Scenariusza	Konfiguracja Danych
`CreateValidPLN()`	Faktura gotowa do zaksi�gowania	IsApproved = true, IsPaid = false, Currency = "PLN", Amount = 1000.00M, Issue/Due Date � dzisiaj/za 30 dni.
`CreateUnapproved()`	Faktura oczekuj�ca na kontrol�	IsApproved = false, IsPaid = false, Currency = "PLN", Amount = 500.00M.
`CreatePaid()`	Faktura ju� op�acona	IsApproved = true, IsPaid = true, Currency = "PLN", Amount = 200.00M.
`CreateInvalidCurrency()`	Faktura w nieobs�ugiwanej walucie	IsApproved = true, IsPaid = false, Currency = "USD", Amount = 800.00M.
`CreateHighValueEUR()`	Faktura spe�niaj�ca warunki, ale droga	IsApproved = true, IsPaid = false, Currency = "EUR", Amount = 50000.00M.

3. Napisz Testy
Po zaimplementowaniu `InvoiceMother`, u�yj jej, aby napisa� dwa testy xUnit dla metody `InvoiceService.CanBeBooked()`:

Test 1 (Fact): Sprawd�, czy `CanBeBooked()` zwraca true dla faktury stworzonej przez `InvoiceMother.CreateValidPLN()`.

Test 2 (Fact): Sprawd�, czy `CanBeBooked()` zwraca false dla faktury stworzonej przez `InvoiceMother.CreateUnapproved()`.

## Prototype *

### Zadanie 1
1. Stw�rz klas� Ork.
1. Stw�rz nowego orka.
1. Za pomoc� serializacji i deserializacji w p�tli stw�rz kilka klon�w utworzonego nowego obiektu klasy ork i dodaj do kolekcji.
1. Zmieniaj im losowo np. parametr si�a. 
1. Wykorzystaj https://www.newtonsoft.com/json/help/html/SerializingJSON.htm

## Facade

### Zadanie 1
1. Wykorzystaj serwis pogodowy https://openweathermap.org/, kt�ry umo�liwia pobieranie informacji o pogodzie.
1. Zaprojektuj fasad� dla tej us�ugi. Fasada powinna udost�pnia� uproszczony interfejs do korzystania z us�ugi, np. metod�, kt�ra zwraca aktualn� temperatur� w danym mie�cie.
1. Stw�rz interfejs u�ytkownika w konsoli, kt�ry pozwoli u�ytkownikowi na wyb�r miasta i wy�wietli aktualn� temperatur� w tym mie�cie.
1. Zaimplementuj fasad�, aby korzysta� z zewn�trznego API, aby pobra� informacje o pogodzie i zwr�ci� uproszczony interfejs do wykorzystania w interfejsie u�ytkownika.
1. Przetestuj aplikacj�, upewniaj�c si�, �e fasada dzia�a poprawnie i udost�pnia uproszczony interfejs u�ytkownika do korzystania z zewn�trznego API.
1. Wykorzystaj do komunikacji klas�: HttpClient  
https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/http/httpclient

Przyk�ad u�ycia: 
https://gist.github.com/AliA1997/b4b3e1066dd9f31a78554438ab5d61bd

## Proxy

### Zadanie 1
1. Stw�rz dwie klasy. Jedna ma reprezentowa� obiekt dost�pny bez ogranicze�, druga obiekt zastrze�ony (dost�p ograniczony has�em).
1. Zaprojektuj proxy, kt�ry b�dzie kontrolowa� dost�p do plik�w po przez sprawdzenie czy has�o zwr�cone zosta�o poprawnie.
1. Stw�rz interfejs u�ytkownika w konsoli, kt�ry pozwoli u�ytkownikowi na wyb�r obiektu do pobrania i wprowadzenie has�a.
1. Przetestuj aplikacj�, upewniaj�c si�, �e proxy dzia�a poprawnie i kontroluje dost�p do obiekt�w.

## Adapter

### Zadanie 1
1. Naszym zadaniem jest przechytrzy� bramkarza w klubie nocnym.
1. Nasz 17 letni Krzy� chce dosta� si� do klubu i pota�czy�, ale nie przechodzi walidacji (np. metoda IsAdult).
1. Napisz adapter klas� `FakeAdult`, kt�ra dziedziczy po klasie `Adult`.
1. Zadaniem adaptera jest oszuka� walidacj� i pozwoli� naszemu bohaterowi wej�� i pobawi� si� w klubie.


## Bridge *

### Zadanie 1
1. Wyobra�my sobie pulpit w naszym systemie operacyjnym. Dla systemu Windows jest to zazwyczaj oczywiste, �e b�dziemy korzysta� z interface'u graficznego. Natomiast u�ytkownik Linux mo�e sobie interface wybra�.
2. Dlatego nie chcemy na sta�e wi�za� interface z systemem operacyjnym.
3. Prosz� wdro�y� odpowiednie klasy (np. System, LinuxSystem, Interface, GraphicInterface).
4. Prosz� wdro�y� relacje mi�dzy tymi elementami za pomoc� wzorca bridge.
5. Przetestuj poprawno�� rozwi�zanie. Niech naci�niecie przycisku menu w naszym interface zwr�ci nam z systemu list� zainstalowanych program�w. (na potrzeby zadania b�dzie to wywo�anie w konsoli funkcji `displayMenu`).

## Decorator *

### Zadanie 1
1. Przygotuj klas� sklepu np. `Shop`.
2. Dodaj mo�liwo�� p�acenia 3 r�nymi sposobami p�atno�ci (nie implementuj prawdziwego po��czenia z systemem p�atno�ci).
3. Je�eli u�ytkownik zap�aci kart� powinien uruchamia� si� dekorator. 
4. Dodaj 3 dekoratory, kt�re b�d� wykonywa�y si� przy p�atno�ci. Np. powiadomienie sms o p�atno�ci, dodanie punkt�w lojalno�ciowych, przekierowanie na stron� g��wn� sklepu.

## Composite *

## Zadanie 1

1. Napisz program, kt�ry symuluje menu restauracji. 
1. Ka�da pozycja w menu mo�e by� daniem (li��) lub podkategori� (kompozyt) zawieraj�c� inne dania lub podkategorie. 
1. Stw�rz struktur�, kt�ra b�dzie w stanie wy�wietli� pe�ne menu z mo�liwo�ci� zag��biania si� w podkategorie.

## Flyweight *

## Zadanie 1

1. Napisz program, kt�ry symuluje system zarz�dzania teksturami w grze. 
1. Ka�da tekstura powinna by� wczytywana z pliku tylko raz i wsp�dzielona pomi�dzy r�nymi obiektami, 
kt�re jej u�ywaj� (np. postaciami, elementami otoczenia).

## Page Object

1. Napisz testy z wykorzystanie wzorca Page Object, kt�ry na stronie https://kidlab.pl, odnajdzie link O Nas i sprawdzi czy modal si� otworzy.
1. Na modalu znajdz tekst "Nasza oferta zaj��".
1. Zamknij modal na koniec testu.

## Command

### Zadanie 1

1. Stw�rz klas� `SantaClausFactory`. 
1. Jej zadaniem b�dzie odbieranie odpowiednich polece� (commands) i produkowanie zabawek lub r�zg.
2. Stw�rz klas� pomocnika �wi�tego Miko�aja, kt�ry b�dzie przekazywa� polecenia do fabryki.  
3. Wykonaj 3 zabawki i jedn� r�zg�.

## Observer

### Zadanie 1

1. Za��my, �e jest grupa student�w, kt�ra oczekuje na wyniki egzaminu i jest obiekt wyk�adowca.
2. Napisz implementacje wzorca obserwatora w ten spos�b, �e w momencie, gdy wyk�adowca og�osi wyniki, ka�dy student dostanie informacje o swoim wyniku.

## Strategy

## Zadanie 1

1. W naszej redakcji internetowej chcieliby�my m�c w �atwy spos�b przeszuka� r�ne bazy zdj��.
2. Zaimplementuj rozwi�zanie, kt�re w zale�no�ci od preferencji pozwoli przeszuka� baz� zdj�� [Pexels](https://www.pexels.com/api/) 
lub baz� zdj�� [Pixabay](https://pixabay.com/api/docs/), po wybranej nazwie kategorii.
3. Wykonaj wszystkie wymagane kroki, �eby m�c korzysta� z API dla obu rozwi�za�.

## Visitor *

## Zadanie 1

1. Napisz program, kt�ry symuluje system sklepu internetowego. 
1. Sklep ma r�ne typy produkt�w: Book (ksi��ka) i Electronics (elektronika). Ka�dy produkt powinien zaakceptowa� odwiedzaj�cego, kt�ry mo�e obliczy�:
Cen� po zastosowaniu zni�ki (np. 10% dla ksi��ek i 5% dla elektroniki).
Koszt dostawy (np. 5 z� dla ksi��ek i 15 z� dla elektroniki).
Ka�dy produkt powinien posiada� cen� bazow�, na podstawie kt�rej zostan� wykonane obliczenia.

## Memento *

## Zadanie 1

1. Napisz program symuluj�cy prosty notatnik, w kt�rym u�ytkownik mo�e dodawa� linie tekstu. 
1. Notatnik powinien umo�liwia� cofanie ostatnio dodanej linii, przywracaj�c stan notatki do poprzedniego stanu.

Wymagania

Operacje:
Dodawanie tekstu: Dodaje now� lini� tekstu do notatki.

Cofanie: 
Usuwa ostatnio dodan� lini� tekstu, przywracaj�c poprzedni stan.

Przechowywanie stanu:
Program powinien zapisywa� stan notatki po ka�dej operacji i umo�liwia� cofanie.

## Template Method

## Zadanie 1

1. Stw�rz program, kt�ry symuluje proces przetwarzania dokumentu. 
1. Dokument mo�e by� w formacie PDF lub Word. W obu przypadkach proces przetwarzania dokumentu sk�ada si� z nast�puj�cych krok�w:
Otwieranie dokumentu.
Parsowanie tre�ci dokumentu (r�ne dla PDF i Word).
Wy�wietlanie tre�ci dokumentu.
Zamkni�cie dokumentu.
Zdefiniuj szablon metody w klasie bazowej ``DocumentProcessor`` i utw�rz klasy pochodne `PDFProcessor` i `WordProcessor`, kt�re implementuj� szczeg�y specyficzne dla danego formatu.

## Mediator *

## Zadanie 1

1. Stw�rz program symuluj�cy kontrol� lot�w na lotnisku. 
1. Samoloty (Airplane) komunikuj� si� ze sob� i z wie�� kontroli lot�w (ControlTower) za po�rednictwem mediatora. 
1. Mediator (ControlTower) zarz�dza komunikacj� i decyduje, kt�re samoloty mog� l�dowa�, startowa�, lub ko�owa�.

## Chain of Responsibility *

## Zadanie 1

1. Stw�rz program symuluj�cy system przetwarzania dokument�w w firmie. 
1. Dokumenty mog� mie� r�ne poziomy priorytetu: Niski, �redni, Wysoki. Ka�dy dokument jest przetwarzany przez odpowiedniego pracownika:
1. Pracownik pierwszego poziomu przetwarza dokumenty o niskim priorytecie.
1. Pracownik drugiego poziomu przetwarza dokumenty o �rednim priorytecie.
1. Pracownik trzeciego poziomu przetwarza dokumenty o wysokim priorytecie.
1. Je�li dokument nie zostanie obs�u�ony na odpowiednim poziomie, powinien zosta� przekazany do wy�szego poziomu.

## Dodatkowe Warsztat 1: System Zarz�dzania Zam�wieniami
Opis Problemu
Masz do czynienia z systemem zarz�dzania zam�wieniami, kt�ry jest �le zaprojektowany. Kody odpowiedzialne za r�ne operacje s� pomieszane i mocno ze sob� powi�zane, co utrudnia modyfikacj� i rozw�j systemu. Celem warsztatu jest refaktoryzacja kodu, aby by� bardziej czytelny, �atwiejszy w utrzymaniu i zgodny z zasadami programowania obiektowego, a jednocze�nie zastosowanie w nim r�nych wzorc�w projektowych.

Sytuacja wyj�ciowa
Zarz�dzanie zam�wieniami:

System obs�uguje r�ne typy zam�wie�: StandardOrder, ExpressOrder.
Obliczanie koszt�w dostawy jest zagnie�d�one w klasie zam�wienia.
Powiadomienia s� wysy�ane za pomoc� r�nych kana��w komunikacji (e-mail, SMS) bezpo�rednio z klasy zam�wienia.
Zam�wienia musz� by� przetwarzane przez r�ne etapy: Przyj�te, W trakcie realizacji, Wys�ane.
Cel refaktoryzacji:

Oddzieli� r�ne odpowiedzialno�ci i wprowadzi� wzorce projektowe takie jak: Strategy, Observer, Factory Method, State, Command.
Kod przed refaktoryzacj�

```csharp	
using System;
using System.Collections.Generic;

public class Order
{
    public string OrderType { get; set; }
    public string Status { get; set; }
    public double Amount { get; set; }

    public void ProcessOrder()
    {
        Console.WriteLine($"Przetwarzanie zam�wienia typu {OrderType}...");
        
        double shippingCost = 0;
        if (OrderType == "Standard")
        {
            shippingCost = 10;
        }
        else if (OrderType == "Express")
        {
            shippingCost = 20;
        }
        
        Console.WriteLine($"Koszt dostawy: {shippingCost} z�");
        Amount += shippingCost;

        Console.WriteLine("Wysy�anie powiadomienia e-mail...");
        Console.WriteLine("Wysy�anie powiadomienia SMS...");

        if (Status == "Przyj�te")
        {
            Status = "W trakcie realizacji";
        }
        else if (Status == "W trakcie realizacji")
        {
            Status = "Wys�ane";
        }

        Console.WriteLine($"Nowy status zam�wienia: {Status}");
    }
}

class Program
{
    static void Main()
    {
        Order order1 = new Order { OrderType = "Standard", Status = "Przyj�te", Amount = 100 };
        order1.ProcessOrder();

        Order order2 = new Order { OrderType = "Express", Status = "Przyj�te", Amount = 200 };
        order2.ProcessOrder();
    }
}
```

Cele Refaktoryzacji
Strategy Pattern: Wykorzystaj wzorzec Strategii do obliczania koszt�w dostawy.
Observer Pattern: Wykorzystaj wzorzec Obserwatora do obs�ugi powiadomie�.
Factory Method Pattern: Wykorzystaj wzorzec Metody Fabrycznej do tworzenia r�nych typ�w zam�wie�.
State Pattern: Wykorzystaj wzorzec Stanu do zarz�dzania statusem zam�wienia.
Command Pattern: Wykorzystaj wzorzec Komendy do obs�ugi dzia�a� zwi�zanych z zam�wieniem.