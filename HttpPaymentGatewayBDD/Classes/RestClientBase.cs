using Microsoft.Extensions.Configuration;
using RestSharp;

namespace HttpPaymentGatewayBDD
{
    class RestClientBase: RestClient
    {
        public static IConfigurationRoot Config { get; set; }
        bool IsAuthorized;
        public  RestClientBase(bool auth) : base(Config["Uri"])
        {    
            IsAuthorized = auth;
            AddHeaders();
        }

        private void AddHeaders()
        {
            this.AddDefaultHeader("Content-Type", Config["Content-Type"]);
            this.AddDefaultHeader("Authorization", "Basic " + getAuthToken());
        }

        private string getAuthToken() 
        {
           return  IsAuthorized ? Config["AuthToken"] : Helper.GenerateFalseToken();
        }

    }
}
