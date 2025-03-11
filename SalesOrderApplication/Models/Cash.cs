
namespace SalesOrderApplication
{
    public class Cash : Payment
    {
        public decimal CashValue { get; set; }

        public override void Pay()
        {
            PaidDate = DateTime.Now;
            Console.WriteLine($"Paid {Amount} in Cash (Value: {CashValue})");
        }

        public override void Update()
        {
            Console.Write("New Cash Value: ");
            CashValue = decimal.Parse(Console.ReadLine());
        }

        public static Cash operator <<(Cash cash, string _)
        {
            Console.WriteLine($"Cash Payment: {cash.Amount}, Value={cash.CashValue}");
            return cash;
        }

        public static Cash operator >>(Cash cash, string _)
        {
            Console.Write("Amount: ");
            cash.Amount = decimal.Parse(Console.ReadLine());
            Console.Write("Cash Value: ");
            cash.CashValue = decimal.Parse(Console.ReadLine());
            return cash;
        }
    }
}