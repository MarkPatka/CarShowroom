using Car_showroom.Additions;
using Car_showroom;
using System.Text;
using Enums;
using System.Threading;
using Car_showroom.MailRepo;


Random rnd = new Random();
Automobile[] automobiles = new Automobile[rnd.Next(5, 10)];

for (int i = 0; i < automobiles.Length; i++)
{
    automobiles[i] = new Automobile(
        (CarBrand)rnd.Next(0, Enum.GetValues(typeof(CarBrand)).Length),
        rnd.Next(1, 50) * 500000 + 1000000,
        new DateTime(2022, 01, 01).AddDays(-rnd.Next(1, 5000)));
    Thread.Sleep(10);
    int cnt = rnd.Next(0, CatalogAdditionals.AdditionalItems.Length + 1);
    while (cnt > 0)
    {
        try
        {
            automobiles[i].AddAddition(CatalogAdditionals.AdditionalItems[rnd.Next(0, CatalogAdditionals.AdditionalItems.Length)]);
            cnt--;
        }
        catch { } // Добавление аналогичного допа вызовет Ex. у метода AddAddition(),
                  // чтобы не прерывать цикл назначения "допов" автомобилям я его подавляю.
    }
}
StringBuilder sb = new StringBuilder();

foreach (Automobile automobile in automobiles)
{
    Console.WriteLine(automobile.SummaryInfo);
    sb.Append($"{automobile.SummaryInfo}\n");
}

Console.WriteLine(sb.ToString());
//Console.WriteLine(ClientsList.GetClientName("crusher777@gmail.com"));
//Console.WriteLine(ClientsList.GetClientEmail("Иванов А.А"));

//MailG mg = new MailG("receiver@gmail.com", "Ololo", sb.ToString());
//mg.Send(mg.Message);



Console.ReadKey();

