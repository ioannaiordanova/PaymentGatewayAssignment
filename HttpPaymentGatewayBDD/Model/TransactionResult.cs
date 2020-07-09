namespace HttpPaymentGatewayBDD
{
    using Newtonsoft.Json;
    using System;

    public class TransactionResult
    {
        [JsonProperty("unique_id")]
        public string UniqueId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("usage")]
        public string Usage { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("transaction_time")]
        public DateTimeOffset TransactionTime { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public static TransactionResult FromJson(string json) => JsonConvert.DeserializeObject<TransactionResult>(json, Converter.Settings);
    }

}
