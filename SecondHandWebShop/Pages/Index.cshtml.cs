﻿using Microsoft.AspNetCore.Mvc;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandWebShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly EFDataAccessLibrary.DataAccess.ProductContext _context;

        public IndexModel(EFDataAccessLibrary.DataAccess.ProductContext context)
        {
            _context = context;
        }
        
        public List<Hat> Hats { get; set; }
        public List<Jacket> Jackets { get; set; }

        public void OnGet()
        {
            Hats = _context.Hats.ToList();
            Jackets = _context.Jackets.ToList();

        }
    }
}
