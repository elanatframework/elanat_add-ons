using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ModuleElanatGalleryModel : CodeBehindModel
    {
        public string GalleryItem = "";
        public string GalleryInnerScriptValue = "";
        public string GalleryInnerStyleValue = "";

        public void SetValue()
        {
            XmlDocument TemplateDocument = new XmlDocument();
            TemplateDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/elanat_gallery/template/template.xml"));
            string GalleryGalleryItemTemplate = TemplateDocument.SelectSingleNode("gallery_root/gallery/gallery_item").SetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage()).InnerText;
            string SumGalleryGalleryItemTemplate = "";


            XmlDocument OptionDocument = new XmlDocument();
            OptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/elanat_gallery/option/elanat_gallery_option.xml"));
            XmlNode OptionNode = OptionDocument.SelectSingleNode("elanat_gallery_option_root/option");
            XmlNodeList ImageNodeList = OptionDocument.SelectSingleNode("elanat_gallery_option_root/image_list").ChildNodes;

            bool GalleryUseInternalBox = OptionNode["gallery_use_internal_box"].Attributes["active"].Value.TrueFalseToBoolean();

            if (GalleryUseInternalBox)
            {
                GalleryInnerScriptValue = "<script>" + PageLoader.LoadWithText(StaticObject.SitePath + "client/elanat_gallery/script/elanat_gallery.js") + "</script>";
                GalleryInnerStyleValue = "<style>" + PageLoader.LoadWithText(StaticObject.SitePath + "client/elanat_gallery/style/elanat_gallery.css") + "</style>";
            }

            foreach (XmlNode node in ImageNodeList)
            {
                string TmpGalleryGalleryItemTemplate = GalleryGalleryItemTemplate;

                TmpGalleryGalleryItemTemplate = TmpGalleryGalleryItemTemplate.Replace("$_asp image_name;", node.Attributes["name"].Value);

                string ImageText = (string.IsNullOrEmpty(node.Attributes["text"].Value)) ? node.Attributes["name"].Value : node.Attributes["text"].Value;
                TmpGalleryGalleryItemTemplate = TmpGalleryGalleryItemTemplate.Replace("$_asp text;", ImageText);

                SumGalleryGalleryItemTemplate += TmpGalleryGalleryItemTemplate;
            }


            GalleryItem = SumGalleryGalleryItemTemplate;
        }
    }
}