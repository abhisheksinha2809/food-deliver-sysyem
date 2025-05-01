namespace Online_food_delivery_system.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public int OrderID { get; set; }
        public Order Order { get; set; }

        public int MenuItemID { get; set; }
        public MenuItem MenuItem { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; } // (MenuItem.Price * Quantity)
    }
}