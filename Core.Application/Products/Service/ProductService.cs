using Mapster;
using Contracts;
using System.Net;
using Contracts.Products.Dtos;
using System.Collections.Generic;
using Contracts.Products.Services;
using Core.Domain.Products.Entities;
using Contracts.Products.Repositories;

namespace Core.Application.Products.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public ServiceResult Add(ProductAddDto addDto)
        {
            var product = addDto.Adapt<Product>();
            if(!IsUniqueSku(new CheckSkuUniqueDto { Sku=addDto.SKU,Id=0}))
                return ServiceResultHandler.Failed("Sku Is Unique!");
            _productRepository.Insert(product);
            _productRepository.SaveChanges();
            return ServiceResultHandler.Ok();
        }

        public ServiceResult Delete(ProductDeleteDto deleteDto )
        {
            var product = _productRepository.Get(deleteDto.Id);
            if (product is null)
                return ServiceResultHandler.Failed(status: HttpStatusCode.NotFound);
            _productRepository.Delete(product);
            _productRepository.SaveChanges();
            return ServiceResultHandler.Ok();
        }

        public ServiceResult Edit(ProductEditDto editDto)
        {
            var product = _productRepository.Get(editDto.Id);
            if (product is null)
                return ServiceResultHandler.Failed(status: HttpStatusCode.NotFound);
            if (!IsUniqueSku(new CheckSkuUniqueDto { Sku = editDto.SKU, Id = editDto.Id }))
                return ServiceResultHandler.Failed("Sku Is Unique!");
            editDto.Adapt(product);
            _productRepository.SaveChanges();
            return ServiceResultHandler.Ok();
        }

        public ServiceResult<List<ProductListDto>> GetAll() => 
            ServiceResultHandler.Ok(_productRepository.GetAll());


        public bool IsUniqueSku(CheckSkuUniqueDto checkSku) 
        { 
            var b = _productRepository.IsUniqueSku(checkSku);
            return b;
        }
    }
}
