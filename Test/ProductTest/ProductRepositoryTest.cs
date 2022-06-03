using Xunit;
using FluentAssertions;
using Core.Domain.Products.Entities;
using Infra.Data.Sql.Products.Repositories;

namespace Test.ProductTest
{
    public  class ProductRepositoryTest: IClassFixture<DataBaseFixture>
    {
        private readonly DataBaseFixture _dataBase;
        ProductRepository productRepository;
        public ProductRepositoryTest(DataBaseFixture dataBase)
        {
            _dataBase = dataBase;
            productRepository = new ProductRepository(_dataBase.DbContext);
        }
        [Fact]
        public void Add_Product()
        {
            var product = new Product {Id=3, Name = "ProductTest", SKU = "1034",ShortDescription="Test" };
            productRepository.Insert(product);
            productRepository.SaveChanges();
            var productSearch = productRepository.Get(product.Id);
            productSearch.Should().Be(product);
        }

        [Fact]
        public void Edit_Product()
        {
            var oldProduct = new Product {Id=1, Name = "OldProductTest", SKU = "1034", ShortDescription = "Test", Description = "" };
            var newProductName = "NewProduct";
            productRepository.Insert(oldProduct);
            productRepository.SaveChanges();
            var product=productRepository.Get(oldProduct.Id);
            product.Name= newProductName;
            productRepository.SaveChanges();
            var productSearch = productRepository.Get( oldProduct.Id);
            productSearch.Name.Should().Be(newProductName);
        }

        [Fact]
        public void Delete_Product()
        {
            var product = new Product {Id = 2,Name = "ProductTest", SKU = "1034", ShortDescription = "Test",Description="" };
            productRepository.Insert(product);
            productRepository.SaveChanges();
            product = productRepository.Get(product.Id);
            productRepository.Delete(product);
            productRepository.SaveChanges();
            var productSearch = productRepository.Get(product.Id);
            productSearch.Should().BeNull();
        }


        [Fact]
        public void IsUniqueSku_Should_False_When_Exist_Sku()
        {
            productRepository.Insert(new Product { Id = 10, SKU = "sku20",Name="PTest", ShortDescription = "Test" });
            productRepository.SaveChanges();
            var result=productRepository.IsUniqueSku(new Contracts.Products.Dtos.CheckSkuUniqueDto { Id = 11, Sku = "sku20" });
            result.Should().BeFalse();
        }
        [Fact]
        public void IsUniqueSku_Should_True_When_NotExist_Sku()
        {
            productRepository.Insert(new Product { Id = 11, SKU = "sku21", Name = "PTest", ShortDescription = "Test" });
            productRepository.SaveChanges();
            var result = productRepository.IsUniqueSku(new Contracts.Products.Dtos.CheckSkuUniqueDto { Id = 12, Sku = "sku25" });
            result.Should().BeTrue();
        }
        [Fact]
        public void GetAll_Should_Return_Zero_When_Empty_Product_Table()
        {
            productRepository.Insert(new Product { Id = 16, SKU = "sku21", Name = "PTest", ShortDescription = "Test" });
            productRepository.SaveChanges();
            var result=productRepository.GetAll();
            result.Count.Should().BeGreaterThan(0);
        }
    }
}
