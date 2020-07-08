using AutoFixture;

namespace HttpPaymentGatewayBDD
{
    class Helper
    {
        public static string GenerateFalseToken()
        {
            var fixture = new Fixture();
            string _token = fixture.Create<string>();
            string _addition = fixture.Create<string>().Substring(0, 4);
            string FalseAuth = _token + _addition;
            FalseAuth = FalseAuth.Replace("-", "1");
            return FalseAuth;
        }

    }
}
