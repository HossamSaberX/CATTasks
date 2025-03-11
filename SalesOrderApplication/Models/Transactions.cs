
namespace SalesOrderApplication
{
    public class Transactions 
    {
        public static List<(Order Order, Payment Payment)> transactions = new List<(Order, Payment)>();
        public static DateTime TransDate { get; set; }

        public static Order GetOrder(int index)
        {
            if (index >= 0 && index < transactions.Count) return transactions[index].Order;
            return null;
        }

        public static void Add(Order order, Payment payment)
        {
            transactions.Add((order, payment));
            TransDate = DateTime.Now;
        }

        public static Transactions operator <<(Transactions _, string __)
        {
            for (int i = 0; i < transactions.Count; i++)
            {
                Console.WriteLine($"Transaction Date={TransDate}, Order={transactions[i].Order.Number}, Payment={transactions[i].Payment.Amount}");
                Console.WriteLine();
            }
            return _; 
        }
    }
}