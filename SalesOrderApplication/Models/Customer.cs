namespace SalesOrderApplication
{
    public abstract class Customer
    {
        private static int nextId = 1;

        public Customer()
        {
            Id = nextId++;
        }

        public int Id { get; protected set; }
        public string Phone { get; set; }

        public abstract void GetInput();

        public abstract void Print();

        public static Customer operator <<(Customer customer, string _)
        {
            customer.Print();
            return customer;
        }
        public static Customer operator >>(Customer customer, string _)
        {
            customer.GetInput();
            return customer;
        }
    }
}