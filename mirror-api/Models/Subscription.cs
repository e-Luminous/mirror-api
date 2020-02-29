using System;

namespace mirror_api.Models
{
    public class Subscription
    {
        public string SubscriptionId { get; set; }
        public DateTime ValidTill { get; set; }
        public Transaction Transaction { get; set; }
        public Institution Institution { get; set; }
    }
}