namespace CarFinder.Services
{
    using Data;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class CarFinderService
    {
        private AppDbContext context = new AppDbContext();
        public ICollection<Cars> GetCars()
        {
            return context.Cars.ToList();
        }
        public Cars GetCar(int id)
        {
            return context.Cars.Find(id);
        }
        public static bool IsValidYear(string year)
        {
            return Regex.IsMatch(year, @"^(19|20)\d{2}$");
        }
        public static bool IsValidMake(string make)
        {
            return Regex.IsMatch(Regex.Replace(make, @"\s+", ""), @"^\w{2,15}$");
        }
        public static bool IsValidModel(string model)
        {
            return Regex.IsMatch(Regex.Replace(Regex.Replace(model, @"\s+", ""), @"[^0-9a-zA-Z:,]+", ""), @"^\w{1,23}$");
        }
        public int CarsCount()
        {
            return this.context.Cars.Count();   
        }
        public List<Cars> GetAllMake()
        {
            var car = context.Cars.FromSqlRaw("SELECT * FROM (SELECT *, Row_number() OVER(partition BY make ORDER BY id DESC) rn FROM [cardatabase].[dbo].[cars]) a WHERE rn = 1 ORDER BY make ASC;").ToList();
            return car;
        }
        public string GetByYear(int year)
        {
            var caryear = new SqlParameter("year", year);
            var car = context.Cars.FromSqlRaw("SELECT * FROM [cardatabase].[dbo].[cars] WHERE year = @caryear;", caryear).ToList();
            return car.ToString();
        }
        public string GetByGearbox(string gearbox)
        {
            var cargearbox = new SqlParameter("year", gearbox);
            var car = context.Cars.FromSqlRaw("SELECT * FROM [cardatabase].[dbo].[cars] WHERE gearbox = @cargearbox;", cargearbox).ToList();
            return car.ToString();
        }
        public string GetByBody(string body)
        {
            var carbody = new SqlParameter("year", body);
            var car = context.Cars.FromSqlRaw("SELECT * FROM [cardatabase].[dbo].[cars] WHERE body = @carbody;", carbody).ToList();
            return car.ToString();
        }
        public ICollection<Cars> GetByMake(string make)
        {
            var carmake = new SqlParameter("carmake", make);
            var car = context.Cars.FromSqlRaw("SELECT * FROM [cardatabase].[dbo].[cars] WHERE make = @carmake;", carmake).ToList();
            return car;
        }
        public ICollection<Cars> GetByMakeAndModel(string make, string model)
        {
            var carmake = new SqlParameter("make", make);
            var carmodel = new SqlParameter("model", model);
            var car = context.Cars.FromSqlRaw("SELECT * FROM [cardatabase].[dbo].[cars] WHERE make = @make AND model = @model;", parameters: new[] { carmake, carmodel }).ToList();
            return car;
        }
        public ICollection<Cars> GetByMakeModelAndYear(string make, string model, int year)
        {
            var carmake = new SqlParameter("make", make);
            var carmodel = new SqlParameter("model", model);
            var caryear = new SqlParameter("year", year);
            var car = context.Cars.FromSqlRaw("SELECT * FROM [cardatabase].[dbo].[cars] WHERE make = @make AND model = @model AND year = @year;", parameters: new[] { carmake, carmodel, caryear }).ToList();
            return car;
        }
        public static string[] RegexCarModel(string model)
        {
            return model.Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
        }
        public void DeleteCar(int id)
        {
          var carToDelete = context.Cars.Find(id);

          if (carToDelete != null)

              context.Cars.Remove(carToDelete);

          context.SaveChanges();

          Console.WriteLine("Car Deleted");
        }

        public void UpdateCar(int id, string make, string model, string year)
        {
            var carToUpdate = context.Cars.Find(id);
            
            if (carToUpdate != null)
            
            {
            
                carToUpdate.Make = make;
            
                carToUpdate.Model = model;
            
                carToUpdate.Year = Int32.Parse(year);
            
                context.SaveChanges();
            
                Console.WriteLine("Car Updated");
            
            }
            else Console.WriteLine("Car Not Found");
        }
        public ICollection<Cars> DetermineGet(string searchParam)
        {
            string[] parameters = RegexCarModel(searchParam);
            switch (parameters.Length)
            {
                case 1:
                    if (IsValidMake(parameters[0].Trim()))
                    {
                         return GetByMake(parameters[0].Trim());
                    }
                    else
                    {
                        throw new ArgumentException("Incorrectly Formatted Car Make");
                    }
                case 2:
                    if (IsValidMake(parameters[0].Trim()) && IsValidModel(parameters[1].Trim()))
                    {
                        return GetByMakeAndModel(parameters[0].Trim(), parameters[1].Trim());
                    }
                    else
                    {
                        throw new ArgumentException("Incorrectly Formatted Car Make or Car Model");
                    }
                case 3:
                    if (IsValidMake(parameters[0].Trim()) && IsValidModel(parameters[1].Trim()) && IsValidYear(parameters[2].Trim()))
                    {
                        return GetByMakeModelAndYear(parameters[0].Trim(), parameters[1].Trim(), Int32.Parse(parameters[2].Trim()));
                    }
                    else
                    {
                        throw new ArgumentException("Incorrectly Formatted Car Make or Car Model");
                    }
                default:
                    throw new ArgumentException("Invalid car id");

            }
        }

    }
}
