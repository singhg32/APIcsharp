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
            string baseApi = " https://www.boredapi.com/api/activity?type= ";



            Console.WriteLine("Loading data...");
            var loader = new ActivityLoader(baseApi);
            bool run = true;
            while (run){
                Console.WriteLine("What type of activity would you like to do? Leave blank for any.");
                string type = Console.ReadLine();
                await loader.GetActivities(type);
                if (loader.Type == type.ToLower() || type == "")
                {
                    Console.WriteLine("Loading...");
                }
                else if (loader.Type != type.ToLower())
                {
                    Console.WriteLine("That is not a valid type of activity. Loading random instead.");
                }


                loader.DisplayData();

            
            
            }


        }
    }      


}