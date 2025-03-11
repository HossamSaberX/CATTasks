
namespace SalesOrderApplication
{
    public enum OrderStatus
    {
        New,
        Hold,
        Paid,
        Canceled
    }

    public class Order
    {
        private Random rnd = new Random();

        public int Number { get; private set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount => CalculateTotal();
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; } = new List<OrderItem>();

        private decimal CalculateTotal()
        {
            decimal total = 0;
            for (int i = 0; i < Items.Count; i++)
            {
                total += Items[i].SalePrice * Items[i].Quantity;
            }
            return total;
        }

        public void Create()
        {
            Number = rnd.Next(1, 100001);
            OrderDate = DateTime.Now;
            Status = OrderStatus.New;
        }

        public void Edit()
        {
            Console.WriteLine("Items in order:");
            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Items[i].Product.Name}, Quantity: {Items[i].Quantity}, Price: {Items[i].SalePrice}");
            }

            Console.Write("Select item to update (1-" + Items.Count + "): ");
            int choice = int.Parse(Console.ReadLine()) - 1;

            if (choice >= 0 && choice < Items.Count) Items[choice].UpdateQuantity();
            else Console.WriteLine("Invalid selection.");
        }

        public static Order operator <<(Order order, string _)
        {
            Console.WriteLine($"Order #{order.Number} - Date: {order.OrderDate}");
            Console.WriteLine($"Status: {order.Status}");
            Console.WriteLine("Items:");

            for (int i = 0; i < order.Items.Count; i++)
            {
                OrderItem item = order.Items[i];
                Console.WriteLine($"  {item.Product.Name} x {item.Quantity} => {item.SalePrice} = {item.Quantity * item.SalePrice}");
            }

            Console.WriteLine($"Total Amount: {order.TotalAmount}");
            return order;
        }

        public static Order operator >>(Order order, string _)
        {
            Console.WriteLine("Status (0=New, 1=Hold, 2=Paid, 3=Canceled): ");
            int statusValue = int.Parse(Console.ReadLine());
            order.Status = (OrderStatus)statusValue;
            return order;
        }
    }
}