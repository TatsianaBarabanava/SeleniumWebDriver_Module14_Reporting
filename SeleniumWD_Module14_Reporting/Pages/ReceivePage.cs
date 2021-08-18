using System;
using OpenQA.Selenium;

namespace SeleniumWebDriver
{
    public class ReceivePage : BaseMailPage
    {
        public static readonly String url = "https://mail.yandex.by/u2709/?uid=1437990165#inbox";
        private static readonly By receiveMail = By.XPath("//span[text()='Закрепить']");

        public ReceivePage() : base(receiveMail, "Receive Mail") 
        { 
        }
    }
}