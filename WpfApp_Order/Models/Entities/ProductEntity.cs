﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_Order.Models.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null;
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public ICollection<OrderEntity> Orders { get; set; }
    }
}
