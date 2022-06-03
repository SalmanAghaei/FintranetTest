using Mapster;
using Contracts;
using System.Linq;
using Contracts.Products.Dtos;
using Infra.Data.Sql.Contexts;
using System.Collections.Generic;
using Core.Domain.Products.Entities;
using Contracts.Products.Repositories;

namespace Infra.Data.Sql.Products.Repositories
{
    public class ProductRepository : Repository<Product,int, AppDbContext>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public List<ProductListDto> GetAll()
        {
            var products = _dbContext.Products.ProjectToType<ProductListDto>().ToList();
            return products;
        }


        public bool IsUniqueSku(CheckSkuUniqueDto checkSku)
        {
            var product = _dbContext.Products.FirstOrDefault(x=>x.Id!= checkSku.Id && x.SKU==checkSku.Sku);
            return product is null ? true : false;
        }
    }
}
