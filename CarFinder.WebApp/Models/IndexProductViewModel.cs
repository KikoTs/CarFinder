using CarFinder.Models;
using System.Collections.Generic;

namespace CarFinder.WebApp.Models
{
    public class IndexCarViewModel
    {
        public List<Cars>? Cars { get; set; }
        public string? SearchString { get; set; }
    }
}
