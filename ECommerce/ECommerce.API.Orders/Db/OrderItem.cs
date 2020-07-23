namespace ECommerce.API.Orders.Db
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal unitPrice { get; set; }
    }
}