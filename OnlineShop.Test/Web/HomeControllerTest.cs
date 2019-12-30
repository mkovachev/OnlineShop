using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineShop.Controllers.Implementations;
using OnlineShop.Controllers.Models.ProductsViewModels;
using OnlineShop.Services.Interfaces;
using OnlineShop.Services.Models.ProductService;
using OnlineShop.Services.Models.ShoppingCartService;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace OnlineShop.Test.Web
{
    public class HomeControllerTest
    {
        private readonly ShoppingCart shoppingCart;

        public HomeControllerTest()
        {
            this.shoppingCart = TestStartup.CreateShoppingCart();
        }

        [Fact]
        public async Task Index_ShouldReturn_HomeViewModel()
        {
            // Arrange
            var mockProductService = new Mock<IProductService>().Object;
            var homeController = new HomeController(mockProductService, shoppingCart);
            var mockHomeViewModel = new Mock<ProductListingViewModel>().Object;

            mockHomeViewModel.Products = new List<ProductListingServiceModel>()
            {
                new ProductListingServiceModel { Id = 1, Title = "A", Price = 1},
                new ProductListingServiceModel { Id = 2, Title = "B", Price = 1},
                new ProductListingServiceModel { Id = 3, Title = "C", Price = 1}
            };

            // get mocked session
            var mockContext = new Mock<HttpContext>().Object;
            var mockSession = new Mock<ISession>();

            var key = "session";
            var value = new byte[0];

            mockSession.Setup(s => s.Set(key, It.IsAny<byte[]>()))
                            .Callback<string, byte[]>((k, v) => value = v);

            mockSession.Setup(s => s.TryGetValue(key, out value))
                .Returns(true);

            // Act
            var result = await homeController.Index(); // TODO return null for sessionId

            //Assert
            Assert.Null(result);
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ProductListingViewModel>(viewResult.Model);
        }

        [Fact]
        public async Task Search_ShouldReturn_SearchViewModel()
        {
            // Arrange
            var mockProductService = new Mock<IProductService>().Object;
            var homeController = new HomeController(mockProductService, shoppingCart);
            var mockHomeViewModel = new Mock<ProductListingViewModel>().Object;

            // Act
            var result = await homeController.Search(mockHomeViewModel);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<ProductListingViewModel>(viewResult.Model);
        }
    }
}
