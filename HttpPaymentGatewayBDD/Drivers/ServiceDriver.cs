using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace HttpPaymentGatewayBDD
{
    public class ServiceDriver
    {
        private static TransactionResult ValidTransaction, VoidTransaction;
        public static IConfigurationRoot Config;
        TransactionRequestBase TransactionRequest;

        public ServiceDriver(bool auth)
        {
            TransactionRequest = new TransactionRequestBase(auth);
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
            if (!TestContext.CurrentContext.Test.MethodName.Contains("Unauthorized"))
                ValidTransaction = TransactionResult.FromJson(TransactionRequest.Response.Content);
        }


        public void AssertStatusCode(int code)
        {
            Assert.AreEqual(code, (int)TransactionRequest.Response.StatusCode);
        }

        public void VoidOfNonExistentTransaction(string refId)
        {
            TransactVoid(new PaymentDetails() { ReferenceId = refId });
            VoidTransaction = TransactionResult.FromJson(TransactionRequest.Response.Content);
        }

        public void VoidValidTransaction()
        {
            TransactVoid(new PaymentDetails() { ReferenceId = ValidTransaction.UniqueId });
            VoidTransaction = TransactionResult.FromJson(TransactionRequest.Response.Content);
        }

        public void VoidToVoidTransaction()
        {
            TransactVoid(new PaymentDetails() { ReferenceId = VoidTransaction.UniqueId });
        }

    }
}