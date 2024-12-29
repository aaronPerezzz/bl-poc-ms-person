using bl_poc_ms_person.DTOs;
using bl_poc_ms_person.Exceptions;
using bl_poc_ms_person.Interface;
using bl_poc_ms_person.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net;


/**
 * @author Aaron Pérez
 * @since 27/12/2024
 */
namespace bl_poc_ms_person.Controllers
{
    [Route("api/persons")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPerson personService;

        public PersonController(IPerson personService)
        {
            this.personService = personService;
        }

        /// <summary>
        /// Obtiene todas las persona activas
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>Lista de personas</returns>
        /// <response code="200">Petición exitosa</response>
        /// <response code="404">No existe información que mostrar</response>
        /// <response code="500">Error en el servidor</response>
        [HttpGet]
        
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<PersonDTO>>> GetAllPersons([FromQuery] PaginationDTO pagination)
        {
            BaseDTO<List<PersonDTO>> response;
            List<PersonDTO> personList;

            try
            {
                personList = await personService.GetPersons(pagination);
                return Ok(response = new(Constants.TRUE, Constants.MSJ_PER02, personList));
            }
            catch (CustomException ex)
            {
                return StatusCode((int)ex.HttpStatusCode, response = new(Constants.FALSE, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, response = new(Constants.FALSE, ex.Message));
            }
        }

        /// <summary>
        /// Crea nuevo registro de una persona
        /// </summary>
        /// <param name="person"></param>
        /// <returns>Creación de nueva persona</returns>
        /// <remarks>
        /// Sample request:
        /// POST api/persons
        /// {
        ///  "name": "Aaron",
        ///  "lastName": "Pérez",
        ///  "email": "aaron@example.com",
        ///  "phone": "2224597300",
        ///  "birthDay": "1993-03-11",
        ///  "maritalStatus": "Soltero"
        /// }
        /// </remarks>
        /// <param name="person"></param>
        /// <response code="201">Información guardada con éxito</response>
        /// <response code="409">Información repétida</response>
        /// <response code="500">Error en el servidor</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(201)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<BaseDTO<PersonDTO>>> SavePerson([FromBody] PersonDTO person)
        {
            BaseDTO<PersonDTO> response;
            PersonDTO personDTO;
            try
            {
                personDTO = await personService.SavePerson(person);
                return StatusCode((int)HttpStatusCode.Created, response = new(Constants.TRUE, Constants.MSJ_PER03, personDTO));
            }
            catch (CustomException ex)
            {
                return StatusCode((int)ex.HttpStatusCode, response = new(Constants.FALSE, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, response = new(Constants.FALSE, ex.Message));
            }
        }

        /// <summary>
        /// Busca una persona por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Información de una persona</returns>
        /// <response code="200">Petición exitosa</response>
        /// <response code="404">No existe información que mostrar</response>
        /// <response code="500">Error en el servidor</response>
        [HttpGet("{id:int}")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<BaseDTO<PersonDTO>>> GetById(int id)
        {
            BaseDTO<PersonDTO> response;
            PersonDTO personDTO;

            try
            {
                personDTO = await personService.GetPersonById(id);
                return Ok(response = new(Constants.TRUE, Constants.MSJ_PER02, personDTO));
            }
            catch (CustomException ex)
            {
                return StatusCode((int)ex.HttpStatusCode, response = new(Constants.FALSE, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, response = new(Constants.FALSE, ex.Message));
            }
        }

        /// <summary>
        /// Eliminación de una persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Elimina una persona</returns>
        /// <response code="204">Petición exitosa</response>
        /// <response code="404">No existe información que mostrar</response>
        /// <response code="500">Error en el servidor</response>
        [HttpDelete("{id:int}")]
        [Produces("application/json")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> DeleteById(int id)
        {
            try
            {
                await personService.DeletePersonById(id);
                return NoContent();

            }
            catch (CustomException ex)
            {
                return StatusCode((int)ex.HttpStatusCode, Constants.MSJ_PER05);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        /// <summary>
        /// Modifica información de una persona
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personDTO"></param>
        /// <remarks>
        /// Sample request:
        /// POST api/persons
        /// {
        ///  "name": "Aaron",
        ///  "lastName": "Pérez",
        ///  "email": "aaron@example.com",
        ///  "phone": "2224597300",
        ///  "birthDay": "1993-03-11",
        ///  "maritalStatus": "Soltero"
        /// }
        /// </remarks>
        /// <returns>Modificación de una persona</returns>
        /// <response code="204">Petición exitosa</response>
        /// <response code="404">No existe información que mostrar</response>
        /// <response code="500">Error en el servidor</response>
        [HttpPut("{id:int}")]
        [Produces("application/json")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> UpdatePersonById(int id, [FromBody] PersonDTO personDTO)
        {
            try
            {
                await personService.UpdatePersonById(id, personDTO);
                return NoContent();
            }
            catch (CustomException ex)
            {
                return StatusCode((int)ex.HttpStatusCode, Constants.MSJ_PER06);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
