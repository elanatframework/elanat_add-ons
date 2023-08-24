using CodeBehind;

namespace Elanat
{
    public partial class AdminSqlCommandController : CodeBehindController
    {
        public AdminSqlCommandModel model = new AdminSqlCommandModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_RunSqlQuery"]))
            {
                btn_RunSqlQuery_Click(context);
                return;
            }

            
            model.SetValue();

            View(model);
        }

        protected void btn_RunSqlQuery_Click(HttpContext context)
        {
            model.SqlQueryValue = context.Request.Form["txt_SqlQuery"].ToString().Replace(Environment.NewLine, " ");


            Write(model.RunSqlQuery());

            IgnoreViewAndModel = true;
        }
    }
}
