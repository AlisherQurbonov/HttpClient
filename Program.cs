using System;
using System.Text.Json;
using System.Threading.Tasks;
using lesson10.Dto.AsmaAlHusna;
using lesson10.Dto.PrayerTime;
using lesson10.Dto.User;
using lesson10.Services;

namespace lesson10
{
   static class Program
     {
        // private static string usersApi = "https://randomuser.me/api/";
        // private static string prayerTimeApi = "http://api.aladhan.com/v1/timingsByCity?city=ArRiyad&country=SaudiaArabia&method=8";
        // private static string AsmaUlHusniApi = "http://api.aladhan.com/asmaAlHusna/:number";


         public static string ToJson(this object obj, bool indented = false)
        {
            var settings = new JsonSerializerOptions()
            {
                WriteIndented = indented
            };
            
            return JsonSerializer.Serialize(obj, settings);
        }
        
        private static string AsmaAlHusna = $"http://api.aladhan.com/asmaAlHusna/";
        private static string prayerTimeApi = $"http://api.aladhan.com/v1/timingsByCity?city=&country=&method=8";
        private static void changeAsmaAlHusna(int number)
        {
            AsmaAlHusna = $"http://api.aladhan.com/asmaAlHusna/{number}";
        }
        private static void changePrayerTimeApi(string countrie, string citie)
        {
            prayerTimeApi = $"http://api.aladhan.com/v1/timingsByCity?city={citie}&country={countrie}&method=8";
        }

        static async Task Main()
        {
            
            var numberName = int.Parse(Console.ReadLine());

              changeAsmaAlHusna(numberName);

              var httpService = new HttpClientService();
            var resultAsmaAlHusna = await httpService.GetObjectAsync<Root>(AsmaAlHusna);

            if(resultAsmaAlHusna.IsSuccess)
            {
                var settings = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };

                var json = JsonSerializer.Serialize(resultAsmaAlHusna.Data.Data, settings);
                Console.WriteLine($"{json}");
            }
            else
            {
                Console.WriteLine($"{resultAsmaAlHusna}");
                
            }


        }
         
        // static async Task Main(string[] args)
        // {
        //     var httpService = new HttpClientService();
            // var result = await httpService.GetObjectAsync<PrayerTime>(prayerTimeApi);

            // if(result.IsSuccess)
            // {
            //     var settings = new JsonSerializerOptions()
            //     {
            //         WriteIndented = true
            //     };

            //     var json = JsonSerializer.Serialize(result.Data, settings);
            //     Console.WriteLine($"{json}");
            // }
            // else
            // {
            //     Console.WriteLine($"{result.ErrorMessage}");
            // }
        //      var result = await httpService.GetObjectAsync<PrayerTime>(prayerTimeApi);
       

        //     if(result.IsSuccess)
        //     { 
               
        //         Console.WriteLine($"{result.Data.Data.Timings.Fajr}");
        //         Console.WriteLine($"{result.Data.Data.Timings.Sunrise}");
        //         Console.WriteLine($"{result.Data.Data.Timings.Dhuhr}");
        //         Console.WriteLine($"{result.Data.Data.Timings.Asr}");
        //         Console.WriteLine($"{result.Data.Data.Timings.Sunset}");
        //         Console.WriteLine($"{result.Data.Data.Timings.Maghrib}");
        //         Console.WriteLine($"{result.Data.Data.Timings.Isha}");
        //         Console.WriteLine($"{result.Data.Data.Timings.Imsak}");
        //         Console.WriteLine($"{result.Data.Data.Timings.Midnight}");    
        //     }
        //     else
        //     {
        //         Console.WriteLine($"{result.ErrorMessage}");
        //     }

            
        // }
        // static async Task Main_user(string[] args)
        // {
        //     var httpService = new HttpClientService();
        //     var result = await httpService.GetObjectAsync<User>(usersApi);

        //     if(result.IsSuccess)
        //     {
        //         Console.WriteLine($"{result.Data.Results[0].Name.First}");
        //     }
        //     else
        //     {
        //         Console.WriteLine($"{result.ErrorMessage}");
        //     }
            
        // }


       
            
            
        
    }
}
