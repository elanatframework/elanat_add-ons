using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionElanatGalleryDeleteImageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["image_name"]))
            {
                Write("false");
                return;
            }
                                
            File.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "client/elanat_gallery/image/" + context.Request.Query["image_name"].ToString()));
            File.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "client/elanat_gallery/image/thumb/" + context.Request.Query["image_name"].ToString()));
            
            Write("true");


            // Delete Image From Option
            XmlDocument ElanatGalleryOptionDocument = new XmlDocument();
            ElanatGalleryOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/elanat_gallery/option/elanat_gallery_option.xml"));

            XmlNode ImageNode = ElanatGalleryOptionDocument.SelectSingleNode("elanat_gallery_option_root/image_list/image[@name='" + context.Request.Query["image_name"] + "']");

            if (ImageNode != null)
            {
                ElanatGalleryOptionDocument.SelectSingleNode("elanat_gallery_option_root/image_list").RemoveChild(ImageNode);

                ElanatGalleryOptionDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/elanat_gallery/option/elanat_gallery_option.xml"));
            }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_elanat_gallery_image", context.Request.Query["image_name"].ToString());
        }
    }
}