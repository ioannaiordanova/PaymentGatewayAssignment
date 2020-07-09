using AutoFixture;

namespace HttpPaymentGatewayBDD
{
    public static class Helper
    {
        public static string GenerateFalseToken()
        {
            var fixture = new Fixture();       

            return RestClientBase.Config["AuthToken"].Substring(0, 35).Replace("0","1") + fixture.Create<string>().Substring(0, 5);
        }

        public static bool IsVoid(this string name)
        {
            return name.Equals(RestClientBase.Config["Void"]);
        }
    }
}
