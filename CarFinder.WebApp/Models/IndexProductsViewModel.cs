using System.Collections.Generic;

namespace CarFinder.WebApp.Models
{
    public class IndexCarsViewModel
    {
        public ICollection<IndexCarViewModel> Cars { get; set; }
        public int CarsCount { get; set; }
    }
}
