/*
 * @author Aaron Pérez
 * @since 07/10/2024
 */

namespace bl_poc_ms_person.DTOs
{
    public class BaseDTO<T>
    {
        public bool IsCorrect { get; set; } = true;
        public string Message { get; set; }
        public T Response { get; set; } = default;

        public BaseDTO(bool EsCorrecto, string mensaje, T respuesta = default)
        {
            this.IsCorrect = EsCorrecto;
            Message = mensaje;
            Response = respuesta;
        }

    }
}
