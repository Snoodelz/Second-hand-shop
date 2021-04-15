using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecondHandWebShop.Data;
using SecondHandWebShop.Helpers;
using SecondHandWebShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SecondHandWebShop.Pages
{
    public class CartModel : PageModel
    {
        private readonly ProductContext _context;

        public CartModel(ProductContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }
        public Clothing Product { get; set; }
        public IEnumerable<Clothing> Merchandise { get; set; }
        public IEnumerable<Clothing> ProductsOnDiscount { get; set; }
        public static List<Item> cart { get; set; }
        public decimal Total { get; set; }

        public void OnGet()
        {
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            ProductsOnDiscount = _context.Clothing.Where(d => d.Discount > 0).ToList();

            Merchandise = _context.Clothing.Where(c => c.Category == "Merchandise").ToList();
        }

        public IActionResult OnGetDelete(string id)
        {
            Product = _context.Clothing.Find(Convert.ToInt32(id));
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            var index = Exists(cart, id);

            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return RedirectToPage("Cart");
        }

        public IActionResult OnGetBuy(string id)
        {
            Product = _context.Clothing.Find(Convert.ToInt32(id));
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<Item>();
                cart.Add(new Item()
                {
                    Clothes = Product,
                    Quantity = 1
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                var index = Exists(cart, id);
                if (index == -1)
                {
                    cart.Add(new Item()
                    {
                        Clothes = Product,
                        Quantity = 1
                    });
                }
                else
                {
                    if (cart[index].Clothes.Category == "Merchandise" && cart[index].Quantity < Product.StockBalance)
                    {
                        cart[index].Quantity++;
                    }
                }
                _context.Clothing.Update(Product);
                _context.SaveChangesAsync();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return RedirectToPage("Cart");
        }

        public IActionResult OnPostUpdate(int quantity, string id)
        {
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            var index = Exists(cart, id);

            if (cart[index].Clothes.Category == "Merchandise")
            {
                cart.ElementAt(index).Quantity = quantity;
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("Cart");
        }

        private int Exists(List<Item> cart, string id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Clothes.Id == Convert.ToInt32(id))
                {
                    return i;
                }
            }
            return -1;
        }

    }
}