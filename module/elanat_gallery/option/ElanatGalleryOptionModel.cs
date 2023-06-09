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
    public class ModuleElanatGalleryOptionModel
    {
        public string ElanatGalleryLanguage { get; set; }
        public string ElanatGalleryImagesLanguage { get; set; }
        public string GalleryUseInternalBoxLanguage { get; set; }
        public string ElanatGalleryUploadImageLanguage { get; set; }
        public string UploadImageLanguage { get; set; }
        public string UseImagePathLanguage { get; set; }
        public string ImagePathLanguage { get; set; }
        public string StartUploadLanguage { get; set; }
        public string SaveElanatGalleryOptionLanguage { get; set; }
        public string SaveElanatGalleryImagesLanguage { get; set; }
        public string RefreshLanguage { get; set; }

        public bool GalleryUseInternalBoxValue { get; set; } = false;

        public string GalleryImageItemValue { get; set; }

        public bool UseImagePathValue { get; set; } = false;
        public HttpPostedFile ImagePathUploadValue { get; set; }
        public string ImagePathTextValue { get; set; }

        public List<string> GalleryImageNameValue = new List<string>();
        public List<string> GalleryImageTextValue = new List<string>();

        public bool FindEvaluateError = false;


        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_gallery/");
            ElanatGalleryLanguage = aol.GetAddOnsLanguage("elanat_gallery");
            ElanatGalleryImagesLanguage = aol.GetAddOnsLanguage("elanat_gallery_images");
            GalleryUseInternalBoxLanguage = aol.GetAddOnsLanguage("gallery_use_internal_box");
            UseImagePathLanguage = aol.GetAddOnsLanguage("use_image_path");
            ImagePathLanguage = aol.GetAddOnsLanguage("image_path");
            ElanatGalleryUploadImageLanguage = aol.GetAddOnsLanguage("elanat_gallery_upload_image");
            UploadImageLanguage = aol.GetAddOnsLanguage("upload_image");
            StartUploadLanguage = aol.GetAddOnsLanguage("start_upload");
            SaveElanatGalleryOptionLanguage = aol.GetAddOnsLanguage("save_elanat_gallery_option");
            SaveElanatGalleryImagesLanguage = aol.GetAddOnsLanguage("save_elanat_gallery_images");
            RefreshLanguage = aol.GetAddOnsLanguage("refresh");


            // Set Current Value
            XmlDocument ElanatGalleryOptionDocument = new XmlDocument();
            ElanatGalleryOptionDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_gallery/option/elanat_gallery_option.xml"));

            XmlNode node = ElanatGalleryOptionDocument.SelectSingleNode("elanat_gallery_option_root/option");

            GalleryUseInternalBoxValue = (node["gallery_use_internal_box"].Attributes["active"].Value == "true");

            SetImageList();
        }

        public void SaveElanatGalleryOption()
        {
            XmlDocument ElanatGalleryOptionDocument = new XmlDocument();
            ElanatGalleryOptionDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_gallery/option/elanat_gallery_option.xml"));

            ElanatGalleryOptionDocument.SelectSingleNode("elanat_gallery_option_root/option/gallery_use_internal_box").Attributes["active"].Value = GalleryUseInternalBoxValue.BooleanToTrueFalse();

            ElanatGalleryOptionDocument.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_gallery/option/elanat_gallery_option.xml"));


            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_gallery/catalog.xml"));

            if (GalleryUseInternalBoxValue)
                CatalogDocument.SelectSingleNode("module_catalog_root/module_static_head").InnerXml = "";
            else
            {
                XmlDocument TemplateDocument = new XmlDocument();
                TemplateDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_gallery/template/template.xml"));
                string GalleryStaticHeadExternalBoxTemplateXml = TemplateDocument.SelectSingleNode("gallery_root/option/static_head_external_box").SetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage()).InnerXml;

                CatalogDocument.SelectSingleNode("module_catalog_root/module_static_head").InnerXml = GalleryStaticHeadExternalBoxTemplateXml;
            }

            CatalogDocument.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_gallery/catalog.xml"));


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_elanat_gallery_option", null);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("elanat_gallery_option_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_gallery/"), "success");
        }

        public void SetImageList()
        {
            XmlDocument TemplateDocument = new XmlDocument();
            TemplateDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_gallery/template/template.xml"));
            string GalleryImageItemTemplate = TemplateDocument.SelectSingleNode("gallery_root/option/image_item").SetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage()).InnerText;
            string SumGalleryImageItemTemplate = "";

            XmlDocument OptionDocument = new XmlDocument();
            OptionDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_gallery/option/elanat_gallery_option.xml"));
            XmlNodeList ImageNodeList = OptionDocument.SelectSingleNode("elanat_gallery_option_root/image_list").ChildNodes;

            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_gallery/");
            string LinkHrefLanguage = aol.GetAddOnsLanguage("link_href");
            string TextLanguage = aol.GetAddOnsLanguage("text");
            string DeleteLanguage = aol.GetAddOnsLanguage("delete");

            GalleryImageItemTemplate = GalleryImageItemTemplate.Replace("$_asp_lang link_href;", LinkHrefLanguage);
            GalleryImageItemTemplate = GalleryImageItemTemplate.Replace("$_asp_lang text;", TextLanguage);
            GalleryImageItemTemplate = GalleryImageItemTemplate.Replace("$_asp_lang delete;", DeleteLanguage);

            int ImageNumber = 0;

            foreach (XmlNode node in ImageNodeList)
            {
                string TmpGalleryImageItemTemplate = GalleryImageItemTemplate;

                TmpGalleryImageItemTemplate = TmpGalleryImageItemTemplate.Replace("$_asp image_name;", node.Attributes["name"].Value);
                TmpGalleryImageItemTemplate = TmpGalleryImageItemTemplate.Replace("$_asp image_text;", node.Attributes["text"].Value);
                TmpGalleryImageItemTemplate = TmpGalleryImageItemTemplate.Replace("$_asp indexer;", (ImageNumber++).ToString());
                TmpGalleryImageItemTemplate = TmpGalleryImageItemTemplate.Replace("$_asp checked;", "checked");


                SumGalleryImageItemTemplate += TmpGalleryImageItemTemplate;
            }


            DirectoryInfo dirInfo = new DirectoryInfo(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "client/elanat_gallery/image"));
            FileInfo[] fileInfo = dirInfo.GetFiles("*.*");

            foreach (FileInfo file in fileInfo)
            {
                bool ImageUsed = false;

                foreach (XmlNode node in ImageNodeList)
                    if (node.Attributes["name"].Value == file.Name)
                    {
                        ImageUsed = true;
                        break;
                    }

                if (ImageUsed)
                    continue;


                string TmpGalleryImageItemTemplate = GalleryImageItemTemplate;

                TmpGalleryImageItemTemplate = TmpGalleryImageItemTemplate.Replace("$_asp image_name;", file.Name);
                TmpGalleryImageItemTemplate = TmpGalleryImageItemTemplate.Replace("$_asp image_text;", "");
                TmpGalleryImageItemTemplate = TmpGalleryImageItemTemplate.Replace("$_asp indexer;", (ImageNumber++).ToString());
                TmpGalleryImageItemTemplate = TmpGalleryImageItemTemplate.Replace("$_asp checked;", ((ImageUsed) ? "checked" : "unchecked"));

                SumGalleryImageItemTemplate += TmpGalleryImageItemTemplate;
            }

            GalleryImageItemValue = SumGalleryImageItemTemplate;
        }

        public void StartUpload()
        {
            string Path = HttpContext.Current.Server.MapPath(StaticObject.SitePath + "client/elanat_gallery/image");
            string ImagePhysicalName = "";

            // If Use Image Path
            if (UseImagePathValue)
            {
                if (string.IsNullOrEmpty(ImagePathTextValue))
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_image_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_gallery/"), "problem");

                System.Net.WebClient webClient = new System.Net.WebClient();

                ImagePhysicalName = System.IO.Path.GetFileName(ImagePathTextValue);
                ImagePhysicalName = FileAndDirectory.GetNewFileNameIfFileNameExist(Path, ImagePhysicalName);


                string ImageExtension = System.IO.Path.GetExtension(ImagePhysicalName);

                if (!FileAndDirectory.IsImageExtension(ImageExtension))
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_select_a_image_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_gallery/"), "problem");

                webClient.DownloadFile(ImagePathTextValue, Path + "/" + ImagePhysicalName.ToFileNameEncode());
            }
            else
            {
                if (!ImagePathUploadValue.HtmlInputHasFile())
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_image_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_gallery/"), "problem");

                ImagePhysicalName = System.IO.Path.GetFileName(ImagePathUploadValue.FileName);
                ImagePhysicalName = FileAndDirectory.GetNewFileNameIfFileNameExist(Path, ImagePhysicalName);


                string ImageExtension = System.IO.Path.GetExtension(ImagePhysicalName);

                if (!FileAndDirectory.IsImageExtension(ImageExtension))
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_select_a_image_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_gallery/"), "problem");

                ImagePathUploadValue.SaveAs(Path + "/" + ImagePhysicalName.ToFileNameEncode());
            }


            // Create Thumbnail Image
            if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "client/elanat_gallery/image/thumb/")))
                System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "client/elanat_gallery/image/thumb/"));

            FileAndDirectory.CreateThumbnailImage(StaticObject.SitePath + "client/elanat_gallery/image/" + ImagePhysicalName, StaticObject.SitePath + "client/elanat_gallery/image/thumb/" + ImagePhysicalName);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("upload_image", Path + "/" + ImagePhysicalName);


            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());
            rf.AddLocalMessage(Language.GetAddOnsLanguage("image_was_upload", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_gallery/"), "success");
            rf.AddPageLoad(StaticObject.SitePath + "add_on/module/elanat_gallery/option/action/ElanatGalleryUploadImage.aspx?image_name=" + ImagePhysicalName, "div_ImageBoxList");
            rf.AddReturnFunction("el_SetLastIndex()");
            rf.RedirectToResponseFormPage();
        }

        public void SaveElanatGalleryImages()
        {
            XmlDocument ElanatGalleryOptionDocument = new XmlDocument();
            ElanatGalleryOptionDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_gallery/option/elanat_gallery_option.xml"));

            ElanatGalleryOptionDocument.SelectSingleNode("elanat_gallery_option_root/image_list").InnerXml = null;

            for (int i = GalleryImageNameValue.Count - 1; i >= 0; i--)
            {
                XmlElement ImageElement = ElanatGalleryOptionDocument.CreateElement("image");
                ImageElement.SetAttribute("name", GalleryImageNameValue[i]);
                ImageElement.SetAttribute("text", GalleryImageTextValue[i]);

                ElanatGalleryOptionDocument.SelectSingleNode("elanat_gallery_option_root/image_list").AppendChild(ImageElement);
            }

            ElanatGalleryOptionDocument.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_gallery/option/elanat_gallery_option.xml"));


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_elanat_gallery_image_list", null);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("elanat_gallery_images_list_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_gallery/"), "success");
        }
    }
}