

namespace CarFinder.Data
{
    using CarFinder.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class DataSeeder
    {
        public DataSeeder()
        {
            Run();
        }

        public void Run()
        {
            AppDbContext context = new AppDbContext();
            Console.WriteLine(context.Cars.Any());

        }
    }
}
