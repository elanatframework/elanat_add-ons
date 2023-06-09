using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionElanatSlideshowDeleteImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["image_name"]))
            {
                Response.Write("false");
                return;
            }
                                
            System.IO.File.Delete(Request.MapPath(StaticObject.SitePath + "client/elanat_slideshow/image/" + Request.QueryString["image_name"].ToString()));
            Response.Write("true");


            // Delete Image From Option
            XmlDocument ElanatSlideshowOptionDocument = new XmlDocument();
            ElanatSlideshowOptionDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_slideshow/option/elanat_slideshow_option.xml"));

            XmlNode ImageNode = ElanatSlideshowOptionDocument.SelectSingleNode("elanat_slideshow_option_root/image_list/image[@name='" + Request.QueryString["image_name"] + "']");

            if (ImageNode != null)
            {
                ElanatSlideshowOptionDocument.SelectSingleNode("elanat_slideshow_option_root/image_list").RemoveChild(ImageNode);

                ElanatSlideshowOptionDocument.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_slideshow/option/elanat_slideshow_option.xml"));
            }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_elanat_slideshow_image", Request.QueryString["image_name"].ToString());
        }
    }
}