using System.ComponentModel.DataAnnotations;

namespace AppleFinder.Models
{
    public class Orchard
    {

        public int OrchardId { get; set; }
        [Display(Name = "Map Id")]

        public int MapID {get; set;}
        public Map? Map { get; set;}
        [Display(Name = "Apples ID")]
        public int ApplesID { get; set; }
        public Apples? Apples { get; set; }
        
    }
}

