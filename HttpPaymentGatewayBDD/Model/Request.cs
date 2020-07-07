namespace HttpPaymentGatewayBDD
{
    using Newtonsoft.Json;
    using System;

    public partial class Request
    {
        [JsonProperty("payment_transaction")]
        public PaymentDetails PaymentTransaction { get; set; }

        public static Request FromJson(string json) => JsonConvert.DeserializeObject<Request>(json, Converter.Settings);
    }

    public partial class PaymentDetails
    {
        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("card_number")]
        public string CardNumber { get; set; }

        [JsonProperty("cvv")]
        
        public long Cvv { get; set; }

        [JsonProperty("expiration_date")]
        public string ExpirationDate { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("usage")]
        public string Usage { get; set; }

        [JsonProperty("transaction_type")]
        public string TransactionType { get; set; }

        [JsonProperty("card_holder")]
        public string CardHolder { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
