using OpenQA.Selenium;

namespace PageObject
{
    public abstract class BaseUITest : IDisposable
    {
        protected IWebDriver Driver { get; private set; }

        public BaseUITest()
        {
            Driver = DriverFactory.CreateDriver();
            Driver.Navigate().GoToUrl("https://kidlab.pl/");
        }

        public void Dispose()
        {
            Driver?.Quit();
        }
    }

    public class KidLabTests : BaseUITest
    {
        [Fact]
        public void TestOtwieraniaProgramuNauczania_PowinnoWyswietlicOknoModalne()
        {
            // ARRANGE
            var stronaGlowna = new StronaGlownaKidLab(Driver);

            // ACT
            stronaGlowna.KliknijLinkProgramNauczania();

            // ASSERT
            Assert.True(stronaGlowna.CzyOknoModalneProgramuJestWidoczne(),
                        "Po klikniêciu linku 'Program nauczania' okno modalne nie jest widoczne.");
        }
    }
}