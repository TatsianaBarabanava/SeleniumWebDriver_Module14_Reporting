using NUnit.Framework;

namespace SeleniumWebDriver
{
    [TestFixture]
    public class TestLogin : BaseTest
    {

        [Test]
        public void Login()
        {
            //Arrange
            this.Log.Debug("Going to Yandex Home Page");
            var homePage = new YandexHomePage();

            this.Log.Info("Getting text from Compose Link");
            var actualExpression = homePage.GetTextFromComposeLink();

            //Assert
            Assert.AreEqual(composeLinkText, actualExpression, "You are on the wrong page");
        }
    }
}