using Contracts;

namespace Core.Domain.Products.Entities
{
    public class Product: Entity
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public int Inventory { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
    }
}
