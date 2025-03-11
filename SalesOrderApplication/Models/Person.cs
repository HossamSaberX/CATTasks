namespace SalesOrderApplication
{
    public class Person : Customer
    {
        public string MailingAddress { get; set; }
        public string FullName { get; set; }

        public override void Print()
        {
            Console.WriteLine($"Person: ID={Id}, Name={FullName}, Phone={Phone}, Address={MailingAddress}");
        }

        public override void GetInput()
        {
            Console.Write("Phone: ");
            Phone = Console.ReadLine();
            Console.Write("Full Name: ");
            FullName = Console.ReadLine();
            Console.Write("Mailing Address: ");
            MailingAddress = Console.ReadLine();
        }
    }
}