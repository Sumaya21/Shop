﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class CartDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
}