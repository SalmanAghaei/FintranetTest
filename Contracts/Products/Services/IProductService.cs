using Contracts.Products.Dtos;
using System.Collections.Generic;

namespace Contracts.Products.Services
{
    public interface IProductService : IScopedLifeTime
    {
        ServiceResult Add(ProductAddDto addDto);
        ServiceResult Edit(ProductEditDto editDto);
        ServiceResult Delete(ProductDeleteDto deleteDto);
        ServiceResult<List<ProductListDto>> GetAll();

    }
}
