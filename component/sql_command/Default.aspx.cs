using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml;
using System.IO;

namespace elanat
{
    public partial class AdminSqlCommand : System.Web.UI.Page
    {
        public AdminSqlCommandModel model = new AdminSqlCommandModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_RunSqlQuery"]))
                btn_RunSqlQuery_Click(sender, e);

            
            model.SetValue();
        }

        protected void btn_RunSqlQuery_Click(object sender, EventArgs e)
        {
            model.SqlQueryValue = Request.Form["txt_SqlQuery"].Replace(Environment.NewLine, " ");


            model.RunSqlQuery();
        }
    }
}