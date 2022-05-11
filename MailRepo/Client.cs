using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_showroom.MailRepo
{
    internal class Client
    {
        public string Name { get; set; }

        private string email = string.Empty;
        public string Email 
        {
            get => email;
            set
            {
                if (!value.Contains('@'))
                    throw new ArgumentException("Проверьте правильность введенного адреса почты!");
                email = value;
            }
        }

        public Client(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
