
namespace SalesOrderApplication
{
    public class Credit : Payment
    {
        public string Number { get; set; }
        public DateTime ExpDate { get; set; }
        public string Type { get; set; }

        public override void Pay()
        {
            PaidDate = DateTime.Now;
            Console.WriteLine($"Paid {Amount} via Credit ({Type})");
        }

        public override void Update()
        {
            Console.Write("New Card Number: ");
            Number = Console.ReadLine();
            Console.Write("New Expiry Date (mm/yy): ");
            ExpDate = DateTime.Parse(Console.ReadLine());
            Console.Write("New Type: ");
            Type = Console.ReadLine();
        }

        public static Credit operator <<(Credit credit, string _)
        {
            Console.WriteLine($"Credit Payment: {credit.Amount}, Card={credit.Number}, Type={credit.Type}");
            return credit;
        }

        public static Credit operator >>(Credit credit, string _)
        {
            Console.Write("Amount: ");
            credit.Amount = decimal.Parse(Console.ReadLine());
            Console.Write("Card Number: ");
            credit.Number = Console.ReadLine();
            Console.Write("Expiry Date (mm/yy): ");
            credit.ExpDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Type: ");
            credit.Type = Console.ReadLine();
            return credit;
        }
    }
}