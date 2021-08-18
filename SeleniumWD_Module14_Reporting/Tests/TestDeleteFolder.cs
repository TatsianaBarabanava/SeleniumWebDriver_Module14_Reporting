using NUnit.Framework;

namespace SeleniumWebDriver
{
    [TestFixture]
    public class TestDeleteFolder : BaseTest
    {

        [Test]
        public void DeleteFolder()
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

            this.Log.Info("Selecting Email by Number");
            draftPage.SelectEmailByNumber(0, gmailEmailInstance.Email);

            this.Log.Info("Clicking on Delete button");
            draftPage.deleteButton.Click();

            this.Log.Info("Compose Email with Random Content");
            var deletePage = draftPage.ClickOnDeleteFolder();

            //Assert
            var actualSender = deletePage.GetTextFromRecepientField(yandexEmailInstance.Email);
            var actualSubject = deletePage.GetTextFromMailTopicField();
            var actualContent = deletePage.GetTextFromContentField();
            Assert.AreEqual(gmailEmailInstance.Sender, actualSender, "Sender field has an invalid value");
            Assert.AreEqual(gmailEmailInstance.Subject, actualSubject, "Email Subject field has an invalid value");
            Assert.AreEqual(deletePage.GetTextFromContentField(), actualContent,  "Content field has an invalid value");
        }
    }
}