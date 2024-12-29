namespace bl_poc_ms_person.Utils.Pagination
{
    public class HttpContextExtensions
    {

        public static Task PaginationResponse(HttpContext context, int totalRegistros, int cantidadRegistros)
        {
            if(context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            double count = totalRegistros;
            double totalPages = Math.Ceiling(count / cantidadRegistros);
            context.Response.Headers.Append("totalRegistros", count.ToString());
            context.Response.Headers.Append("totalPaginas", totalPages.ToString());
            return Task.FromResult(0);
        }
    }
}
