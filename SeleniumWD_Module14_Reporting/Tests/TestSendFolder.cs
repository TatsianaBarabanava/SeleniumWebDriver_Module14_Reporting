using NUnit.Framework;

namespace SeleniumWebDriver
{
    [TestFixture]
    public class TestSendFolder : BaseTest
    {
       
        [Test]
        public void SendFolder()
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
            mailPage.ComposeEmailWithRandomContent(gmailEmailInstance);

            this.Log.Info("Escaping the pop-up Window");
            Browser.PressEscape();

            this.Log.Info("Clicking on Draft Link");
            var draftPage = mailPage.ClickOnDraftLink();

            this.Log.Info("Clicking on Recipient Field");
            draftPage.ClickOnRecepientField(gmailEmailInstance.Email);

            this.Log.Info("Clicking on Send button");
            draftPage.ClickOnSendButtonWithActions();

            this.Log.Info("Escaping the pop-up Window");
            Browser.PressEscape();

            this.Log.Info("Clicking on Send folder");
            var sendPage = draftPage.ClickOnSendFolder();

            //Assert
            var actualSender = sendPage.GetTextFromRecepientField(gmailEmailInstance.Email);
            var actualSubject = sendPage.GetTextFromMailTopicField();
            var actualContent = sendPage.GetTextFromContentField();
            Assert.AreEqual(gmailEmailInstance.Email, actualSender, "Sender field has an invalid value");
            Assert.AreEqual(gmailEmailInstance.Subject, actualSubject, "Email Subject field has an invalid value");
            Assert.AreEqual(sendPage.GetTextFromContentField(), actualContent, "Content field has an invalid value");
        }
    }
}