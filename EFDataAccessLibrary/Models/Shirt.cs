using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccessLibrary.Models
{
    public class Shirt : Clothing
    {
        public string Gender { get; set; }
        public string Material { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
    }
}
