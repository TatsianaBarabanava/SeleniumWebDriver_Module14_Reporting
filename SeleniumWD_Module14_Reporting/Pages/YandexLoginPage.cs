using System;
using OpenQA.Selenium;
using SeleniumWebDriver.BusinessObjects;

namespace SeleniumWebDriver
{
    public class YandexLoginPage : BaseMailPage
    {
        public static readonly String url = "https://passport.yandex.by/auth/welcome";
        private static readonly By loginFieldXpath = By.Id("passp-field-login");
        private static readonly BaseElement loginField = new BaseElement(loginFieldXpath);
        private static readonly BaseElement confirmationButton = new BaseElement(By.ClassName("Button2_view_action"));
        private static readonly BaseElement passwordField = new BaseElement(By.Id("passp-field-passwd"));

        public YandexLoginPage() : base(loginFieldXpath, "Login Field")
        { 
        }

        public void TypeLogin(string Login)
        {
            loginField.SendKeys(Login);
        }

        public void ClickConfirmationButton ()
        {
            confirmationButton.JSClick();
        }

        public void TypePassword(string Password)
        {
            passwordField.SendKeys(Password);
        }

        public YandexHomePage Login (User user)
        {
            TypeLogin(user.DataUser[0]);
            ClickConfirmationButton();
            TypePassword(user.DataUser[1]);
            ClickConfirmationButton();

            return new YandexHomePage();
        }
    }
}