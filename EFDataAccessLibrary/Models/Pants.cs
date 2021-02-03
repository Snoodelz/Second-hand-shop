﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccessLibrary.Models
{
    public class Pants
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PantSize { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
    }
}
