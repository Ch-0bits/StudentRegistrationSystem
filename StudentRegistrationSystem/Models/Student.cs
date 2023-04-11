using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string FName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LName { get; set; }
        [Required]
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
