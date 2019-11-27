using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Controllers.Infrastructure;
using OnlineShop.Data.Models;
using OnlineShop.Services.Interfaces;
using OnlineShop.Services.Models.ShoppingCartService;
using System.IO;
using System.Threading.Tasks;

namespace OnlineShop.Controllers.Implementations
{
    public class OrderController : Controller
    {
        private const string senderEmailName = "Your Tradeport Team";
        private const string senderEmailAddress = "tradeport3@gmail.com";
        private const string Message = "Your cart is empty, go back and add some products";
        private readonly IShoppingCartService shoppingCartServices;
        private readonly ShoppingCart shoppingCart;
        private readonly IOrderService orderService;
        //private readonly IEmailService emailService;
        private readonly IWebHostEnvironment env;

        public OrderController(IShoppingCartService shoppingCartServices, ShoppingCart shoppingCart, IOrderService orderService, IWebHostEnvironment env)
        {
            this.shoppingCartServices = shoppingCartServices;
            this.shoppingCart = shoppingCart;
            this.orderService = orderService;
            //this.emailService = emailService;
            this.env = env;
        }

        public async Task<IActionResult> Checkout(Order order)
        {
            var items = this.shoppingCartServices.AllProducts();
            this.shoppingCart.ShoppingCartItems = items;

            if (shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("Empty cart", "Your cart is empty, go grab some products");
                TempData.AddErrorMessage(Message);
            }

            if (!ModelState.IsValid)
            {
                // TempData.AddErrorMessage("Please fill in all fields");
                return View(order);
            }

            await orderService.CreateOrderAsync(order).ConfigureAwait(false);
            shoppingCartServices.ClearCart();

            // send email with order details to customer

            var webRoot = env.WebRootPath; //get wwwroot folder

            var pathToFile = env.WebRootPath // get file
                     + Path.DirectorySeparatorChar.ToString()
                     + "templates"
                     + Path.DirectorySeparatorChar.ToString()
                     + "Email"
                     + Path.DirectorySeparatorChar.ToString()
                     + "orderConfirmation.html";

            // read file TODO
            //var builder = new BodyBuilder();
            //using (StreamReader reader = System.IO.File.OpenText(pathToFile))
            //{
            //    builder.HtmlBody = reader.ReadToEnd();
            //}

            //var emailMessage = new EmailMessage
            //{
            //    ToAddresses =
            //    {
            //        new EmailAddress { Name = $"{order.LastName} {order.FirstName}", Address = order.Email }
            //    },
            //    FromAddresses =
            //    {
            //        new EmailAddress { Name = senderEmailName, Address = senderEmailAddress }
            //    },
            //    Subject = $"ShredMates Shop Order {order.OrderId}",
            //    Content = builder.ToString()
            //};

            //this.emailService.SendEmail(emailMessage);

            TempData.AddSuccessMessage("Thank you for your order! Check your email for the order details");
            return RedirectToAction("Index", "Home");
        }
    }
}
