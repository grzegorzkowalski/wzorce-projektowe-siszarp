using System;
using System.Collections.Generic;

// --- 1. Interfejsy (Definicje ról) ---

// Krok, który Aktor może wykonać (Interakcja lub Zadanie)
public interface IPerformable
{
    void PerformAs<TAbility>(Actor actor) where TAbility : IAbility;
}

// Interfejs dla Zdolności, czyli jak Aktor wchodzi w interakcję z systemem
public interface IAbility
{
    // Cechy specyficzne dla zdolności, np. WebDriver dla ICanBrowseTheWeb
}

// Interfejs dla Pytań
public interface IQuestion<TResult>
{
    TResult AnsweredBy(Actor actor);
}

// --- 2. Klasa Aktora ---

public class Actor
{
    public string Name { get; }
    private Dictionary<Type, IAbility> abilities = new Dictionary<Type, IAbility>();

    public Actor(string name)
    {
        Name = name;
    }

    // Nadaje Aktorowi zdolność (np. używania przeglądarki)
    public Actor Can<TAbility>(TAbility ability) where TAbility : IAbility
    {
        abilities[typeof(TAbility)] = ability;
        return this;
    }

    // Metoda do wykonywania Zadań i Interakcji
    public void AttemptsTo(IPerformable performable)
    {
        Console.WriteLine($"\n{Name} attempts to: {performable.GetType().Name}");
        // Używamy IAbility jako generycznego typu dla ułatwienia
        performable.PerformAs<IAbility>(this);
    }

    // Metoda do zadawania Pytań
    public TResult AsksFor<TResult>(IQuestion<TResult> question)
    {
        return question.AnsweredBy(this);
    }

    // Metoda do pobierania konkretnej zdolności Aktora
    public TAbility AbilityTo<TAbility>() where TAbility : IAbility
    {
        if (abilities.TryGetValue(typeof(TAbility), out var ability))
        {
            return (TAbility)ability;
        }
        throw new InvalidOperationException($"Actor {Name} cannot perform action requiring {typeof(TAbility).Name}.");
    }
}

// --- 3. Zdolność (Ability) ---

// Zdolność do przeglądania strony
public class ICanBrowseTheWeb : IAbility
{
    // W prawdziwym teście tu byłby obiekt np. WebDrivera
    public void ClickElement(string selector)
    {
        Console.WriteLine($"[Web] Wykonano kliknięcie na elemencie: {selector}");
    }

    public void TypeText(string selector, string text)
    {
        Console.WriteLine($"[Web] Wpisano '{text}' do pola: {selector}");
    }
}

// --- 4. Interakcje (Interactions) ---

// Elementarny krok: Kliknięcie w przycisk
public class ClickButton : IPerformable
{
    private string selector;

    public ClickButton(string selector) => this.selector = selector;

    public void PerformAs<TAbility>(Actor actor) where TAbility : IAbility
    {
        // Aktor używa swojej Zdolności do interakcji
        actor.AbilityTo<ICanBrowseTheWeb>().ClickElement(selector);
    }
}

// Elementarny krok: Wpisanie tekstu
public class TypeText : IPerformable
{
    private string selector;
    private string text;

    public TypeText(string selector, string text)
    {
        this.selector = selector;
        this.text = text;
    }

    public void PerformAs<TAbility>(Actor actor) where TAbility : IAbility
    {
        actor.AbilityTo<ICanBrowseTheWeb>().TypeText(selector, text);
    }
}

// --- 5. Zadanie (Task) ---

// Cel biznesowy: Logowanie
public class LoginAsUser : IPerformable
{
    private string login;
    private string password;

    public LoginAsUser(string login, string password)
    {
        this.login = login;
        this.password = password;
    }

    public void PerformAs<TAbility>(Actor actor) where TAbility : IAbility
    {
        // Zadanie łączy Interakcje
        new TypeText("#usernameField", login).PerformAs<IAbility>(actor);
        new TypeText("#passwordField", password).PerformAs<IAbility>(actor);
        new ClickButton("#loginButton").PerformAs<IAbility>(actor);
    }
}

// --- 6. Pytanie (Question) ---

public class IsUserLoggedIn : IQuestion<bool>
{
    public bool AnsweredBy(Actor actor)
    {
        // Tutaj byłaby logika sprawdzająca stan, np. szukanie elementu "Witaj, Użytkowniku"
        Console.WriteLine($"\n{actor.Name} sprawdza status zalogowania...");
        return true; // Symulacja, że jest zalogowany
    }
}

// --- 7. Scenariusz Testowy (Main) ---

public class Program
{
    public static void Main()
    {
        // 1. Inicjalizacja Aktora i jego Zdolności
        var janek = new Actor("Janek Tester");
        janek.Can(new ICanBrowseTheWeb()); // Janek potrafi przeglądać strony

        // 2. Wykonanie Scenariusza (Given-When-Then)

        // WHEN: Janek próbuje wykonać Zadanie logowania
        janek.AttemptsTo(
            new LoginAsUser("janek.test", "TajneHaslo123")
        );

        // THEN: Weryfikacja stanu (Pytanie)
        bool isLogged = janek.AsksFor(new IsUserLoggedIn());

        if (isLogged)
        {
            Console.WriteLine("\n✅ TEST ZALICZONY: Użytkownik jest zalogowany.");
        }
        else
        {
            Console.WriteLine("\n❌ TEST NIEZALICZONY: Logowanie nie powiodło się.");
        }
    }
}