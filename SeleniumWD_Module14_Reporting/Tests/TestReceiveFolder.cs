using NUnit.Framework;

namespace SeleniumWebDriver
{
    [TestFixture]
    public class TestReceiveFolder : BaseTest
    {
        [Test]
        public void ReceiveFolder()
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

            this.Log.Info("Clicking on Recipient Field");
            draftPage.ClickOnRecepientField(yandexEmailInstance.Email);

            this.Log.Info("Clicking on Send Button");
            draftPage.ClickOnSendButtonWithActions();

            this.Log.Info("Escaping the pop-up Window");
            Browser.PressEscape();

            this.Log.Info("Clicking on Inbox folder");
            var receivePage = draftPage.ClickOnInboxFolder();

            this.Log.Info("Refreshing the page");
            Browser.RefreshPage();

            //Assert
            var actualSender = receivePage.GetTextFromRecepientField(yandexEmailInstance.Email); 
            var actualSubject = receivePage.GetTextFromMailTopicField();
            var actualContent = receivePage.GetTextFromContentField();
            Assert.AreEqual(yandexEmailInstance.Sender, actualSender, "Sender field has an invalid value");
            Assert.IsTrue(actualSubject.Contains(yandexEmailInstance.Subject), "Email Subject field has an invalid value");
            Assert.AreEqual(receivePage.GetTextFromContentField(), actualContent, "Content field has an invalid value");
        }
    }
}