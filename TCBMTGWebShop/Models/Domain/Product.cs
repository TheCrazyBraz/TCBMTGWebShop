namespace TCBMTGWebShop.Models.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductType { get; set; }
        public decimal ProductPrice { get; set; }
        public  int ProductQuantity { get; set; }

    
    }
}

