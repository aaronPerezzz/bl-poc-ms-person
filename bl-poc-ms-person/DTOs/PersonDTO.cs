using bl_poc_ms_person.Utils;
using bl_poc_ms_person.Utils.Enums;
using System.ComponentModel.DataAnnotations;

namespace bl_poc_ms_person.DTOs
{
    public class PersonDTO
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string? LastName { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [MaxLength(10)]
        [Phone]
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateOnly BirthDay { get; set; }
        [Required]
        [EnumDataType(typeof(MaritalStatus), ErrorMessage = Constants.MSJ_PER07)]
        public string? MaritalStatus { get; set; }
    }
}
