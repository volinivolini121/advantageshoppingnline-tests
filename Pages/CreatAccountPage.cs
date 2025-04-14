using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;



namespace advantageshoppingonline.Pages
{
    public class CreateAccountPage
    {
        private IWebDriver driver;
        public CreateAccountPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By userIcon = By.XPath("//a[@id='menuUserLink']");
        private By creatNewAccount = By.XPath("//a[@class='create-new-account ng-scope' and @translate='CREATE_NEW_ACCOUNT']");
        private By usernameRegisterPage = By.Name("usernameRegisterPage");
        private By emailRegisterPage = By.Name("emailRegisterPage");
        private By passwordRegisterPage = By.Name("passwordRegisterPage");
        private By confirm_passwordRegisterPage = By.Name("confirm_passwordRegisterPage");
        private By emailFieldErrorLabel = By.CssSelector("label.invalid:contains('Password field is required')");
        private By usernameFieldErrorLabel = By.CssSelector("label.invalid:contains('Username field is required')");
        private By passwordFieldErrorLabel = By.CssSelector("label.invalid:contains('Password field is required')");
        private By confirmPasswordFieldErrorLabel = By.CssSelector("label.invalid:contains(Confirm password field is required')");


        public void GoToAdvantageWebsite()
        {
            driver.Navigate().GoToUrl("https://www.advantageonlineshopping.com/");
            Thread.Sleep(2000);

        }

        public void SelectUserIcon()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".loader")));
            IWebElement userIconElement = wait.Until(ExpectedConditions.ElementToBeClickable(userIcon));
            userIconElement.Click();

        }



        public void SelectCreateNewAccount()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".loader")));
            IWebElement createAccountButton = wait.Until(ExpectedConditions.ElementIsVisible(creatNewAccount));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", createAccountButton);
            wait.Until(ExpectedConditions.ElementToBeClickable(creatNewAccount));
            createAccountButton.Click();

        }

        public CreateAccountPage ClickIntoAndOutOfMandatoryFields()
        {
            var mandatoryFields = new List<By>
                {
                    usernameRegisterPage,
                    emailRegisterPage,
                    passwordRegisterPage,
                    confirm_passwordRegisterPage
                };

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            foreach (var field in mandatoryFields)
            {
                try
                {
                    IWebElement fieldElement = wait.Until(ExpectedConditions.ElementIsVisible(field));
                    fieldElement.Click();
                    fieldElement.SendKeys(Keys.Tab);
                }
                catch (WebDriverTimeoutException)
                {
                    Assert.Fail($"The mandatory '{field}' could not be located .");
                }
            }
            return new CreateAccountPage(driver);
        }

        public CreateAccountPage EnterUserName(string username)
        {
            IWebElement userNameInput = driver.FindElement(usernameRegisterPage);
            userNameInput.Clear();
            userNameInput.SendKeys(username);
            return this;
        }

        public CreateAccountPage EnterEmail(string email)
        {
            IWebElement emailInput = driver.FindElement(emailRegisterPage);
            emailInput.Clear();
            emailInput.SendKeys(email);
            return this;
        }

        public CreateAccountPage EnterPassword(string password)
        {
            IWebElement passwordInput = driver.FindElement(passwordRegisterPage);
            passwordInput.Clear();
            passwordInput.SendKeys(password);
            return this;
        }

        public CreateAccountPage EnterConfirmPassword(string confirmPassword)
        {
            IWebElement confirmPasswordInput = driver.FindElement(confirm_passwordRegisterPage);
            confirmPasswordInput.Clear();
            confirmPasswordInput.SendKeys(confirmPassword);
            return this;
        }

        public string GetUsernameErrorMessage()
        {

            IWebElement usernameErrorLabel = driver.FindElement(usernameFieldErrorLabel);
            return usernameErrorLabel.Text;
        }

        public string GetEmailErrorMessage()
        {
            IWebElement emailErrorLabel = driver.FindElement(emailFieldErrorLabel);
            return emailErrorLabel.Text;
        }

        public string GetPasswordErrorMessage()
        {
            IWebElement passwordErrorLabel = driver.FindElement(passwordFieldErrorLabel);
            return passwordErrorLabel.Text;
        }

        public string GetConfirmPasswordErrorMessage()
        {
            IWebElement confirmPasswordErrorLabel = driver.FindElement(confirmPasswordFieldErrorLabel);
            return confirmPasswordErrorLabel.Text;
        }

        public CreateAccountPage VerifyErrorMessages()
        {
            string[] errorMessageIds = {
        "usernameError",
        "emailError",
        "passwordError",
        "confirmPasswordError"
         };

            foreach (var errorId in errorMessageIds)
            {
                var errorElement = driver.FindElements(By.Id(errorId));
                Assert.IsTrue(errorElement.Count == 0 || !errorElement[0].Displayed, $"Error message for '{errorId}' is still displayed!");
            }

            return this;
        }
    }
}