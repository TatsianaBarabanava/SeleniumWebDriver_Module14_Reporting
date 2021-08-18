using System;
using OpenQA.Selenium;

namespace SeleniumWebDriver
{
    public class DeletePage : BaseMailPage
    {
        public static readonly String url = "https://mail.yandex.by/u2709/?uid=1437990165#trash";
        private static readonly By deleteMail = By.XPath("//span[text()='Отключить рассылки']");

        public DeletePage() : base(deleteMail, "Delete Mail") 
        { 
        }
    }
}