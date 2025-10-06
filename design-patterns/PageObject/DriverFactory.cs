using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PageObject
{
    public static class DriverFactory
    {
        // Główna metoda tworząca instancję WebDrivera
        public static IWebDriver CreateDriver()
        {
            // Ustawienia dla Chrome
            var options = new ChromeOptions();
            // Przykład konfiguracji: uruchomienie w trybie bezgłowym (Headless)
            // options.AddArgument("--headless"); 

            // Utwórz nowy sterownik Chrome
            IWebDriver driver = new ChromeDriver(options);

            // Ustawienie globalnych parametrów
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

            return driver;
        }
    }
}
