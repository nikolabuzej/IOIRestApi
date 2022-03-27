namespace FrontEnd.Domain
{
    public class IOI
    {
        public int? IOIid { get; set; }
        public DateTime DeliveryDeadline { get; set; } = DateTime.Now;
        public DateTime PaymentDeadline { get; set; } = DateTime.Now;
        public Warranty Warranty { get; set; } = new Warranty();
        public int WarrantyId { get; set; }
    }
}
