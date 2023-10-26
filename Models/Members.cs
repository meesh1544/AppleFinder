using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppleFinder.Models
{
    public enum Gender
    {
        Male,
        Female,
        other
    }
    public class Members
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only alphabetic letters are allowed.")]
        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage = "Please enter your full name using 30 characters or less.")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only alphabetic letters are allowed.")]
        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "Please enter your full name using 30 characters or less.")]
        public string LastName { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Please enter your address using 50 characters or less.")]
        public string Address { get; set; } = string.Empty; 

        [StringLength(30, ErrorMessage = "Please enter the city using 30 characters or less.")]
        public string City { get; set; } = string.Empty;

        [StringLength(2, ErrorMessage = "Please enter the state using 2 characters.")]
        public string? State { get; set; } = string.Empty;

        [StringLength(10, ErrorMessage = "Zipcode has a maximum length of 10 numbers.")]

        [Required(ErrorMessage = "ZipCode is required")]
        [Display(Name = "Zipcode")]
        public string Zip { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Cell Phone")]
        [Range(7,11)]
        public string Cell { get; set; } = string.Empty;
    }
}
