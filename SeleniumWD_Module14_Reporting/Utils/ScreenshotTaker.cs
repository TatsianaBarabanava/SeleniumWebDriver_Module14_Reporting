using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SeleniumWebDriver.Utils
{
    public static class ScreenshotTaker
    {
        private static IWebDriver Browser
        {

            get { return SeleniumWebDriver.Browser.GetDriver(); }
        }

        public static string TakeScreenshot(string directory, string testName)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string screenshotFileName =
                string.Format(
                    "{0}_{1}.{2}",
                    testName,
                    DateTime.Now.ToString("dd.MM.yyyy_HH.mm.ss"),
                    ImageFormat.Jpeg.ToString().ToLowerInvariant())
                      .Replace("\"", string.Empty)
                      .Replace("\\", string.Empty);

            string screenshotSaveFullPath = Path.Combine(directory, screenshotFileName);

            using (Image screenshot = Image.FromStream(new MemoryStream(Browser.TakeScreenshot().AsByteArray)))
            {
                screenshot.Save(screenshotSaveFullPath);
            }

            return screenshotSaveFullPath;
        }
    }
}
