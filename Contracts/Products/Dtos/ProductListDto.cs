namespace Contracts.Products.Dtos
{
    public class ProductListDto
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public int Inventory { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
    } 
}
