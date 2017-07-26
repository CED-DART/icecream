using System;
using System.Collections.Generic;

namespace IceCream.Data.Models
{
    public partial class UserDebtor
    {
        public int IdUserDebtor { get; set; }
        public int IdUser { get; set; }
        public string Reason { get; set; }
        public DateTime DebitDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string Evaluation { get; set; }
        public DateTime Created { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
