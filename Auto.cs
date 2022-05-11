using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_showroom
{
    abstract class Auto
    {
        public CarBrand Brand { get; set; }
        private List<IAddition> Additions { get; set; }

        protected double carPrice;
        public abstract double CarPrice { get; set; }
        public abstract string CarID { get; }
        public abstract double SummaryPrice { get; }
        public abstract string SummaryInfo { get; }


        protected DateTime manufactureDate;
        public virtual DateTime ManufactureDate
        {
            get => manufactureDate;
            set
            {
                if (value.Year >= 1990 && value <= DateTime.Now)
                    manufactureDate = value;
                else throw new ArgumentException("Вышел срок Эксплуатации");
            }
        }

        public Auto() 
        {
            Additions = new List<IAddition>();
        }
        public Auto(DateTime manufacturedate)
            : this()
        {
            manufactureDate = manufacturedate;
        }

        public abstract string GenerateCarID();
        protected double AdditionsPrice => Additions?.Sum(t => t.Price) ?? 0;
        public string GetAdditionsInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in Additions)
            {
                sb.Append($"{item.Name} - {item.Price} руб.\n");
            }
            sb.Append($"Общая цена всех допов: {AdditionsPrice}");

            return sb.ToString();
        }
        public void AddAddition(IAddition item)
        {
            if (Additions.Any(t => t.Name == item.Name))
                throw new Exception("Данный доп. товар уже добавлен");
            Additions.Add(item);
        }
        public void ClearAdditions() => Additions.Clear();





    } 
}
