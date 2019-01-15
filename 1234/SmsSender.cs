using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Authorization
{
    public class SmsSender
    {
        private int _key;

        public void SetKey()
        {
            Random randomizer = new Random();
            _key = randomizer.Next(1000, 10000);
        }

        public bool IsTrueKey(int key)
        {
            if (_key == key)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SendSMS(User user, string userKey)
        {
            int tempData;
            if (int.TryParse(userKey, out tempData))
            {              
                if (IsTrueKey(int.Parse(userKey)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                const string accountSid = "ACcd06636a85930cc073b116adc5b32c17";
                const string authToken = "4e445ebaef2a50110aace507774b08d9";
                TwilioClient.Init(accountSid, authToken);
                var message = MessageResource.Create(
                    body: "" + _key,
                    from: new Twilio.Types.PhoneNumber("+14783248627"),
                    to: new Twilio.Types.PhoneNumber("" + user.GetNumber())
                );
                return false;
            }            
        }
    }
}
