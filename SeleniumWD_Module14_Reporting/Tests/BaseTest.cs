using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SeleniumWebDriver.BusinessObjects;
using SeleniumWebDriver.Logs;
using System.Diagnostics;
using System.IO;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace SeleniumWebDriver
{
    [TestFixture]
    public abstract class BaseTest : Browser
    {
        private readonly string _screenshotsDirectory;
        protected Logger Log;
        protected IWebDriver driver;
        protected string baseUrl;
        protected string composeLinkText = "Написать письмо";
        protected readonly User user = User.GetDefaultUser();
        protected readonly CommonEmailInstance yandexEmailInstance = (CommonEmailInstance)new YandexEmailInstance().GetInstanceWithRandomSubjectAndContent();
        protected readonly CommonEmailInstance gmailEmailInstance = (CommonEmailInstance)new GmailEmailInstance().GetInstanceWithRandomSubjectAndContent();

        public BaseTest()
        {
            this.Log = LoggerManager.GetLogger(this.GetType());
            this._screenshotsDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Screenshots");
        }

        [SetUp]
        public void TestSetup()
        {
            this.driver = GetDriver();

            Log.Info("Open Yandex Website");
            this.baseUrl = YandexHomePage.url;

            NavigateTo(this.baseUrl);

            Log.Info("Maximize Window");
            WindowMaximize();

            Log.Info("Open Yandex Website");
            var homePage = new YandexHomePage();

            Log.Info("Login to Yandex");
            homePage.ClickOnLoginButton().Login(user).WaitForComposeLinkIsVisible();
        }

        [TearDown]
        public void TakeScreenshotOfError()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                this.Log.Error(
                    "Test failed. Screenshot saved at: "
                    + Browser.TakeScreenshot(this._screenshotsDirectory, TestContext.CurrentContext.Test.Name));
            }
            Quit();
        }

        public void CreateReport()
        {
            string fullName = Directory.GetCurrentDirectory() + @"\ReportUnit.exe";
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = fullName;
            Log.Info("Executing TestReport: " + fullName);
            info.Arguments = @"C:\Users\Tatsiana_Barabanava\source\repos\SeleniumWD_Module14_Reporting\bin\Debug\net48\TestResult.xml C:\Users\Tatsiana_Barabanava\source\repos\SeleniumWD_Module14_Reporting\ResultReport\TestResults.html";
            Process.Start(info);
        }

        [OneTimeTearDown]
        public void CleanUp() 
        {
            CreateReport();
        }
    }
}