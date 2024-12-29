using System.Net;


/*
 * @author Aaron Pérez
 * @since 27/12/2024
 */
namespace bl_poc_ms_person.Exceptions
{
    public class CustomException: Exception
    {
        public HttpStatusCode HttpStatusCode { get; }
        public CustomException(string message, HttpStatusCode httpStatusCode): base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
