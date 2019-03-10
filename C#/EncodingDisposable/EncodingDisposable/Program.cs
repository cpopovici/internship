using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingDisposable
{
    class Program
    {
        static void Main(string[] args)
        {
            // Encodig File Stream
            string path = "testfile.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("Unicode charachter: \u0987 \u098B \u0BA3", Encoding.Unicode);
                writer.WriteLine("UTF8 SOME TEXT EXAMPLE!", Encoding.UTF8);
            }

            using (StreamWriter writer = new StreamWriter("date.ini"))
            {
                DateTime date = new DateTime(2019, 5, 4, 10, 0, 0);
                writer.WriteLine(date);
            }

            using (StreamReader reader = new StreamReader("date.ini"))
            {
                string rawDate = reader.ReadLine();
                DateTime readedDate = DateTime.Parse(rawDate);
                Console.WriteLine("Readed DateTime from File: {0}", readedDate.ToLocalTime());
            }

            // DateTime
            DateTime now = DateTime.Now;
            var result = TimeSpan.FromDays(1) + TimeSpan.FromHours(4.35) + TimeSpan.FromMinutes(48);
            DateTime flightStartTime = new DateTime(2019, 3, 10, 10, 30, 0);
            TimeSpan flightTime = TimeSpan.FromHours(3) + TimeSpan.FromMinutes(25);
            DateTimeOffset arrivalTime = new DateTimeOffset(flightStartTime + flightTime, TimeSpan.FromHours(3));
            TimeZone currentZone = TimeZone.CurrentTimeZone;

            Console.WriteLine("Date time now: {0}", now);
            Console.WriteLine("Today is {0}", now.DayOfWeek);
            Console.WriteLine("Yesterday was {0}", now.AddDays(-1).DayOfWeek);
            Console.WriteLine("TimeSpan result: {0} day : {1} hours : {2} minutes", result.Days, result.Hours, result.Minutes);
            Console.WriteLine("Flight start at {0} UTC {1} and arive time is {2}", flightStartTime, currentZone.GetUtcOffset(flightStartTime), arrivalTime);
            Console.WriteLine("Current Time Zone: {0}", currentZone.StandardName);

            // Culture example
            Console.WriteLine();
            CultureInfo enUs = new CultureInfo("en-US");
            Console.WriteLine(enUs.DisplayName + " - currency symbol: 999" + enUs.NumberFormat.CurrencySymbol);
            Console.WriteLine(enUs.DisplayName + " - DateTime Format: " + now.ToString(enUs));
            Console.WriteLine();
            CultureInfo deDe = new CultureInfo("de-DE");
            Console.WriteLine(deDe.DisplayName + " - currency symbol: 999" + deDe.NumberFormat.CurrencySymbol);
            Console.WriteLine(deDe.DisplayName + " - DateTime Format: " + now.ToString(deDe));
            Console.WriteLine();
            CultureInfo ruRu = new CultureInfo("ru-RU");
            Console.WriteLine(ruRu.DisplayName + " - currency symbol: 999" + ruRu.NumberFormat.CurrencySymbol);
            Console.WriteLine(ruRu.DisplayName + " - DateTime Format: " + now.ToString(ruRu));
            Console.ReadKey();

        }
    }
}
