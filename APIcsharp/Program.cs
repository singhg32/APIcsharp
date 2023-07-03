using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.Threading.Tasks; 
using APIcsharp.Class;
using static System.Net.WebRequestMethods;

namespace APIcsharp
{
    internal class Program
    {
        static async Task Main()
        {
            string baseApi = "https://www.boredapi.com/api/activity?";



            Console.WriteLine("Loading data...");
            Console.WriteLine("Type options: \nEducation\nRecreational\nSocial\nDIY\nCharity\nCooking\nRelaxation\nMusic\nBusywork");
            var loader = new ActivityLoader(baseApi);
            bool run = true;
            while (run){
                Console.WriteLine("What type of activity would you like to do? Leave blank for any.");
                string type = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("How many participants would you need to have? Leave blank for any.");
                string participants = Console.ReadLine() ?? string.Empty; 
                await loader.GetActivities(type, participants);
                if ((loader.Type == type.ToLower() || type == "") && Int32.TryParse(participants, out int result))
                {
                    Console.WriteLine("Loading...");
                }
                else if (loader.Type != type.ToLower())
                {
                    Console.WriteLine("That is not a valid type of activity. Loading random instead.");
                }
                else if (!Int32.TryParse(participants, out int result2))
                {
                    Console.WriteLine("That is not a valid number of participants");
                }

                loader.DisplayData();

            
            
            }


        }
    }      


}