﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_LEG.Modelos
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public virtual Order Order { get; set; }
        public virtual Plate Plate { get; set; }
    }
}
