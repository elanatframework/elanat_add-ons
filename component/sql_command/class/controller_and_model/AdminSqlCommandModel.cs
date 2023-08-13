using CodeBehind;

namespace Elanat
{
    public partial class AdminSqlCommandModel : CodeBehindModel
    {
        public string SqlCommandLanguage { get; set; }
        public string SetSqlCommandLanguage { get; set; }
        public string SqlQueryLanguage { get; set; }
        public string RunSqlQueryLanguage { get; set; }

        public string SqlQueryValue { get; set; }

        public string SqlQueryAttribute { get; set; }

        public string SqlQueryCssClass { get; set; }

        public List<string> EvaluateErrorList;
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/sql_command/");
            SqlCommandLanguage = aol.GetAddOnsLanguage("sql_command");
            SetSqlCommandLanguage = aol.GetAddOnsLanguage("set_sql_command");
            SqlQueryLanguage = aol.GetAddOnsLanguage("sql_query");
            RunSqlQueryLanguage = aol.GetAddOnsLanguage("run_sql_query");
        }

        public void RunSqlQuery()
        {
            string SqlQuery = SqlQueryValue;

            // Check Query Error
            DataBaseSocket db = new DataBaseSocket();
            db.GetCommand(SqlQuery);

            if (!string.IsNullOrEmpty(db.ErrorMessage))
            {
                string ErrorMessage = db.ErrorMessage;

                db.Close();

                ResponseForm.WriteLocalAlone(ErrorMessage, "problem");

                return;
            }

            SqlQuery = SqlQuery.Replace("&", "$_asp sql_query_amp;");

            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());
            rf.AddPageLoad(StaticObject.AdminPath + "/sql_command/action/GetSqlQueryTable.aspx?sql_query=" + SqlQuery, "div_SqlQueryTable");
            rf.RedirectToResponseFormPage();
        }
    }
}