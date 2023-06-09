using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionElanatGalleryDeleteImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["image_name"]))
            {
                Response.Write("false");
                return;
            }
                                
            System.IO.File.Delete(Request.MapPath(StaticObject.SitePath + "client/elanat_gallery/image/" + Request.QueryString["image_name"].ToString()));
            System.IO.File.Delete(Request.MapPath(StaticObject.SitePath + "client/elanat_gallery/image/thumb/" + Request.QueryString["image_name"].ToString()));
            Response.Write("true");


            // Delete Image From Option
            XmlDocument ElanatGalleryOptionDocument = new XmlDocument();
            ElanatGalleryOptionDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_gallery/option/elanat_gallery_option.xml"));

            XmlNode ImageNode = ElanatGalleryOptionDocument.SelectSingleNode("elanat_gallery_option_root/image_list/image[@name='" + Request.QueryString["image_name"] + "']");

            if (ImageNode != null)
            {
                ElanatGalleryOptionDocument.SelectSingleNode("elanat_gallery_option_root/image_list").RemoveChild(ImageNode);

                ElanatGalleryOptionDocument.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_gallery/option/elanat_gallery_option.xml"));
            }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_elanat_gallery_image", Request.QueryString["image_name"].ToString());
        }
    }
}