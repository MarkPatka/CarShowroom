using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_showroom.Additions
{
    internal class SafetyBag : IAddition
    {
        public double Price { get; set; }
        public string Name => "Подушки безопасности";

        public SafetyBag(double price)
        {
            Price = price;
        }
    }
}
