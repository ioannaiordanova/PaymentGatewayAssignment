using Microsoft.Extensions.Configuration;
using RestSharp;

namespace HttpPaymentGatewayBDD
{
    public class TransactionRequestBase
    {
        private RestClientBase RestClient;
        public IRestResponse Response { get; set; }
        private RestRequest RestRequest;
        private IConfigurationRoot Config = RestClientBase.Config;
 
        public TransactionRequestBase(bool auth) 
        {
            RestClient = new RestClientBase(auth);
        }

        private TransactionRequestBase AddBodyParameter(PaymentDetails _body)
        {  
            RestRequest.AddParameter(Config["Content-Type"], new Payment() { PaymentTransaction = _body }.ToJson(), ParameterType.RequestBody);
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

        public void SendPaymentDetails(PaymentDetails _paymentDetails)
        {
            SetPostRequest(Config["Query"]).AddBodyParameter(_paymentDetails).Post();   
        }

        public void TransactSale(PaymentDetails _paymentDetailsModel)
        {
            _paymentDetailsModel.TransactionType = Config["Sale"];
            SendPaymentDetails(_paymentDetailsModel);
        }

        public void TransactVoid(PaymentDetails _paymentDetailsModel)
        {
            _paymentDetailsModel.TransactionType = Config["Void"];
            SendPaymentDetails(_paymentDetailsModel);
        }

    }
}
