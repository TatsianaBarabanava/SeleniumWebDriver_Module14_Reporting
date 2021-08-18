using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Drawing;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium.Interactions;

namespace SeleniumWebDriver
{
    public class BaseElement : IWebElement
    {
        protected string _name;
        protected By _locator;
        protected IWebElement element;

        public BaseElement (By locator, string name)
        {
            _locator = locator;
            _name = name == "" ? GetText() : name;
        }

        public BaseElement(By locator)
        {
            _locator = locator;
        }

        public string GetText()
        {
            WaitForIsVisible();

            return GetElement().Text;
        }

        public IWebElement GetElement()
        { 
            try
            {
                element = Browser.GetDriver().FindElement(_locator);
            }
            catch (Exception)
            {
                throw;
            }
            return element;
        }

        public ReadOnlyCollection<IWebElement> GetElements()
        {
            return Browser.GetDriver().FindElements(_locator);
        }

        public void WaitForIsVisible()
        {
            new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(Browser.timeoutForElement)).Until(ExpectedConditions.ElementIsVisible(_locator));
        }

        public IWebElement FindElement (By @by)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void SendKeys(string text)
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(_locator).SendKeys(text);
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }

        public void Click()
        {
            WaitForIsVisible();
            Browser.GetDriver().FindElement(_locator).Click();
        }

        public void ClickWithAction()
        {
            WaitForIsVisible();
            new Actions(Browser.GetDriver()).Click(Browser.GetDriver().FindElement(_locator)).Build().Perform();
        }

        public int Count()
        {
            this.WaitForIsVisible();

            return Browser.GetDriver().FindElements(_locator).Count();
        }

        public void JSClick()
        {
            this.WaitForIsVisible();
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.GetDriver();
            executor.ExecuteScript("arguments[0].click()", this.GetElement());
        }

        public string GetAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string TagName { get; }
        public string Text { get; }
        public bool Enabled { get; }
        public bool Selected { get; }
        public Point Location { get; }
        public Size Size { get; }
        public bool Displayed { get; }
    }
}