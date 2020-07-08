using AutoFixture;

namespace HttpPaymentGatewayBDD
{
    class Helper
    {

        public static string GenerateFalseToken()
        {
            var fixture = new Fixture();
            string _addition = fixture.Create<string>().Substring(0, 5);
            string FalseAuth = TestService.config["AuthToken"].Substring(0, 35) + _addition;
            FalseAuth = FalseAuth.Replace("0", "1");
           
            return FalseAuth;
        }

    }
}
