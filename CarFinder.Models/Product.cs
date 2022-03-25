

namespace CarFinder.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Cars
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public int Trim_id { get; set; }
        public string Trim { get; set; }
        public int Make_id { get; set; }
        public string Make { get; set; }
        public int Model_id { get; set; }
        public string Model { get; set; }
        public int Generation_id { get; set; }
        public string Generation { get; set; }
        public int Body_id { get; set; }
        public string Body { get; set; }
        public int Drive_id { get; set; }
        public string Drive { get; set; }
        public int Gearbox_id { get; set; }
        public string Gearbox { get; set; }
        public int Engine_type_id { get; set; }
        public string Engine_type { get; set; }
        public int Engine_volume { get; set; }
        public int Engine_power { get; set; }
        public int Year { get; set; }
        public string Image { get; set; }
        public DateTime Date_update { get; set; }
        public int Is_active { get; set; }
        public int Old_id { get; set; }
    }
}
