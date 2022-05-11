using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_showroom.Additions
{
    internal class FourWheelDrive : IAddition
    {
        public double Price { get; set; }
        public string Name => "Полный привод";

        public FourWheelDrive(double price)
        {
            Price = price;
        }


    }
}
