using System;

namespace mirror_api.Models
{
    public class Transaction
    {
        public string TransactionId { get; set; }
        public double BillPaid { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public string TransactionLog { get; set; }
        public PaymentMethod Method { get; set; }
        public Subscription Subscription { get; set; }
    }
}