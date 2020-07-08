using RestSharp;

namespace HttpPaymentGatewayBDD
{
    class TransactionRequestBase
    {
        private RestClientBase RestClient;
        public IRestResponse Response { get; set; }
        private RestRequest RestRequest;
        public TransactionRequestBase(bool auth) 
        {
            RestClient = new RestClientBase(auth);
        }

        public void AddBodyParameter(PaymentDetails _body)
        {
            Payment _paymentRequest = new Payment() { PaymentTransaction = _body };          
            RestRequest.AddParameter(ServiceDriver.Config["Content-Type"], _paymentRequest.ToJson(), ParameterType.RequestBody);
        }

        public void SendPaymentDetails(string _query,PaymentDetails _paymentDetails)
        {
            RestRequest = new RestRequest(_query, Method.POST);

            AddBodyParameter(_paymentDetails);
            
            Response = RestClient.Post(RestRequest);
        }
    }
}
