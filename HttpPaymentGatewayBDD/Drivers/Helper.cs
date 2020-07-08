using AutoFixture;

namespace HttpPaymentGatewayBDD
{
    class Helper
    {
        public static string GenerateFalseToken()
        {
            var fixture = new Fixture();       

            return ServiceDriver.Config["AuthToken"].Substring(0, 35).Replace("0","1") + fixture.Create<string>().Substring(0, 5);
        }
    }
}
