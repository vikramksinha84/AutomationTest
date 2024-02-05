using AutomationTest.BaseClass;
using AutomationTest.Hooks;
using AutomationTest.PagesObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationTest.StepDefinitions
{
    [Binding]
    internal class AmazonTestStepDefinition 
    {
        public IWebDriver? Driver = null;
        BasePage? CurrentPage;
        string? _productName = String.Empty;
        internal AmazonHomePage? amazonHomePage => new AmazonHomePage(Driver);

        [Given(@"User Navigate to amazon\.in")]
        public void GivenUserNavigateToAmazon_In()
        {
            Driver = new ChromeDriver();
            if (Driver != null)
            {
                Driver.Manage().Window.Maximize();
                Driver.Navigate().GoToUrl("https://www.amazon.in/");
            }
        }

        [When(@"User Amazon Home Page")]
        public void WhenUserAmazonHomePage()
        {
            amazonHomePage?.VerifyAmazonlogo();
        }

        [When(@"user search the product ""([^""]*)"" filter folder")]
        public void WhenUserSearchTheProductFilterFolder(string product)
        {
            amazonHomePage?.SearchItem(product);
        }

        [Then(@"user validate the searched word from Result Info bar ""([^""]*)""")]
        public void ThenUserValidateTheSearchedWordFromResultInfoBar(string product)
        {
            amazonHomePage?.ValidateSearchedItem(product);
        }

        [When(@"Select the Hamburger Menu button from the main navigation bar")]
        public void WhenSelectTheHamburgerMenuButtonFromTheMainNavigationBar()
        {
            amazonHomePage?.CLickOnHamburger();
        }

        [When(@"User select option Mobiles, Computers")]
        public void WhenUserSelectOptionMobilesComputers()
        {
            amazonHomePage?.ClickMobilesComputers();
        }

        [When(@"Select option 'Software")]
        public void WhenSelectOptionSoftware()
        {
            CurrentPage = amazonHomePage?.ClickSoftware();
        }

        [Then(@"User validate the log is present under Top categories section")]
        public void ThenUserValidateTheLogIsPresentUnderTopCategoriesSection()
        {
            CurrentPage?.As<SoftwareStorePage>().VerifyTopCategories();
        }

        [When(@"user search the product Toy")]
        public void WhenUserSearchTheProductToy()
        {
            CurrentPage = amazonHomePage?.GetToyPage();
        }

        [When(@"User select the first produc")]
        public void WhenUserSelectTheFirstProduc()
        {
            CurrentPage?.As<ToyPage>().ClickFirstToyItem();
            _productName = CurrentPage?.As<ToyPage>().GetToyDetailName();
        }

        [When(@"User Click on Add Cart")]
        public void WhenUserClickOnAddCart()
        {
            CurrentPage?.As<ToyPage>().ClickOnAddCart();
        }

        [Then(@"select shopping cart and validate if added item is present in the shopping cart")]
        public void ThenSelectShoppingCartAndValidateIfAddedItemIsPresentInTheShoppingCart()
        {
            CurrentPage = amazonHomePage?.ClickOnCart();
            if (_productName != null)
                CurrentPage?.As<ShoppingCartPage>().ValidateAddedProductInCart(_productName);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver?.Quit();
        }
    }
}
