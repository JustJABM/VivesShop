﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VivesShop.Models
{
    public class MenuItem
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public decimal Price { get; set; }
       public string Type { get; set; }
    }
}
