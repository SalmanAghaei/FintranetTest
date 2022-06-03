using Xunit;
using NSubstitute;
using FluentAssertions;
using Contracts.Products.Dtos;
using Core.Domain.Products.Entities;
using Contracts.Products.Repositories;
using Core.Application.Products.Service;

namespace Test.Core.Application.Test
{
    public class ProductServiceTest
    {
        private IProductRepository productRepository = Substitute.For<IProductRepository>();
        ProductService productService;
        CheckSkuUniqueDto checkSku;
        public ProductServiceTest()
        {
            productService = new ProductService(productRepository);
            checkSku = new CheckSkuUniqueDto { Id = 1, Sku = "1040" };
        }

        [Fact]
        public void Add_Product()
        {
            productRepository.IsUniqueSku(checkSku).ReturnsForAnyArgs(true);
            var productAddDto = new ProductAddDto { SKU = "1035", Name = "ProductTest", ShortDescription = "Test" };
            var result = productService.Add(productAddDto);
            result.IsSuccess.Should().BeTrue();
        }


        [Fact]
        public void Edit_Product()
        {

            productRepository.IsUniqueSku(checkSku).ReturnsForAnyArgs(true);
            productRepository.Get(1).ReturnsForAnyArgs(new Product { Id = 1, SKU = "1038", Name = "ProductTest", ShortDescription = "Test" });
            var productEditDto = new ProductEditDto { Id = 1, SKU = "1036", Name = "ProductTest", ShortDescription = "Test" };
            var result = productService.Edit(productEditDto);
            result.IsSuccess.Should().BeTrue();

        }

        [Fact]
        public void Should_Edit_NotFound_When_Use_InValid_Product()
        {
            var productEditDto = new ProductEditDto { Id = 1, SKU = "1037", Name = "ProductTest", ShortDescription = "Test" };
            productRepository.Get(productEditDto.Id).Returns(x => null);
            var result = productService.Edit(productEditDto);
            result.Status.Should().Be(System.Net.HttpStatusCode.NotFound);

        }

        [Fact]
        public void Delete_Product()
        {

            var productDeleteDto = new ProductDeleteDto { Id = 1 };
            productRepository.Get(productDeleteDto.Id).ReturnsForAnyArgs(new Product { Id = 1, SKU = "1038", Name = "ProductTest", ShortDescription = "Test" });
            var result = productService.Delete(productDeleteDto);
            result.IsSuccess.Should().BeTrue();

        }

        [Fact]
        public void Should_Delete_NotFound_When_Use_InValid_Product()
        {
            var productDeleteDto = new ProductDeleteDto { Id = 1 };
            productRepository.Get(productDeleteDto.Id).Returns(x => null);
            var result = productService.Delete(productDeleteDto);
            result.Status.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        [Fact]
        public void Should_IsUniqueSku_False_When_Repetitive_Sku()
        {
            productRepository.IsUniqueSku(checkSku).ReturnsForAnyArgs(false);
            var result = productService.IsUniqueSku(checkSku);
            result.Should().BeFalse();
        }

        [Fact]
        public void Should_IsUniqueSku_True_When_Valis_Sku()
        {
            productRepository.IsUniqueSku(checkSku).ReturnsForAnyArgs(true);
            var result = productService.IsUniqueSku(checkSku);
            result.Should().BeTrue();
        }
    }
}
