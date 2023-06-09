using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionElanatSlideshowUploadImage : System.Web.UI.Page
    {
        public ActionElanatSlideshowUploadImageModel model = new ActionElanatSlideshowUploadImageModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["image_name"]))
                return;

            model.ImageNameValue = Request.QueryString["image_name"].ToString();


            model.SetValue();
        }
    }
}