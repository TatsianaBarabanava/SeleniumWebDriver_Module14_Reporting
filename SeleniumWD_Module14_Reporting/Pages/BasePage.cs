using OpenQA.Selenium;

namespace SeleniumWebDriver
{
    public abstract class BasePage
    {
        protected By titleLocator;
        protected string title;
        public static string titleForm;

        protected BasePage(By TitleLocator, string Title)
        {
            titleLocator = TitleLocator;
            title = titleForm = Title;
            WaitIsOpen();
        }

        public void WaitIsOpen()
        {
            var label = new BaseElement(titleLocator, title);
            label.WaitForIsVisible();
        }
    }
}