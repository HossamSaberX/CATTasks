
namespace SalesOrderApplication
{
    public class OrderItem
    {
        public decimal SalePrice { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }

        public void UpdateQuantity()
        {
            Console.Write("New Quantity: ");
            Quantity = int.Parse(Console.ReadLine());
        }

        public static OrderItem operator ++(OrderItem item)
        {
            item.Quantity++;
            return item;
        }

        public static OrderItem operator --(OrderItem item)
        {
            if (item.Quantity > 0)
                item.Quantity--;
            return item;
        }

        public static OrderItem operator +(OrderItem item, int value)
        {
            item.Quantity += value;
            return item;
        }

        public static OrderItem operator -(OrderItem item, int value)
        {
            if (item.Quantity - value >= 0)
                item.Quantity -= value;
            return item;
        }

        public static OrderItem operator >>(OrderItem item, string _)
        {
            Console.Write("Quantity: ");
            item.Quantity = int.Parse(Console.ReadLine());
            return item;
        }
    }
}