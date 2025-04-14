using advantageshoppingonline.Pages;
using NUnit.Framework;
using OpenQA.Selenium;


namespace advantageshoppingonline.StepDefinitions
{
    [Binding]
    public class CreateAccountSteps
    {
        private readonly IWebDriver driver;
        CreateAccountPage createAccountPage;

        public CreateAccountSteps(IWebDriver driver)
        {
            this.driver = driver;
            this.createAccountPage = new CreateAccountPage(driver);
        }

        [Given("I navigate to advantage online shopping website")]
        public void GivenINavigateToAdvantageOnlineShoppingWebsite()
        {
            createAccountPage.GoToAdvantageWebsite();
        }

        [When("I click on user icon to open the register popup")]
        public void WhenIClickOnUserIconToOpenTheRegisterPopup()
        {
            createAccountPage.SelectUserIcon();
        }

        [When(@"I click create new account")]
        public void WhenIClickCreateNewAccount()
        {
            createAccountPage.SelectCreateNewAccount();

        }

        [When("I click into and out of mandatory fields")]
        public void WhenIClickIntoAndOutOfMandatoryFields()
        {
            createAccountPage.ClickIntoAndOutOfMandatoryFields();

        }

        [Then("I verify error messages display correctly")]
        public CreateAccountSteps ThenIVerifyErrorMessagesDisplayCorrectly()
        {
            Assert.IsTrue(driver.PageSource.Contains("Username field is required"));
            Assert.IsTrue(driver.PageSource.Contains("Email field is required"));
            Assert.IsTrue(driver.PageSource.Contains("Password field is required"));
            Assert.IsTrue(driver.PageSource.Contains("Confirm password field is required"));
            return this;
        }

        [When("I enter valid data into all mandatory fields")]
        public CreateAccountSteps WhenIEnterValidDataIntoAllMandatoryFields()
        {
            createAccountPage.EnterUserName("onlineuser");
            createAccountPage.EnterEmail("onlineuser@example.com");
            createAccountPage.EnterPassword("Onlineuser@9");
            createAccountPage.EnterConfirmPassword("Onlineuser@9");
            return this;
        }

        [Then("I verify that all error messages are cleared")]
        public void ThenIVerifyThatAllErrorMessagesAreCleared()
        {
            createAccountPage.VerifyErrorMessages();

        }
    }
}
