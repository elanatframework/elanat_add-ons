using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionElanatGalleryUploadImage : System.Web.UI.Page
    {
        public ActionElanatGalleryUploadImageModel model = new ActionElanatGalleryUploadImageModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["image_name"]))
                return;

            model.ImageNameValue = Request.QueryString["image_name"].ToString();


            model.SetValue();
        }
    }
}