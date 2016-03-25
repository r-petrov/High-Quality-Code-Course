namespace Models
{
    public class Order
    {
        public int ID { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Discount { get; set; }
    }
}
