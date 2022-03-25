using Newtonsoft.Json;
using CarFinder.Data;
using CarFinder.Models;
using CarFinder.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CarFinder.ConsoleApp
{
    internal class Program
    {
        //private 
        public static void UsingMethod(int mode)
        {
            Console.Clear();
            CarFinderService service = new CarFinderService();
            //Console.WriteLine(mode);
            Console.WriteLine("Make {Model} Year");
            Console.WriteLine("BMW {X5} 2003");
            Console.WriteLine("Using the examples above enter the car information.");
            string carinfo = Console.ReadLine();
            DataTable dt = new DataTable();
            List<Cars> L = service.DetermineGet(carinfo).ToList();
            List<int> idList = new List<int>();
            //var info = DbSet<Cars>().ToList();
            if (mode == 1)
            {
                foreach (var a in L)
                {
                    idList.Add(a.Id);
                    Console.WriteLine($"({a.Id}) {a.Make} {a.Model} {a.Year} {a.Trim} {a.Generation} {a.Body} {a.Drive} {a.Gearbox} {a.Engine_type} {a.Engine_volume} {a.Engine_power}");
                }
                do
                {
                    Console.WriteLine("Select your model!");
                    string idNotFormatted = Console.ReadLine();
                    int id = Int32.TryParse(idNotFormatted, out _) ? Int32.Parse(idNotFormatted) : -1;
                    if (idList.Contains(id))
                    {
                        Console.Clear();
                        Cars car = service.GetCar(id);
                        Console.WriteLine($"Trim: {car.Trim}");
                        Console.WriteLine($"Make: {car.Make}");
                        Console.WriteLine($"Model: {car.Model}");
                        Console.WriteLine($"Generation: {car.Generation}");
                        Console.WriteLine($"Body: {car.Body}");
                        Console.WriteLine($"Gearbox: {car.Gearbox}");
                        Console.WriteLine($"Engine Type: {car.Engine_type}");
                        Console.WriteLine($"Engine Volume: {car.Engine_volume}");
                        Console.WriteLine($"Engine Power: {car.Engine_power}");
                        Console.WriteLine($"Year of manufacture: {car.Year}");
                        Console.WriteLine($"Image: https://info-km.com/api/GoogleAPI/fetchGoogleAPI.php?img={car.Image}");

                        break;
                    }
                    else Console.WriteLine("Wrong model id. Please try again!");
                } while (true);
            }
            else if (mode == 2)
            {
                Console.Clear();
                string json = JsonConvert.SerializeObject(L);
                Console.WriteLine(json);

            }

            //L.ForEach(i => Console.Write("{0}\t", i));
            //Console.WriteLine(context.Cars.Any());
        }
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome this is Find my Car App");
            Console.WriteLine("In this program you can find more information about your car.");
            Console.WriteLine("Do you want to use the Standard mode or the API one?");
            Console.WriteLine("1. Standard (This is selected by default)");
            Console.WriteLine("2. API");
            string modeNotFormatter = Console.ReadLine();
            int mode = Int32.TryParse(modeNotFormatter, out _) ? Int32.Parse(modeNotFormatter) : 1;
            switch (mode)
            {
                case 1:
                    UsingMethod(mode);
                    break;
                case 2:
                    UsingMethod(mode);
                    break;
                default:
                    UsingMethod(1);
                    break;
            }

        }
    }
}
