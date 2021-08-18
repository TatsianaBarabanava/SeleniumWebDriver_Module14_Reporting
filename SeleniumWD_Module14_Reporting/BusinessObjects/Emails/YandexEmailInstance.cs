using Microsoft.Azure.Cosmos.Serialization.HybridRow.Schemas;
using SeleniumWebDriver.BusinessObjects.Emails;

namespace SeleniumWebDriver.BusinessObjects
{
    public class YandexEmailInstance : CommonEmailInstance
    {
        public YandexEmailInstance()
        {
        }

        public YandexEmailInstance(string sender, string email, string subject, string content)
        {
            this._sender = sender;
            this._email = email;
            this._subject = subject;
            this._content = content;
        }

        public override BaseEmailInstance GetInstanceWithRandomSubjectAndContent()
        {
            return (CommonEmailInstance) GetInstanceWithRandomSubjectAndContent("Tatsiana Barabanava", "snieczka@yandex.by");
        }
    }
}
