using CodeBehind;

namespace Elanat
{
    public partial class ActionGetSqlQueryTableController : CodeBehindController
    {
        public ActionGetSqlQueryTableModel model = new ActionGetSqlQueryTableModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["sql_query"]))
            {
                IgnoreViewAndModel = true;
                return;
            }


            model.SqlQueryValue = context.Request.Query["sql_query"].ToString().Replace("$_asp sql_query_amp;", "&");

            model.SetValue();

            View(model);
        }
    }
}