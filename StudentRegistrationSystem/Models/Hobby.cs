
namespace StudentRegistrationSystem.Models
{
    public class Hobby
    {
        public Hobby()
        {
            this.objStdHob = new HashSet<StudentHobby>();
        }

        public int HobbyId { get; set; }
        public string HobbyName { get; set; }
        public ICollection<StudentHobby>? objStdHob { get; set; }

    }
}
