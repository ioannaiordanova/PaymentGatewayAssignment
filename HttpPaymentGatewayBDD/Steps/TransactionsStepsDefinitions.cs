using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace HttpPaymentGatewayBDD
{
    [Binding]
    public class TransactionsStepsDefinitions
    {
        TestService _test;

        [Given(@"I am (.*)authorized")]
        public void GivenIAmAuthorized(string not)
        {
            if (not.Contains("not"))
                _test = new TestService(false);
            else
                _test = new TestService(true);
        }


        [When(@"I submit my payment details:")]
        [System.Obsolete]
        public void WhenIEnterMyCardDetailsAndTryToMakeASale(Table requestDetails)
        {
            _test.ValidTransaction(requestDetails.CreateInstance<PaymentDetails>());
        }

        [When(@"I post my correct payment details:")]
        public void WhenIPostMyCorrectPaymentDetails(Table requestDetails)
        {
            _test.SendTransaction(requestDetails.CreateInstance<PaymentDetails>());
        }


        [Then(@"I have the status code (.*)")]
        public void ThenMyTrnsactionIs(int statusCode)
        {
            _test.AssertStatusCode(statusCode);
        }

        [When(@"I try to void my previously successfull transaction")]
        public void WhenITryToVoidMyPreviouslySuccessfullTransaction()
        {
            _test.VoidTransaction();
        }

        [When(@"I try to void my previous void transaction")]
        public void WhenITryToVoidMyPreviousVoidTransaction()
        {
            _test.VoidToVoidTransaction();
        }

        [When(@"I try to void my non-existent payment transaction:")]
        public void WhenITryToVoidMyNonExistingTransaction(Table requestDetails)
        {
            _test.SendTransaction(requestDetails.CreateInstance<PaymentDetails>());
        }
    }
}
