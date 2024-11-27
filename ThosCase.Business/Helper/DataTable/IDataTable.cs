namespace ThosCase.Business.Helper.DataTable
{
    public interface IDataTable
    {
        DatatableResponse<T> GetForDataTable<T>(List<T> model, JqueryDatatableParam param);
    }
}
