
namespace SalesOrderApplication
{
    class Program
    {
        static Stock stock = new Stock();
        static List<Customer> customers = new List<Customer>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Sales Order System");
                Console.WriteLine("1. Data Entry\n2. Sales Process\n3. Print\n4. Exit");
                string choice = Console.ReadLine();
                if (choice == "4") break;

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("1. Customer CRUD\n2. Product in Stock CRUD");
                        string crudChoice = Console.ReadLine();
                        if (crudChoice == "1")
                        {
                            Console.WriteLine("1. Add\n2. Update\n3. Delete");
                            string customerChoice = Console.ReadLine();
                            if (customerChoice == "1")
                            {
                                Console.WriteLine("1. Person\n2. Company");
                                if (Console.ReadLine() == "1")
                                {
                                    Person person = new Person();
                                    person.GetInput();
                                    customers.Add(person);
                                    Console.WriteLine($"Added new person with ID: {person.Id}");

                                }
                                else
                                {
                                    Company company = new Company();
                                    company.GetInput();
                                    customers.Add(company);
                                    Console.WriteLine($"Added new company with ID: {company.Id}");

                                }
                            }
                            else if (customerChoice == "2")
                            {
                                Console.Write("Customer ID: ");
                                int id = int.Parse(Console.ReadLine());
                                for (int i = 0; i < customers.Count; i++)
                                {
                                    if (customers[i].Id == id)
                                    {
                                        customers[i] = customers[i] >> "";
                                        break;
                                    }
                                }
                            }
                            else if (customerChoice == "3")
                            {
                                Console.Write("Customer ID: ");
                                int id = int.Parse(Console.ReadLine());
                                for (int i = 0; i < customers.Count; ++i)
                                {
                                    if (customers[i].Id == id)
                                    {

                                        customers.RemoveAt(i);
                                        break;
                                    }

                                }
                            }
                        }
                        else if (crudChoice == "2")
                        {
                            Console.WriteLine("1. Add\n2. Update\n3. Delete");
                            string productChoice = Console.ReadLine();
                            if (productChoice == "1")
                            {
                                stock = stock >> "";
                                Console.WriteLine($"Added new product with ID: {stock.Products[stock.Products.Count - 1].Id}");
                            }
                            else if (productChoice == "2")
                            {
                                Console.Write("Product ID: ");
                                int id = int.Parse(Console.ReadLine());
                                stock.UpdateProduct(id);
                            }
                            else if (productChoice == "3")
                            {
                                Console.Write("Product ID: ");
                                int id = int.Parse(Console.ReadLine());
                                stock.DeleteProduct(id);
                            }
                        }
                        break;

                    case "2":
                        Console.WriteLine("1. Add Transaction\n2. Update Order\n3. Pay Order");
                        string processor = Console.ReadLine();
                        if (processor == "1")
                        {
                            Order order = new Order();
                            order.Create();
                            Console.Write("Enter Customer ID: ");
                            int customerId = int.Parse(Console.ReadLine());
                            bool customerFound = false;
                            for (int i = 0; i < customers.Count; i++)
                            {
                                if (customers[i].Id == customerId)
                                {
                                    Console.WriteLine("Customer found");
                                    customerFound = true;
                                    break;
                                }
                            }
                            if (!customerFound) break;

                            Console.WriteLine("Enter Items:");
                            while (true)
                            {
                                Console.Write("Product ID (0 to finish): ");
                                int productId = int.Parse(Console.ReadLine());
                                if (productId == 0) break;
                                Product product = stock.GetProduct(productId);
                                if (product != null)
                                {
                                    OrderItem item = new OrderItem { Product = product, SalePrice = product.Price };
                                    Console.Write("Quantity: ");
                                    item.Quantity = int.Parse(Console.ReadLine());
                                    order.Items.Add(item);
                                }
                            }
                            Console.Write("Enter Status (0=New, 1=Hold, 2=Paid, 3=Canceled): ");
                            int statusValue = int.Parse(Console.ReadLine());
                            order.Status = (OrderStatus)statusValue; 

                            Console.WriteLine("Payment: 1. Credit\n2. Cash\n3. Check");
                            string paymentChoice = Console.ReadLine();
                            Payment payment = null;
                            if (paymentChoice == "1")
                            {
                                Credit credit = new Credit();
                                credit = credit >> "";
                                payment = credit;
                            }
                            else if (paymentChoice == "2")
                            {
                                Cash cash = new Cash();
                                cash = cash >> "";
                                payment = cash;
                            }
                            else if (paymentChoice == "3")
                            {
                                Check check = new Check();
                                check = check >> "";
                                payment = check;
                            }
                            if (payment != null)
                            {
                                payment.Pay();
                                Transactions.Add(order, payment); 
                            }
                        }
                        else if (processor == "2")
                        {
                            Console.Write("Order Number: ");
                            int orderNum = int.Parse(Console.ReadLine());
                            Order order = null;
                            for (int i = 0; i < Transactions.transactions.Count; i++)
                            {
                                if (Transactions.transactions[i].Order.Number == orderNum)
                                {
                                    order = Transactions.transactions[i].Order;
                                    break;
                                }
                            }
                            if (order != null)
                            {
                                Console.WriteLine("1. Order Item Quantity\n2. Order Status");
                                string updateChoice = Console.ReadLine();
                                if (updateChoice == "1")
                                {
                                    order.Edit();
                                }
                                else if (updateChoice == "2")
                                {
                                    Console.Write("New Status (0=New, 1=Hold, 2=Paid, 3=Canceled): ");
                                    int statusValue = int.Parse(Console.ReadLine());
                                    order.Status = (OrderStatus)statusValue; 
                                }
                            }
                        }
                        else if (processor == "3")
                        {
                            Console.Write("Order Number: ");
                            int orderNum = int.Parse(Console.ReadLine());
                            for (int i = 0; i < Transactions.transactions.Count; i++)
                            {
                                if (Transactions.transactions[i].Order.Number == orderNum)
                                {
                                    Transactions.transactions[i].Payment.Pay();
                                    Transactions.transactions[i].Order.Status = OrderStatus.Paid;
                                    break;
                                }
                            }
                        }
                        break;

                    case "3":
                        Console.WriteLine("1. Customers\n2. Stock data\n3. Transactions");
                        string printChoice = Console.ReadLine();
                        if (printChoice == "1")
                        {
                            for (int i = 0; i < customers.Count; i++)
                            {
                               customers[i] = customers[i] << "";
                                    Console.WriteLine();
                            }
                        }
                        else if (printChoice == "2")
                        {
                            var res = stock << ""; 
                        }
                        else if (printChoice == "3")
                        {
                            Transactions log = new Transactions();
                            log = log << "";
                        }
                        break;
                }
            }
        }
    }
}