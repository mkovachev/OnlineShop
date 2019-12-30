using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineShop.Controllers.Implementations;
using OnlineShop.Controllers.Models.CategoryViewModels;
using OnlineShop.Services.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace OnlineShop.Test.Web
{
    public class AdminCategoryControllerTest
    {
        [Fact]
        public async Task Index_ShouldReturn_CategoryViewModel_WithAllProducts()
        {
            // Arrange
            var mockCategoryService = new Mock<ICategoryService>();
            var CategoryController = new CategoriesController(mockCategoryService.Object);
            var id = 1; // category

            // Act
            var result = await CategoryController.Index(id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<CategoryViewModel>(viewResult.Model);
        }
    }
}
