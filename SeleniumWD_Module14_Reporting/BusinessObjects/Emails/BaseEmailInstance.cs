using SeleniumWebDriver.Utils;

namespace SeleniumWebDriver.BusinessObjects.Emails
{
    public abstract class BaseEmailInstance
    {
        protected string _sender;
        protected string _email;
        protected string _subject;
        protected string _content;
        protected static RandomUtil _randomUtil = RandomUtil.Instance;

        public string Sender => _sender;

        public string Email => _email;

        public string Subject => _subject;

        public string Content => _content;

        public abstract BaseEmailInstance GetInstanceWithRandomSubjectAndContent(string sender, string email);

        public abstract BaseEmailInstance GetInstanceWithRandomSubjectAndContent();
    }
      
}
