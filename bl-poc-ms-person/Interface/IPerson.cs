using bl_poc_ms_person.DTOs;

namespace bl_poc_ms_person.Interface
{
    public interface IPerson
    {
        Task<List<PersonDTO>> GetPersons(PaginationDTO pagination);
        Task<PersonDTO> GetPersonById(int id);
        Task UpdatePersonById(int id, PersonDTO person);
        Task DeletePersonById(int id);
        Task<PersonDTO> SavePerson(PersonDTO person);
    }
}
