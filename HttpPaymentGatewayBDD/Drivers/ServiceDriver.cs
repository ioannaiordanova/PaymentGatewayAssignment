using NUnit.Framework;
using TechTalk.SpecFlow.Configuration;

namespace HttpPaymentGatewayBDD
{
    public class ServiceDriver
    {
        private static string VoidTransactionRef, ValidTransactionRef;
        public TransactionRequestBase TransactionRequest;

        public ServiceDriver(bool auth)
        {
            TransactionRequest = new TransactionRequestBase(auth);
        }

        private void SetValidTransactionRef()
        {
            ValidTransactionRef = TransactionRequest.getResponseRefId();
        }

        private void SetVoidTransactionRef()
        {
            VoidTransactionRef = TransactionRequest.getResponseRefId();
        }


        public void SalesTransaction(PaymentDetails _PaymentDetailsModel)
        {
            TransactionRequest.TransactSale(_PaymentDetailsModel);
            if (TransactionRequest.IfIsResponseIsSuccessful) SetValidTransactionRef();            
        }

        public void VoidOfNonExistentTransaction(string refId)
        {
            TransactionRequest.TransactVoid(new PaymentDetails() { ReferenceId = refId });
        }

        public PaymentDetails GetPaymentDetailsBy(string previousTransactionType)
        {
            return previousTransactionType.IsVoid() ? new PaymentDetails() { ReferenceId = VoidTransactionRef } : new PaymentDetails() { ReferenceId = ValidTransactionRef };
        }

        public void VoidPreviousTransaction(string previousTransactionType)
        {
            TransactionRequest.TransactVoid(GetPaymentDetailsBy(previousTransactionType));
            if (TransactionRequest.IfIsResponseIsSuccessful) SetVoidTransactionRef();
        }

    }
}