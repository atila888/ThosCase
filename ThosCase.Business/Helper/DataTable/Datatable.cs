using System.Data;

namespace ThosCase.Business.Helper.DataTable
{
    public class Datatable : IDataTable
    {
        public DatatableResponse<T> GetForDataTable<T>(List<T> model, JqueryDatatableParam param)
        {
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                model = model.AreAllPropertiesSearch(param.sSearch);
            }

            var displayResult = model.Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();
            var totalRecords = model.Count();

            return new DatatableResponse<T>
            {
                sEcho = param.sEcho,
                iTotalRecords = totalRecords,
                iTotalDisplayRecords = totalRecords,
                aaData = displayResult
            };
        }
    }

    internal static class Extensions
    {
        internal static List<T> AreAllPropertiesSearch<T>(this IEnumerable<T> items, string searchText)
        {
            var properties = typeof(T).GetProperties().Where(x => x.PropertyType == typeof(string));
            return items.Where(x => properties.All(p => ((string)p.GetValue(x)).Contains(searchText))).ToList();
        }
    }
}
