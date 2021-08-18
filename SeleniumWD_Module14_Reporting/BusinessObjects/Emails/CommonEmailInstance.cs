using SeleniumWebDriver.BusinessObjects.Emails;

namespace SeleniumWebDriver.BusinessObjects
{
    public class CommonEmailInstance : BaseEmailInstance
    {
        public CommonEmailInstance()
        {
        }

        public CommonEmailInstance(string sender, string email, string subject, string content)
        {
            this._sender = sender;
            this._email = email;
            this._subject = subject;
            this._content = content;
        }

        public override BaseEmailInstance GetInstanceWithRandomSubjectAndContent(string sender, string email)
        {
            string randomSubject = _randomUtil.GetRandomText(5);
            string randomContent = _randomUtil.GetRandomText(10);

            return new CommonEmailInstance(sender, email, randomSubject, randomContent);
        }

        public override BaseEmailInstance GetInstanceWithRandomSubjectAndContent()
        {
            string randomEmail = $"{_randomUtil.GetRandomText(5)}@mail.ru";
            string randomSender = $"{_randomUtil.GetRandomText(5)} {_randomUtil.GetRandomText(8)}";

            return  GetInstanceWithRandomSubjectAndContent(randomSender, randomEmail);
        }
    }
}
