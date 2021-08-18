using System;
using OpenQA.Selenium;

namespace SeleniumWebDriver
{
    public class SendPage : BaseMailPage
    {
        public static readonly String url = "https://mail.yandex.by/u2709/?uid=1437990165#sent";
        private static readonly By sendMail = By.XPath("//span[text()='Закрепить']");

        public SendPage() : base(sendMail, "Send Mail") 
        { 
        }
    }
}