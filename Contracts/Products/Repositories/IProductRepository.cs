using Contracts.Products.Dtos;
using Core.Domain.Products.Entities;
using System.Collections.Generic;

namespace Contracts.Products.Repositories
{
    public interface IProductRepository : IRepository<Product, int>
    {
        List<ProductListDto> GetAll();
        bool IsUniqueSku(CheckSkuUniqueDto checkSku);
    }
}
