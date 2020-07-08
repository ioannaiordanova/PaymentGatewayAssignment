using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace HttpPaymentGatewayBDD
{
    [Binding]
    public class TransactionsStepsDefinitions
    {
        ServiceDriver _test;

        [Given(@"I am (.*)authorized")]
        public void GivenIAmAuthorized(string not)
        {
            _test = new ServiceDriver(!not.Contains("not"));
        }


        [When(@"I submit my payment details:")]
        [System.Obsolete]
        public void WhenIEnterMyCardDetailsAndTryToMakeASale(Table requestDetails)
        {
            _test.SalesTransaction(requestDetails.CreateInstance<PaymentDetails>());
        }


        [Then(@"I have the status code (.*)")]
        public void ThenMyTrnsactionIs(int statusCode)
        {
            _test.AssertStatusCode(statusCode);
        }

        [When(@"I try to void my previously successfull transaction")]
        public void WhenITryToVoidMyPreviouslySuccessfullTransaction()
        {
            _test.VoidValidTransaction();
        }

        [When(@"I try to void my previous void transaction")]
        public void WhenITryToVoidMyPreviousVoidTransaction()
        {
            _test.VoidToVoidTransaction();
        }

        [When(@"I try to void my non-existent payment transaction:")]
        public void WhenITryToVoidMyNonExistingTransaction(Table requestDetails)
        {
            _test.TransactVoid(requestDetails.CreateInstance<PaymentDetails>());
        }
    }
}
