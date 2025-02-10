using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System;

namespace SeleniumAutomationTests.NUnit
{
    [TestFixture]
    public class WikipediaTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }


        public void TestSearchButton()
        {
            driver.Navigate().GoToUrl("https://www.wikipedia.org");

            IWebElement searchButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='pure-button pure-button-primary-progressive']")));
            Assert.That(searchButton.Displayed, "Бутонът за търсене не е наличен.");
        }


        [Test]
        public void TestLanguageOptions()
        {
            driver.Navigate().GoToUrl("https://www.wikipedia.org");

            IWebElement englishOption = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='link-box'][@lang='en']")));
            IWebElement germanOption = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='link-box'][@lang='de']")));

            Assert.That(englishOption.Displayed, "Езиковата опция за английски не е налична.");
            Assert.That(germanOption.Displayed, "Езиковата опция за немски не е налична.");
        }


        [Test]
        public void TestLogo()
        {
            driver.Navigate().GoToUrl("https://www.wikipedia.org");

            IWebElement logo = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("www-wikipedia-org")));
            Assert.That(logo.Displayed, "Логото на Wikipedia не е видимо.");
        }


        [Test]
        public void TestSearchFunctionality()
        {
            driver.Navigate().GoToUrl("https://www.wikipedia.org");

            IWebElement searchInput = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("search")));
            searchInput.SendKeys("Selenium WebDriver");
            searchInput.SendKeys(Keys.Enter);


            IWebElement firstResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h1[contains(text(),'Selenium WebDriver')]")));
            Assert.That(firstResult.Displayed, "Резултатите от търсенето не се показват.");
        }


        [Test]
        public void TestMainLinks()
        {
            driver.Navigate().GoToUrl("https://www.wikipedia.org");


            IWebElement englishLink = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='link-box'][@lang='en']")));
            Assert.That(englishLink.Displayed, "Линкът за английската версия не е наличен.");
        }

        [Test]
        public void TestMobileVersionLink()
        {
            driver.Navigate().GoToUrl("https://www.wikipedia.org");

            IWebElement mobileLink = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='other-project-link'][@href='https://m.wikipedia.org']")));
            Assert.That(mobileLink.Displayed, "Линкът към мобилната версия не е наличен.");
        }


        [Test]
        public void TestSearchUrl()
        {
            driver.Navigate().GoToUrl("https://www.wikipedia.org");

            IWebElement searchInput = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("search")));
            searchInput.SendKeys("C#");
            searchInput.SendKeys(Keys.Enter);


            Assert.That(driver.Url.Contains("C#"), "URL не съдържа търсената дума.");
        }


        [Test]
        public void TestArticleCategories()
        {
            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Selenium_(software)");


            IWebElement categoriesSection = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("catlinks")));
            Assert.That(categoriesSection.Displayed, "Няма видими категории за статията.");
        }


        [Test]
        public void TestHeaderContent()
        {
            driver.Navigate().GoToUrl("https://www.wikipedia.org");


            IWebElement header = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("www-wikipedia-org")));
            Assert.That(header.Displayed, "Хедърът на Wikipedia не е видим.");
        }


        [Test]
        public void TestLanguageSwitchButton()
        {
            driver.Navigate().GoToUrl("https://www.wikipedia.org");


            IWebElement languageSwitchButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("js-lang-later")));
            Assert.That(languageSwitchButton.Displayed, "Бутонът за смяна на езика не е наличен.");
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
