using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccessLibrary.Models
{
    public class Jacket : Clothing
    {
        public string Gender { get; set; }
        public string Material { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }
}
