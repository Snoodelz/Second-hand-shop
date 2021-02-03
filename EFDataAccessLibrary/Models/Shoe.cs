using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccessLibrary.Models
{
    public class Shoe : Clothing
    {
        public string Gender { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
    }
}
