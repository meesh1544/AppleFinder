using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppleFinder.Models
{
    public class Apples
    {
        public int ApplesID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

}
