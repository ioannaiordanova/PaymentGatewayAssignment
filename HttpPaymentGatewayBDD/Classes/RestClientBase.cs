using RestSharp;
using System;

namespace HttpPaymentGatewayBDD
{
    class RestClientBase: RestClient
    {
        bool IsAuthorized;
        public  RestClientBase(bool auth) : base(ServiceDriver.Config["Uri"])
        {    
            IsAuthorized = auth;
            AddHeaders();
        }

        private void AddHeaders()
        {
            this.AddDefaultHeader("Content-Type", ServiceDriver.Config["Content-Type"]);
            this.AddDefaultHeader("Authorization", "Basic " + getAuthToken());
        }

        private string getAuthToken() 
        {
           return  IsAuthorized ? ServiceDriver.Config["AuthToken"] : Helper.GenerateFalseToken();
        }

    }
}
