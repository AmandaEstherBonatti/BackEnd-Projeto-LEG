using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_LEG.Modelos
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string Status { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime OrderEnd { get; set; }
        public virtual Client Client { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
