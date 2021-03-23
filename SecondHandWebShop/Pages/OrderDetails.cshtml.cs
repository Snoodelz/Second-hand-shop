using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecondHandWebShop.Data;
using SecondHandWebShop.Helpers;
using SecondHandWebShop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandWebShop.Pages
{
    public class OrderDetailsModel : PageModel
    {
        private readonly ProductContext _context;

        public OrderDetailsModel(ProductContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Order Order { get; set; }
        public decimal Total { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Order = _context.Order.OrderByDescending(x => x.OrderId).First();

            Total = CartModel.cart.Sum(item => item.Clothes.Price * item.Quantity);

            Order.OrderTotal = Total;

            List<string> OrderItems = new List<string>();

            CartModel.cart.ToList().ForEach(x =>
            {
                OrderItems.Add($"{x.Clothes.Name} * {x.Quantity}");
            });

            var result = string.Join(",", OrderItems);
            Order.OrderItems = result;

            _context.Order.Update(Order);
            await _context.SaveChangesAsync();

            CartModel.cart.Clear();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", CartModel.cart);

            return Page();
        }
    }
}