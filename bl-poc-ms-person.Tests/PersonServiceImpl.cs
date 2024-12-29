using bl_poc_ms_person.DTOs;
using bl_poc_ms_person.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bl_poc_ms_person.Tests
{
    internal class PersonServiceImpl : IPerson
    {
        public Task DeletePersonById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PersonDTO> GetPersonById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonDTO>> GetPersons(PaginationDTO pagination)
        {
            throw new NotImplementedException();
        }

        public Task<PersonDTO> SavePerson(PersonDTO person)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePersonById(int id, PersonDTO person)
        {
            throw new NotImplementedException();
        }
    }
}
