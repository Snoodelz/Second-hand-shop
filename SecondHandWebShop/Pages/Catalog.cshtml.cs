using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecondHandWebShop.Data;
using SecondHandWebShop.Models;
using System.Net.Http;
using SecondHandWebShop.Models.ExternalAPI;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace SecondHandWebShop.Pages
{
    public class CatalogModel : PageModel
    {
        private readonly ProductContext _context;

        public CatalogModel(ProductContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string Category { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ClothingBrandsDropdown { get; set; }

        public SelectList Brands { get; set; }
        public WeatherData CurrentWeather { get; set; }

        public IList<Clothing> Clothing { get; set; }
        public IList<Clothing> AllClothing { get; set; }
        public IEnumerable<Clothing> Merchandise { get; set; }
        public IEnumerable<Clothing> AllHats { get; set; }
        public IEnumerable<Clothing> AllJackets { get; set; }
        public IEnumerable<Clothing> AllJewelries { get; set; }
        public IEnumerable<Clothing> AllShirts { get; set; }
        public IEnumerable<Clothing> AllShoes { get; set; }
        public IEnumerable<Clothing> AllTrousers { get; set; }
        public IEnumerable<Clothing> ProductsOnDiscount { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> brandQuery = from x in _context.Clothing
                                            orderby x.Brand
                                            select x.Brand;

            var clothings = from m in _context.Clothing
                            select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                clothings = clothings.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ClothingBrandsDropdown))
            {
                clothings = clothings.Where(x => x.Brand == ClothingBrandsDropdown);
            }
            Brands = new SelectList(await brandQuery.Distinct().ToListAsync());
            Clothing = await clothings.ToListAsync();

            AllClothing = _context.Clothing.Where(c => c.Category != "Merchandise").ToList();
            Merchandise = _context.Clothing.Where(c => c.Category == "Merchandise").ToList();
            AllHats = _context.Clothing.Where(c => c.Category == "Hat").ToList();
            AllJackets = _context.Clothing.Where(c => c.Category == "Jacket").ToList();
            AllJewelries = _context.Clothing.Where(c => c.Category == "Jewelry").ToList();
            AllShirts = _context.Clothing.Where(c => c.Category == "Shirt").ToList();
            AllShoes = _context.Clothing.Where(c => c.Category == "Shoe").ToList();
            AllTrousers = _context.Clothing.Where(c => c.Category == "Trouser").ToList();
            ProductsOnDiscount = _context.Clothing.Where(d => d.Discount != 0).ToList();

            var client = new HttpClient();
            Task<string> getWeatherStringTask = client.GetStringAsync($"https://api.weatherbit.io/v2.0/current?key=a2ba4dec961441e2ae9bf092c64f9e11&lang=sv&city=stockholm");
            string weatherString = await getWeatherStringTask;
            CurrentWeather = JsonSerializer.Deserialize<WeatherData>(weatherString);
        }
        public static bool AlreadyInCart(Clothing product)
        {
            var cartItems = CartModel.cart;

            if (cartItems != null)
            {
                foreach (var item in cartItems)
                {
                    if (item.Clothes.Id == product.Id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
