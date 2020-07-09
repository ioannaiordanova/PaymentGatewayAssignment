using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace HttpPaymentGatewayBDD
{
    [Binding]
    class Hooks
    {
        [BeforeFeature]
        public static void BeforeFeature()
        {
            RestClientBase.Config = new ConfigurationBuilder().AddJsonFile("conf.json").Build();
        }
    }
}
