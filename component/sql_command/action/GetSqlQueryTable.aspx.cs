using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionGetSqlQueryTable : System.Web.UI.Page
    {
        public ActionGetSqlQueryTableModel model = new ActionGetSqlQueryTableModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["sql_query"]))
                return;


            model.SqlQueryValue = Request.QueryString["sql_query"].ToString().Replace("$_asp sql_query_amp;", "&");

            model.SetValue();
        }
    }
}