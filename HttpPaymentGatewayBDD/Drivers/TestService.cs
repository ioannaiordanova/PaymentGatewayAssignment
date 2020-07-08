using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using RestSharp;
using System;

namespace HttpPaymentGatewayBDD
{
    public class TestService
    {
        private RestClient _restClient;
        private static TransactionResult _validTransaction, _voidTransaction;
        IRestResponse _response;
        public static IConfigurationRoot config;

        public TestService(bool auth)
        {
            _restClient = new RestClient();

            _restClient.BaseUrl = new Uri(config["Uri"]);
            _restClient.AddDefaultHeader("Content-Type", config["Content-Type"]);

            if (auth)
                _restClient.AddDefaultHeader("Authorization", "Basic " + config["AuthToken"]);
            else
            {
                _restClient.AddDefaultHeader("Authorization", "Basic " + Helper.GenerateFalseToken());
            }
        }

      

        private IRestResponse SendTransaction(PaymentDetails _transaction)
        {
            Request _saleRequest = new Request() { PaymentTransaction = _transaction };
            var request = new RestRequest(config["Query"], Method.POST);

            request.AddParameter(config["Content-Type"], _saleRequest.ToJson(), ParameterType.RequestBody);

            _response = _restClient.Post(request);
            return _response;
        }

        public String TransactSale(PaymentDetails _transaction)
        {
            _transaction.TransactionType = config["Sale"];
            return SendTransaction(_transaction).Content;
        }

        public string TransactVoid(PaymentDetails _transaction)
        {
            _transaction.TransactionType = config["Void"];
            return SendTransaction(_transaction).Content;
        }

        public void ValidTransaction(PaymentDetails _transaction)
        {
            _validTransaction = TransactionResult.FromJson(TransactSale(_transaction));
        }


        public void AssertStatusCode(int code)
        {
            Assert.AreEqual(code, (int)_response.StatusCode);
        }


        public void VoidValidTransaction()
        {
            PaymentDetails _transaction = new PaymentDetails() { ReferenceId = _validTransaction.UniqueId };
            _voidTransaction = TransactionResult.FromJson(TransactVoid(_transaction));

        }

        public void VoidToVoidTransaction()
        {
            PaymentDetails _transaction = new PaymentDetails() { ReferenceId = _voidTransaction.UniqueId };
            TransactVoid(_transaction);
        }

    }
}