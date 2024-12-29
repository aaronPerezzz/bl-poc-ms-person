using bl_poc_ms_person.DTOs;

namespace bl_poc_ms_person.Utils.Pagination
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, PaginationDTO pagination)
        {
            return queryable.Skip((pagination.Pagina -1) * pagination.CantidadRegistros).Take(pagination.CantidadRegistros);
        }
    }
}
