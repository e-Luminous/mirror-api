using System.Collections.Generic;

namespace mirror_api.Models
{
    public class PaymentMethod
    {
        public int MethodId { get; set; }
        public string MethodName { get; set; }
        public string EndPoint { get; set; }
        public string OTPUrl { get; set; }
        public string TransactionUrl { get; set; }

        public ICollection<Transaction> Transcs { get; set; }
    }
}