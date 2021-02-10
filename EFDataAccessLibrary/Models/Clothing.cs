using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccessLibrary.Models
{
    public class Clothing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
        public string Brand { get; set; }
        public string TypeOf { get; set; }

        public Clothing()
        {
            Date = DateTime.Now;
        }
    }
}
