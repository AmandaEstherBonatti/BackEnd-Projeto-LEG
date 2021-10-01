using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_LEG.Modelos
{
    public class Plate
    {
        [Key]
        public int PlateId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
