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
        public Clothing Clothing { get; set; }
        public decimal Total { get; set; }
        public List<Item> CustomerOrder { get; set; }

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

            List<Item> customerOrder = new List<Item>();

            CartModel.cart.ToList().ForEach(x =>
            {
                customerOrder.Add(x);
            });

            CustomerOrder = customerOrder;

            foreach (var item in CartModel.cart)
            {
                if (item.Clothes.Category == "Merchandise")
                {
                    for (int i = 0; i < item.Quantity; i++)
                    {
                        item.Clothes.StockBalance--;
                        item.Clothes.SoldMerch++;
                    }
                }
                else
                {
                    item.Clothes.StockBalance--;
                }
                _context.Clothing.Update(item.Clothes);
            }

            _context.Order.Update(Order);
            await _context.SaveChangesAsync();

            CartModel.cart.Clear();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", CartModel.cart);

            return Page();
        }
    }
}
