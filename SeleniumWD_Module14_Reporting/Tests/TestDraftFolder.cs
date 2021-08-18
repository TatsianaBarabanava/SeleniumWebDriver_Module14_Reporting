using NUnit.Framework;

namespace SeleniumWebDriver
{
    [TestFixture]
    public class TestDraftFolder : BaseTest
    {

         [Test]
        public void DraftContent()
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

            this.Log.Info("Waiting until Resend Link is visible");
            mailPage.resendLink.WaitForIsVisible();

            this.Log.Info("Clicking on Draft Link");
            var draftPage = mailPage.ClickOnDraftLink();

            //Assert
            var actualSender = draftPage.GetTextFromRecepientField(gmailEmailInstance.Email);
            var actualSubject = draftPage.GetTextFromMailTopicField();
            var actualContent = draftPage.GetTextFromContentField();
            Assert.AreEqual(gmailEmailInstance.Email, actualSender, "Sender field has an invalid value");
            Assert.AreEqual(gmailEmailInstance.Subject, actualSubject, "Email Subject field has an invalid value");
            Assert.AreEqual(draftPage.GetTextFromContentField(), actualContent, "Content field has an invalid value");
        }
    }
}