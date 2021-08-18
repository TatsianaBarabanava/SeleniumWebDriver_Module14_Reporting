using NUnit.Framework;

namespace SeleniumWebDriver
{
    [TestFixture]
    public class TestSendEmail : BaseTest
    {
       
        [Test]
        public void SendEmail()
        {
            //Arrange
            this.Log.Debug("Going to Yandex Home Page");
            var homePage = new YandexHomePage();

            this.Log.Info("Clicking on Compose Link");
            homePage.ClickOnComposeLink();

            this.Log.Info("Switching to Mail Page Window");
            var mailPage = homePage.SwitchToMailPageWindow();

            //Act
            this.Log.Info("Composing Email with Random Content");
            mailPage.ComposeEmailWithRandomContent(yandexEmailInstance);

            this.Log.Info("Escaping the pop-up Window");
            Browser.PressEscape();

            this.Log.Info("Clicking on Draft Link");
            var draftPage = mailPage.ClickOnDraftLink();

            this.Log.Info("Counting the actual number of Emails in Draft folder");
            int actualNumberOfDrafts = draftPage.CountEmails(gmailEmailInstance.Email);

            this.Log.Info("Clicking on Recipient Field");
            draftPage.ClickOnRecepientField(gmailEmailInstance.Email);

            this.Log.Info("Clicking on Send button");
            draftPage.ClickOnSendButtonWithActions();

            this.Log.Info("Escaping the pop-up Window");
            Browser.PressEscape();

            this.Log.Info("Refreshing the page");
            Browser.JSRefreshPage();

            //Assert
            bool expectedNumberOfDrafts = draftPage.CountEmails(gmailEmailInstance.Email) == (actualNumberOfDrafts - 1);
            Assert.IsTrue(expectedNumberOfDrafts, "The Number Of Letters In Mail Box is different from Expected Value");
        }
    }
}