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

        public TransactionRequestBase AddBodyParameter(PaymentDetails _body)
        {  
            RestRequest.AddParameter(ServiceDriver.Config["Content-Type"], new Payment() { PaymentTransaction = _body }.ToJson(), ParameterType.RequestBody);
            return this;
        }
  
        private TransactionRequestBase SetPostRequest(string _query)
        {
            RestRequest = new RestRequest(_query, Method.POST);
            return this;
        }

        public bool IfIsResponseIsSuccessful
        {
            get { return Response.IsSuccessful; }
           
        }

        public string getResponseRefId()
        {
           return TransactionResult.FromJson(Response.Content).UniqueId;
        }

        private void Post()
        {
            Response = RestClient.Post(RestRequest);
        }

        public void SendPaymentDetails(string _query,PaymentDetails _paymentDetails)
        {
            SetPostRequest(_query).AddBodyParameter(_paymentDetails).Post();   
        }

    }
}
