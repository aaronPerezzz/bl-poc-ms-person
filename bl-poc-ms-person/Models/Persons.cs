using System.ComponentModel.DataAnnotations;

namespace bl_poc_ms_person.Models
{
    public class Persons
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required]
        public DateOnly BirthDay { get; set; }
        public string MaritalStatus { get; set; }
        [Required]
        public bool IsActive { get; set; }

    }
}
