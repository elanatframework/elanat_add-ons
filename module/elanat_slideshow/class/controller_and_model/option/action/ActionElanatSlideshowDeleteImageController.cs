using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionElanatSlideshowDeleteImageController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["image_name"]))
            {
                Write("false");

                return;
            }
                                
            File.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "client/elanat_slideshow/image/" + context.Request.Query["image_name"].ToString()));
            
            Write("true");


            // Delete Image From Option
            XmlDocument ElanatSlideshowOptionDocument = new XmlDocument();
            ElanatSlideshowOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/elanat_slideshow/option/elanat_slideshow_option.xml"));

            XmlNode ImageNode = ElanatSlideshowOptionDocument.SelectSingleNode("elanat_slideshow_option_root/image_list/image[@name='" + context.Request.Query["image_name"].ToString() + "']");

            if (ImageNode != null)
            {
                ElanatSlideshowOptionDocument.SelectSingleNode("elanat_slideshow_option_root/image_list").RemoveChild(ImageNode);

                ElanatSlideshowOptionDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/elanat_slideshow/option/elanat_slideshow_option.xml"));
            }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("delete_elanat_slideshow_image", context.Request.Query["image_name"].ToString());
        }
    }
}