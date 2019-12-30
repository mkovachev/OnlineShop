using AutoMapper;
using Data;
using FluentAssertions;
using OnlineShop.Data.Models;
using OnlineShop.Services.Implementations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OnlineShop.Test.Services
{
    public class CategoryServiceTest
    {
        private readonly OnlineShopDbContext db;
        private readonly Category category;
        private readonly IMapper mapper;

        public CategoryServiceTest()
        {
            this.db = TestStartup.CreateDatabase();
            this.category = db.Categories.FirstOrDefault();
            this.mapper = TestStartup.CreateMapper();
        }

        [Fact]
        public async Task ByIdAsync_ShouldReturn_CorrectCategory()
        {
            // Arrange
            var categoryService = new CategoryService(db, mapper);

            // Act
            var result = await categoryService.ByIdAsync(category.Id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Category>(result);

            result.Should()
                .Match<Category>(r =>
                                    r.Id == category.Id
                                    && r.Name == category.Name);
        }

        [Fact]
        public async Task AllProductsInCategoryAsync_ShouldReturn_AllProductFromCategory_OrderedByTitle()
        {
            // Arrange
            var categoryService = new CategoryService(db, mapper);

            // Act
            var productsInCategory = await categoryService.AllProductsInCategoryAsync(category.Id);
            var result = productsInCategory.ToList();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count);

            result
                .Should()
                .Match(r => r.ElementAt(0).Title == "TestProduct1"
                         && r.ElementAt(1).Title == "TestProduct2"
                         && r.ElementAt(2).Title == "TestProduct3")
                .And
                .HaveCount(3);
        }
    }
}
