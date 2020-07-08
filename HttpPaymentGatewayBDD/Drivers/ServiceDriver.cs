using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace HttpPaymentGatewayBDD
{
    public class ServiceDriver
    {
        private static string ValidTransactionRef, VoidTransactionRef;
        public static IConfigurationRoot Config;
        TransactionRequestBase TransactionRequest;

        public ServiceDriver(bool auth)
        {
            TransactionRequest = new TransactionRequestBase(auth);
        }

        private void SetValidTransactionRef()
        {
            ValidTransactionRef = TransactionRequest.getResponseRefId();
        }

        public void TransactSale(PaymentDetails _paymentDetailsModel)
        {
            _paymentDetailsModel.TransactionType = Config["Sale"];
            TransactionRequest.SendPaymentDetails(Config["Query"],_paymentDetailsModel);
        }

        public void TransactVoid(PaymentDetails _paymentDetailsModel)
        {
            _paymentDetailsModel.TransactionType = Config["Void"];
            TransactionRequest.SendPaymentDetails(Config["Query"],_paymentDetailsModel);
        }

        public void SalesTransaction(PaymentDetails _PaymentDetailsModel)
        {
            TransactSale(_PaymentDetailsModel);
            if (TransactionRequest.IfIsResponseIsSuccessful) SetValidTransactionRef();            
        }


        public void AssertStatusCode(int code)
        {
            Assert.AreEqual(code, (int)TransactionRequest.Response.StatusCode);
        }

        public void VoidOfNonExistentTransaction(string refId)
        {
            TransactVoid(new PaymentDetails() { ReferenceId = refId });
        }

        public void VoidValidTransaction()
        {
            TransactVoid(new PaymentDetails() { ReferenceId = ValidTransactionRef });
            VoidTransactionRef = TransactionRequest.getResponseRefId();
        }

        public void VoidToVoidTransaction()
        {
            TransactVoid(new PaymentDetails() { ReferenceId = VoidTransactionRef });
        }

    }
}