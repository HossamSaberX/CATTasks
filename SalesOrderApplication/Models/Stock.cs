
namespace SalesOrderApplication
{
    public class Stock
    {
        public List<Product> Products { get; } = new List<Product>();

        public Product GetProduct(int id)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].Id == id)
                    return Products[i];
            }
            return null;
        }

        public void UpdateProduct(int id)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].Id == id)
                {
                    Products[i].Update();
                    break;
                }
            }
        }

        public void DeleteProduct(int id)
        {
            for (int i = 0; i < Products.Count; ++i)
            {
                if (Products[i].Id == id)
                {
                    Products.RemoveAt(i);
                break;

                }
            }
        }

        public static Stock operator <<(Stock stock, string _)
        {
            for (int i = 0; i < stock.Products.Count; i++)
            {
                stock.Products[i].Print();
                    Console.WriteLine();
            }
            return stock;
        }

        public static Stock operator >>(Stock stock, string _)
        {
            Product product = new Product();
            product.GetInput();
            stock.Products.Add(product);
            return stock;
        }
    }
}