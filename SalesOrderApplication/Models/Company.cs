namespace SalesOrderApplication
{
    public class Company : Customer
    {
        public string Location { get; set; }
        public string CompanyName { get; set; }

        public override void Print()
        {
            Console.WriteLine($"Company: ID={Id}, Name={CompanyName}, Phone={Phone}, Location={Location}");
        }

        public override void GetInput()
        {
            Console.Write("Phone: ");
            Phone = Console.ReadLine();
            Console.Write("Company Name: ");
            CompanyName = Console.ReadLine();
            Console.Write("Location: ");
            Location = Console.ReadLine();
        }
    }
}