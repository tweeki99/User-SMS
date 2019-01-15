using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Authorization
{
    public class User
    {
        private string _login;
        private string _password;
        private string _email;
        private string _number;       

        public string GetLogin()
        {
            return _login;
        }

        public void SetLogin(string login)
        {
            _login = login;
        }

        public void SetPassword(string password)
        {
            _password = password;
        }

        public void SetNumber(string number)
        {
            _number = number;
        }

        public string GetNumber()
        {
            return _number;
        }

        public bool ReadEmail(string email)
        {              
            if (email.Contains("@") && email.Contains("."))
            {

                _email = email;
                return true;
            }
            else
            {
                return false;
            }
        }        
    }
}

