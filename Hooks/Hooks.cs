using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace advantageshoppingonline.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly Reqnroll.BoDi.IObjectContainer _container;

        public Hooks(Reqnroll.BoDi.IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario("@LOG001")]
        public void BeforeScenarioWithTag()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            // No changes needed here
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();
            if (driver != null) // Added missing parentheses
            {
                driver.Quit();
            }
        }
    }
}
