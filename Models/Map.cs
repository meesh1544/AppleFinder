using System.ComponentModel.DataAnnotations;

namespace AppleFinder.Models
{
    public class Map
    {
        [Display(Name = "Map ID")]
        public int MapID { get; set; }
        public string? Name { get; set; }
    }
}
