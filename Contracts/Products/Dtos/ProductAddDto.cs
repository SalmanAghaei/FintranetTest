namespace Contracts.Products.Dtos
{
    public class ProductAddDto
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public int Inventory { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
    }  
}
