using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistrationSystem.Models
{
    public class StudentHobby
    {
        public int Id { get; set; }
        public int HobbyId { get; set; }
        public int StudentId { get; set; }
        
        public Student student { get; set; }
        
        public Hobby hobby { get; set; }
    }
}
