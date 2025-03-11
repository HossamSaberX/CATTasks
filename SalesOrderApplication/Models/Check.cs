
namespace SalesOrderApplication
{
    public class Check : Payment
    {
        public string Name { get; set; }
        public string BankId { get; set; }

        public override void Pay()
        {
            PaidDate = DateTime.Now;
            Console.WriteLine($"Paid {Amount} via Check ({Name})");
        }

        public override void Update()
        {
            Console.Write("New Name: ");
            Name = Console.ReadLine();
            Console.Write("New Bank ID: ");
            BankId = Console.ReadLine();
        }

        public static Check operator <<(Check check, string _)
        {
            Console.WriteLine($"Check Payment: {check.Amount}, Name={check.Name}, BankID={check.BankId}");
            return check;
        }

        public static Check operator >>(Check check, string _)
        {
            Console.Write("Amount: ");
            check.Amount = decimal.Parse(Console.ReadLine());
            Console.Write("Name: ");
            check.Name = Console.ReadLine();
            Console.Write("Bank ID: ");
            check.BankId = Console.ReadLine();
            return check;
        }
    }
}