using OpenQA.Selenium;

namespace PageObject
{
    public class StronaGlownaKidLab
    {
        private readonly IWebDriver _driver;

        // --- 1. LOKALIZATORY ELEMENTÓW (Locators) ---
        // Lokalizator dla linku 'Program nauczania'
        private By LinkProgramNauczaniaLocator = By.LinkText("Program nauczania");

        // Lokalizator dla samego okna modalnego (może to być kontener div z klasą 'modal-content')
        private By OknoModalneProgramuLocator = By.CssSelector("#techDialogId");

        // Lokalizator dla przycisku zamknięcia okna modalnego (opcjonalnie)
        private By PrzyciskZamknijModalLocator = By.CssSelector("#dialogTop.button");

        public StronaGlownaKidLab(IWebDriver driver)
        {
            _driver = driver;
        }

        // --- 2. METODA AKCJI (Action) ---

        // Akcja biznesowa: Kliknięcie linku otwierającego okno modalne
        public void KliknijLinkProgramNauczania()
        {
            _driver.FindElement(LinkProgramNauczaniaLocator).Click();
        }

        // --- 3. METODA WERYFIKACYJNA (Weryfikacja widoczności UI) ---

        // Metoda pomocnicza dla asercji, sprawdza widoczność elementu modalnego
        public bool CzyOknoModalneProgramuJestWidoczne()
        {
            // Używamy try-catch lub metody, która sprawdza istnienie i widoczność elementu 
            // bez rzucania wyjątku, jeśli element nie istnieje.
            try
            {
                var modal = _driver.FindElement(OknoModalneProgramuLocator);
                return modal.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
