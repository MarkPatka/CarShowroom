using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Car_showroom.MailRepo;

namespace Car_showroom
{
    internal static class ClientsList
    {
        private static Dictionary<string, string> clientsBase = new()
        {
            { "al1992@gmail.com", "Алексей И.Г."},
            { "crusher777@gmail.com", "Петрова М.Р"},
            { "yayaN25@gmail.com", "Иванов А.А" },
            { "elena.k.@gmail.com", "Иванов А.А" }

        };

        public static string GetClientName(string email)
        {
            if (clientsBase.TryGetValue(email, out string? name)) return name;
            else
                return $"Пользователь с Email: {email} не найден";
        }
        
        public static string GetClientEmail(string name)
        {
            var fltEmails = clientsBase
                            .Where(v => v.Value.ToLower().Replace('.', ' ').Trim()
                                   .Equals(name.ToLower().Replace('.', ' ').Trim()))
                            .Select(v => v.Key);

            StringBuilder builder = new StringBuilder();

            if (fltEmails.Count() > 1) builder.Append($"Найдено клиентов с именем ({name}): {fltEmails.Count()}\n");
            
            foreach (var fltEmail in fltEmails) builder.Append($"{fltEmail}\n");

            return builder.ToString();
        }
    }
}
