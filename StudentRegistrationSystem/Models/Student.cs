using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace StudentRegistrationSystem.Models
{
    public class Student
    {
        public Student()
        {
            this.objStdHob = new HashSet<StudentHobby>();
        }       

        [Key]
        public int StudentId { get; set; }

        [Required]
        [DisplayName("First Name")]
        [MaxLength(32)]
        [RegularExpression(@"^[^<>!@#$%^&*(),.?':{}|<>]*$", ErrorMessage = "Special characters are not allowed.")]
        public string FName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [MaxLength(32)]
        [RegularExpression(@"^[^<>!@#$%^&*(),.?':{}|<>]*$", ErrorMessage = "Special characters are not allowed.")]
        public string LName { get; set; }

        
        [Required]
        //[Range(typeof(DateTime), "1/1/1900", "1/1/2005", ErrorMessage = "You should be 18 years or older.")]
        [AgeAbove18(ErrorMessage = "Date must be lower than 18 years from today.")]
        
        public DateTime DOB { get; set; }

        [Required]
        public string Course { get; set; }

        [NotMapped]
        public string[] Hobbies{ get; set; }


        public ICollection<StudentHobby> objStdHob { get; set; }

        [NotMapped]
        public List<SelectListItem>? hobbiesList { get; set; }

    }
}
