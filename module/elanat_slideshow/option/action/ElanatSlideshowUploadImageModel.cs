using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class ActionElanatSlideshowUploadImageModel
    {
        public string ImageNameValue { get; set; }

        public void SetValue()
        {
            // Set Image Template
            XmlDocument TemplateDocument = new XmlDocument();
            TemplateDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_slideshow/template/template.xml"));
            string SlideshowImageItemTemplate = TemplateDocument.SelectSingleNode("slideshow_root/option/image_item").SetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage()).InnerText;

            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_slideshow/");
            string LinkHrefLanguage = aol.GetAddOnsLanguage("link_href");
            string TextLanguage = aol.GetAddOnsLanguage("text");
            string DeleteLanguage = aol.GetAddOnsLanguage("delete");

            SlideshowImageItemTemplate = SlideshowImageItemTemplate.Replace("$_asp_lang link_href;", LinkHrefLanguage);
            SlideshowImageItemTemplate = SlideshowImageItemTemplate.Replace("$_asp_lang text;", TextLanguage);
            SlideshowImageItemTemplate = SlideshowImageItemTemplate.Replace("$_asp_lang delete;", DeleteLanguage);

            SlideshowImageItemTemplate = SlideshowImageItemTemplate.Replace("$_asp image_name;", ImageNameValue);
            SlideshowImageItemTemplate = SlideshowImageItemTemplate.Replace("$_asp image_link;", "");
            SlideshowImageItemTemplate = SlideshowImageItemTemplate.Replace("$_asp image_text;", "");
            SlideshowImageItemTemplate = SlideshowImageItemTemplate.Replace("$_asp indexer;", "tmp");
            SlideshowImageItemTemplate = SlideshowImageItemTemplate.Replace("$_asp checked;", "unchecked");

            HttpContext.Current.Response.Write(SlideshowImageItemTemplate);
        }
    }
}