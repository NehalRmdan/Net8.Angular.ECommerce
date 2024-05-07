namespace core.Entities.OrderAggregates
{
    public class ProductItemOrdered 
    {
        public ProductItemOrdered()
        {
        }

        public ProductItemOrdered(int productItemId
            , string productName
            , string productPictureURL)
        {
            ProductItemId = productItemId;
            ProductName = productName;
            ProductPictureURL = productPictureURL;
        }

        public int ProductItemId { get; set; }

        public string ProductName { get; set; }

        public string ProductPictureURL { get; set; }
    }
}
