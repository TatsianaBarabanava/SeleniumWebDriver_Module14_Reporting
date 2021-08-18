using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Configuration;

namespace SeleniumWebDriver
{
    public class BrowserFactory
    {
        public static IWebDriver GetDriver(BrowserType type, int timeOutSec)
        {
            IWebDriver driver = null;

            switch (type)
            {
                case BrowserType.Chrome:
                    {
                        var service = ChromeDriverService.CreateDefaultService();
                        var option = new ChromeOptions();
                        option.AddArgument("disable-infobars");
                        driver = new ChromeDriver(service, option, TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }
                case BrowserType.Firefox:
                    {
                        var service = FirefoxDriverService.CreateDefaultService();
                        var options = new FirefoxOptions();
                        driver = new FirefoxDriver(service, options, TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }
                case BrowserType.RemoteFirefox:
                    {
                        var capability = new DesiredCapabilities();
                        capability.SetCapability(CapabilityType.BrowserName, BrowserType.Firefox.ToString());
                        capability.SetCapability(CapabilityType.PlatformName, new Platform(PlatformType.Windows));
                        driver = new RemoteWebDriver(new Uri(ConfigurationManager.AppSettings.Get("URI")), capability);
                        break;
                    }
                case BrowserType.RemoteChrome:
                    {
                        var capability = new DesiredCapabilities();
                        capability.SetCapability(CapabilityType.BrowserName, BrowserType.Chrome.ToString());
                        capability.SetCapability(CapabilityType.PlatformName, new Platform(PlatformType.Windows));
                        driver = new RemoteWebDriver(new Uri(ConfigurationManager.AppSettings.Get("URI")), capability);
                        break;
                    }
            }
            return driver;
        }
    }
}