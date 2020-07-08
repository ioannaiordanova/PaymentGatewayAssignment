using Newtonsoft.Json;

namespace HttpPaymentGatewayBDD
{
    public static class BaseHttpModel
    {
        public static string ToJson(this TransactionResult self) => JsonConvert.SerializeObject(self, HttpPaymentGatewayBDD.Converter.Settings);

        public static string ToJson(this Payment self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
