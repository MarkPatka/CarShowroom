using Car_showroom.Additions;
using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;



namespace Car_showroom
{
    internal class Automobile : Auto
    {
        private static string carId = string.Empty;
        public override double CarPrice
        {
            get => carPrice;
            set
            {
                if (value > 0)
                    carPrice = value;
                else
                    throw new ArgumentException("Значение цены автомобиля не может быть отрицательным");
            }
        }
        public override string CarID => carId;

        public override double SummaryPrice => CarPrice + AdditionsPrice;


        public override string SummaryInfo
        {
            get
            {
                return $"Автомобиль: {Brand}\nID: {CarID}\n" +
                       $"Стоимость в базовой комплектации: {CarPrice}\n\nДОПЫ:\n{GetAdditionsInfo()}\n" +
                       $"Итоговая стоимость, вместе с допами: {SummaryPrice}\n" +
                       $"==================================================================";

            }
        }



        public Automobile(CarBrand brand, double price, DateTime mdt)
            : base(mdt)
        {
            Brand = brand;
            CarPrice = price;
            GenerateCarID();
        }

        public override string GenerateCarID()
        {
            DateTimeOffset DT = new(DateTime.Now);
            StringBuilder SB = new();

            int ID = (int)(DT.ToUnixTimeMilliseconds() % 1000000000);
            SB.Append(ID.ToString());

            for (int i = 3; i < SB.Length; i += 4) SB.Insert(i, '-');

            carId = SB.ToString();
            return carId;
        }


    }
}
