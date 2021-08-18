using System;
using OpenQA.Selenium;
using SeleniumWebDriver.BusinessObjects;

namespace SeleniumWebDriver
{
    public class MailPage : BaseMailPage
    {
        public static readonly String url = "https://mail.yandex.by/u2709/?uid=1437990165#inbox";
        private static readonly By newMail = By.XPath("//span[text()='Новое письмо']");
        private static readonly BaseElement recepientField = new BaseElement(By.XPath("//div[@class='composeYabbles']"));
        private static readonly BaseElement topicField = new BaseElement(By.XPath("//input[contains(@class,'composeTextField')]"));
        private static readonly BaseElement mailContentField = new BaseElement(By.XPath("//div[@role='textbox']"));

        public MailPage() : base(newMail, "New Mail") 
        { 
        }

        public void TypeRecepient(string Recepient)
        {
            recepientField.SendKeys(Recepient);
        }

        public void ClickOnTypeTopicField()
        {
            topicField.Click();
        }

        public void TypeTopic(string Topic)
        {
            topicField.SendKeys(Topic);
        }

        public void ClickOnMailContentField()
        {
            mailContentField.Click();
        }

        public void TypeMailContent(string Content)
        {
            mailContentField.SendKeys(Content);
        }

        public void WaitForRecepientFieldIsVisible()
        {
            recepientField.WaitForIsVisible();
        }

        public void ComposeEmail(string Recepient, string Topic, string Content)
        {
            TypeRecepient(Recepient);
            ClickOnTypeTopicField();
            TypeTopic(Topic);
            ClickOnMailContentField();
            TypeMailContent(Content);
        }

        public void ComposeEmailWithRandomContent(CommonEmailInstance emailInstance)
        {
            WaitForRecepientFieldIsVisible();
            ComposeEmail(emailInstance.Email, emailInstance.Subject, emailInstance.Content);
        }

        public string GetRandomContent()
        {
            return mailContentField.GetText();
        }
    }
}