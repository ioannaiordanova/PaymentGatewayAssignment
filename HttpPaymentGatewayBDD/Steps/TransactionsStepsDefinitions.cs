using NUnit.Framework;
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
            Assert.AreEqual(statusCode, (int)_test.TransactionRequest.Response.StatusCode);
        }

        [When(@"I try to void my previous (.*) transaction")]
        public void WhenITryToVoidMyPreviousTransaction(string prevoiusTransactionType)
        {
            _test.VoidPreviousTransaction(prevoiusTransactionType);
        }

        [When(@"I try to void my non-existent payment transaction with ref id (.*)")]
        public void WhenITryToVoidMyNonExistingTransaction(string refId)
        {
            _test.VoidOfNonExistentTransaction(refId);
        }
    }
}
