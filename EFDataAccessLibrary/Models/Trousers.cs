using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccessLibrary.Models
{
    public class Trousers : Clothing
    {
        public string Gender { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
    }
}
