using SeleniumWebDriver.BusinessObjects.Emails;

namespace SeleniumWebDriver.BusinessObjects
{
    public class GmailEmailInstance : CommonEmailInstance
    {
        public GmailEmailInstance()
        {
        }

        public GmailEmailInstance(string sender, string email, string subject, string content)
        {
            this._sender = sender;
            this._email = email;
            this._subject = subject;
            this._content = content;
        }

        public override BaseEmailInstance GetInstanceWithRandomSubjectAndContent()
        {
            return (CommonEmailInstance) GetInstanceWithRandomSubjectAndContent("Tatsiana Barabanava", "snieczka@gmail.com");
        }
    }
}
