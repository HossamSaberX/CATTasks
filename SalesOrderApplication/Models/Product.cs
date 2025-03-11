using System;
namespace SalesOrderApplication
{
    public class Product
    {
        private static int nextId = 1;

        public Product()
        {
            Id = nextId++;
        }

        public int Id { get; protected set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }

        public void GetInput()
        {
            Console.Write("Name: ");
            Name = Console.ReadLine();
            Console.Write("Price: ");
            Price = decimal.Parse(Console.ReadLine());
            Console.Write("Type: ");
            Type = Console.ReadLine();
        }

        public void Update()
        {
            GetInput();
        }

        public void Print()
        {
            Console.WriteLine($"{Id}: {Name} -- {Price} ({Type})");
        }

        public static Product operator <<(Product product, string _)
        {
            product.Print();
            return product;
        }

        public static Product operator >>(Product product, string _)
        {
            product.GetInput();
            return product;
        }
    }
}