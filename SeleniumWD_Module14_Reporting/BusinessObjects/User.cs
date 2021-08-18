namespace SeleniumWebDriver.BusinessObjects
{
    public class User
    {
        private readonly string _login;
        private readonly string _password;

        public string[] DataUser { get; private set; }

        public User (string login, string password)
        {
            this._login = login;
            this._password = password;
            DataUser = new[] { this._login, this._password };
        }

        public static User GetDefaultUser()
        {
            return new User("Snieczka", "2020327abcd");
        }
    }
}
