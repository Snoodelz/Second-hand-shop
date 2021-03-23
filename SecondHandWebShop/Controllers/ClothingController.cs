using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecondHandWebShop.Data;
using SecondHandWebShop.Models;
using Newtonsoft.Json;
using System.IO;

namespace SecondHandWebShop.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClothingController : ControllerBase
    {

        private readonly ProductContext _context;

        public ClothingController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clothing>>> GetClothing()
        {
            return await _context.Clothing.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Clothing>> GetClothing(int id)
        {
            var clothing = await _context.Clothing.FindAsync(id);

            if (clothing == null)
            {
                return NotFound();
            }

            return clothing;
        }

    }
}
