using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionElanatGalleryUploadImageModel : CodeBehindModel
    {
        public string ImageNameValue { get; set; }

        public void SetValue()
        {
            // Set Image Template
            XmlDocument TemplateDocument = new XmlDocument();
            TemplateDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/elanat_gallery/template/template.xml"));
            string GalleryImageItemTemplate = TemplateDocument.SelectSingleNode("gallery_root/option/image_item").SetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage()).InnerText;

            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_gallery/");
            string LinkHrefLanguage = aol.GetAddOnsLanguage("link_href");
            string TextLanguage = aol.GetAddOnsLanguage("text");
            string DeleteLanguage = aol.GetAddOnsLanguage("delete");

            GalleryImageItemTemplate = GalleryImageItemTemplate.Replace("$_asp_lang link_href;", LinkHrefLanguage);
            GalleryImageItemTemplate = GalleryImageItemTemplate.Replace("$_asp_lang text;", TextLanguage);
            GalleryImageItemTemplate = GalleryImageItemTemplate.Replace("$_asp_lang delete;", DeleteLanguage);

            GalleryImageItemTemplate = GalleryImageItemTemplate.Replace("$_asp image_name;", ImageNameValue);
            GalleryImageItemTemplate = GalleryImageItemTemplate.Replace("$_asp image_text;", "");
            GalleryImageItemTemplate = GalleryImageItemTemplate.Replace("$_asp indexer;", "tmp");
            GalleryImageItemTemplate = GalleryImageItemTemplate.Replace("$_asp checked;", "unchecked");

            Write(GalleryImageItemTemplate);
        }
    }
}