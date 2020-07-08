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
                _restClient.AddDefaultHeader("Authorization", "Basic " + config["AuthTokenFalse"]);
        }


        public IRestResponse SendTransaction(PaymentDetails _transaction)
        {
            Request _saleRequest = new Request() { PaymentTransaction = _transaction };
            var request = new RestRequest(config["Query"], Method.POST);

            request.AddParameter(config["Content-Type"], _saleRequest.ToJson(), ParameterType.RequestBody);

            _response = _restClient.Post(request);
            return _response;
        }

        public void ValidTransaction(PaymentDetails _transaction)
        {
            _validTransaction = TransactionResult.FromJson(SendTransaction(_transaction).Content);

        }

        public void AssertStatusCode(int code)
        {
            Assert.IsTrue((int)_response.StatusCode == code);
        }


        public void VoidTransaction()
        {
            PaymentDetails _transaction = new PaymentDetails() { ReferenceId = _validTransaction.UniqueId, TransactionType = config["Void"] };

            _voidTransaction = TransactionResult.FromJson(SendTransaction(_transaction).Content);

        }

        public void VoidToVoidTransaction()
        {
            PaymentDetails _transaction = new PaymentDetails() { ReferenceId = _voidTransaction.UniqueId, TransactionType = config["Void"] };
            SendTransaction(_transaction);
        }

    }
}