using AutoMapper;
using bl_poc_ms_person.DTOs;
using bl_poc_ms_person.Models;

namespace bl_poc_ms_person.Mapper
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Persons, PersonDTO>().ReverseMap();
        }
    }
}
