
namespace SalesOrderApplication
{
    public abstract class Payment
    {
        public DateTime PaidDate { get; set; }
        public decimal Amount { get; set; }

        public abstract void Pay();
        public abstract void Update();
    }
}