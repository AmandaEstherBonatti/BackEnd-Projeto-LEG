using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_LEG.Modelos
{
    public class Restaurant:User
    {
        public string Cnpj { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
    }
}
