using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace HttpPaymentGatewayBDD
{
    [Binding]
    public class TransactionsStepsDefinitions
    {
        Tests _test;

        [Given(@"I am (.*)authorized")]
        public void GivenIAmAuthorized(string not)
        {
            if (not.Equals("not "))
                _test = new Tests(false);
            else
                _test = new Tests(true);
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


        [Then(@"I had the status code (.*)")]
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
