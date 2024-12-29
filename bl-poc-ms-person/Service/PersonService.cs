

using AutoMapper;
using bl_poc_ms_person.Context;
using bl_poc_ms_person.DTOs;
using bl_poc_ms_person.Exceptions;
using bl_poc_ms_person.Interface;
using bl_poc_ms_person.Models;
using bl_poc_ms_person.Utils;
using bl_poc_ms_person.Utils.Pagination;
using Microsoft.EntityFrameworkCore;
using System.Net;

/**
 *  @author Aaron Pérez
 *  @since 27/12/2024
 */
namespace bl_poc_ms_person.Service
{
    public class PersonService : IPerson
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PersonService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Hace la eliminación logica de una persona
        /// </summary>
        /// <param name="id"></param>
        public async Task DeletePersonById(int id)
        {
            var queryPerson = await FindPersonById(id);
            queryPerson.IsActive = Constants.FALSE;
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Busca una persona por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>PersonDTO</returns>
        public async Task<PersonDTO> GetPersonById(int id)
        {
            Persons findPersonById = await FindPersonById(id);
            return mapper.Map<PersonDTO>(findPersonById);
        }

        /// <summary>
        /// Optiene todas las persona por paginación
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>List<PersonDTO></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<List<PersonDTO>> GetPersons(PaginationDTO pagination)
        {
            IQueryable<Persons> queryPerson = context.Persons.Where(p => p.IsActive).AsQueryable();
            if (queryPerson.Count() < Constants.NUM1)
            {
                throw new CustomException(Constants.MSJ_PER01, HttpStatusCode.NotFound);
            }

            List<Persons> personPagination = await queryPerson.Paginar(pagination).ToListAsync();
            return mapper.Map<List<PersonDTO>>(personPagination);
        }

        /// <summary>
        /// Crea nuevo resgistro
        /// </summary>
        /// <param name="person"></param>
        /// <returns>PersonDTO</returns>
        /// <exception cref="CustomException"></exception>
        public async Task<PersonDTO> SavePerson(PersonDTO person)
        {
            Persons emailExist = await context.Persons.FirstOrDefaultAsync(p => p.Email == person.Email);
            if (emailExist != null)
            {
                throw new CustomException(Constants.MSJ_PER04, HttpStatusCode.BadRequest);
            }

            Persons newPerson = mapper.Map<Persons>(person);
            newPerson.IsActive = Constants.TRUE;

            context.Add(newPerson);

            try
            {
                await context.SaveChangesAsync();
                return person;
            }
            catch (Exception ex)
            {
                throw new CustomException(Constants.MSJ_PER04 + ex.Message, HttpStatusCode.BadRequest);
            }

        }

        /// <summary>
        /// Actualiza información de la persona
        /// </summary>
        /// <param name="id"></param>
        /// <param name="person"></param>
        /// <exception cref="CustomException"></exception>
        public async Task UpdatePersonById(int id, PersonDTO person)
        {
            Persons queryPerson = await FindPersonById(id);
            if (queryPerson is null)
            {
                throw new CustomException(Constants.MSJ_PER01, HttpStatusCode.NotFound);
            }

            queryPerson = mapper.Map(person, queryPerson);
            queryPerson.Id = id;
            await context.SaveChangesAsync();
        }


        /// <summary>
        /// Busca la persona por id, en caso de no encontrar información regresa un mensaje de error
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Persons</returns>
        /// <exception cref="CustomException"></exception>
        private async Task<Persons> FindPersonById(int id)
        {
            Persons queryPerson = await context.Persons.Where(p => p.IsActive).FirstOrDefaultAsync(p => p.Id == id);
            if (queryPerson == null)
            {
                throw new CustomException(Constants.MSJ_PER01, HttpStatusCode.NotFound);
            }
            return queryPerson;
        }
    }
}
