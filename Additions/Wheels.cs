using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_showroom.Additions
{
    internal class Wheels : IAddition
    {
        public double Price { get; set; }
        public string Name => "Литые Диски";

        public Wheels(double price)
        {
            Price = price;
        }
    }
}
