using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionElanatFaqAddFaq : System.Web.UI.Page
    {
        public ActionElanatFaqAddFaqModel model = new ActionElanatFaqAddFaqModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["index"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["index"].IsNumber())
            {
                Response.Write("false");
                return;
            }

            string Index = Request.QueryString["index"].ToString();

            model.SetValue(Index);
        }
    }
}