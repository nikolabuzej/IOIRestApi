using System;

namespace IOIModel
{
    public class IOI
    {
        public int? IOIid { get; set; }
        public DateTime DeliveryDeadline { get; set; }
        public DateTime PaymentDeadline { get; set; }
        public Warranty Warranty { get; set; }
        public int WarrantyId { get; set; }

    }
}
