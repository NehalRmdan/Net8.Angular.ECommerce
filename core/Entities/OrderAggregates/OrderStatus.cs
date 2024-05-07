using System.Runtime.Serialization;

namespace core.Entities.OrderAggregates
{
    public enum OrderStatus
    {
        [EnumMember(Value ="Pending")]
        Pending,

        [EnumMember(Value = "Payment Success")]
        PaymentReceived,

        [EnumMember(Value = "Payment Failed")]
        PaymentFailed,
    }
}
