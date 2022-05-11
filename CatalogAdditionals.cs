using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_showroom.Additions
{
    static class CatalogAdditionals
    {
        public static IAddition[] AdditionalItems = new IAddition[4]
        {
            new AutomaticTransmission(15000),
            new FourWheelDrive(12000),
            new SafetyBag(9000),
            new Wheels(10000)
        };
    }
}
