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
    public class ModuleElanatSlideshowOptionModel
    {
        public string ElanatSlideshowLanguage { get; set; }
        public string ElanatSlideshowImagesLanguage { get; set; }
        public string SlideshowUseMaxWidthLanguage { get; set; }
        public string SlideshowUseInternalBoxLanguage { get; set; }
        public string IncludeTextLanguage { get; set; }
        public string UseTextBackgroundLanguage { get; set; }
        public string SlideshowWidthLanguage { get; set; }
        public string SlideshowHeightLanguage { get; set; }
        public string ChangeSlideDelayLanguage { get; set; }
        public string SlideImageObjectFitLanguage { get; set; }
        public string TextLocationLanguage { get; set; }
        public string ChangeSlideAnimationLanguage { get; set; }
        public string TextStyleLanguage { get; set; }
        public string ElanatSlideshowUploadImageLanguage { get; set; }
        public string UploadImageLanguage { get; set; }
        public string UseImagePathLanguage { get; set; }
        public string ImagePathLanguage { get; set; }
        public string StartUploadLanguage { get; set; }
        public string SaveElanatSlideshowOptionLanguage { get; set; }
        public string SaveElanatSlideshowImagesLanguage { get; set; }
        public string RefreshLanguage { get; set; }

        public bool SlideshowUseMaxWidthValue { get; set; } = false;
        public bool SlideshowUseInternalBoxValue { get; set; } = false;
        public bool IncludeTextValue { get; set; } = false;
        public bool UseTextBackgroundValue { get; set; } = false;

        public string SlideshowWidthValue { get; set; }
        public string SlideshowHeightValue { get; set; }
        public string ChangeSlideDelayValue { get; set; }
        public string TextStyleValue { get; set; }

        public string SlideshowImageItemValue { get; set; }

        public string SlideImageObjectFitOptionListValue { get; set; }
        public string SlideImageObjectFitOptionListSelectedValue { get; set; }
        public string TextLocationOptionListValue { get; set; }
        public string TextLocationOptionListSelectedValue { get; set; }
        public string ChangeSlideAnimationOptionListValue { get; set; }
        public string ChangeSlideAnimationOptionListSelectedValue { get; set; }

        public string SlideshowWidthAttribute { get; set; }
        public string SlideshowHeightAttribute { get; set; }
        public string ChangeSlideDelayAttribute { get; set; }
        public string SlideImageObjectFitAttribute { get; set; }
        public string TextLocationAttribute { get; set; }
        public string ChangeSlideAnimationAttribute { get; set; }
        public string TextStyleAttribute { get; set; }

        public string SlideshowWidthCssClass { get; set; }
        public string SlideshowHeightCssClass { get; set; }
        public string ChangeSlideDelayCssClass { get; set; }
        public string SlideImageObjectFitCssClass { get; set; }
        public string TextLocationCssClass { get; set; }
        public string ChangeSlideAnimationCssClass { get; set; }
        public string TextStyleCssClass { get; set; }

        public bool UseImagePathValue { get; set; } = false;
        public HttpPostedFile ImagePathUploadValue { get; set; }
        public string ImagePathTextValue { get; set; }

        public List<string> SlideshowImageNameValue = new List<string>();
        public List<string> SlideshowImageTextValue = new List<string>();
        public List<string> SlideshowImageLinkValue = new List<string>();

        public List<string> EvaluateErrorList;
        public bool FindEvaluateError = false;


        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_slideshow/");
            ElanatSlideshowLanguage = aol.GetAddOnsLanguage("elanat_slideshow");
            ElanatSlideshowImagesLanguage = aol.GetAddOnsLanguage("elanat_slideshow_images");
            SlideshowUseMaxWidthLanguage = aol.GetAddOnsLanguage("slideshow_use_max_width");
            SlideshowUseInternalBoxLanguage = aol.GetAddOnsLanguage("slideshow_use_internal_box");
            IncludeTextLanguage = aol.GetAddOnsLanguage("include_text");
            UseTextBackgroundLanguage = aol.GetAddOnsLanguage("use_text_background");
            SlideshowWidthLanguage = aol.GetAddOnsLanguage("slideshow_width");
            SlideshowHeightLanguage = aol.GetAddOnsLanguage("slideshow_height");
            ChangeSlideDelayLanguage = aol.GetAddOnsLanguage("change_slide_delay");
            SlideImageObjectFitLanguage = aol.GetAddOnsLanguage("slide_image_object_fit");
            TextLocationLanguage = aol.GetAddOnsLanguage("text_location");
            ChangeSlideAnimationLanguage = aol.GetAddOnsLanguage("change_slide_animation");
            TextStyleLanguage = aol.GetAddOnsLanguage("text_style");
            UseImagePathLanguage = aol.GetAddOnsLanguage("use_image_path");
            ImagePathLanguage = aol.GetAddOnsLanguage("image_path");
            ElanatSlideshowUploadImageLanguage = aol.GetAddOnsLanguage("elanat_slideshow_upload_image");
            UploadImageLanguage = aol.GetAddOnsLanguage("upload_image");
            StartUploadLanguage = aol.GetAddOnsLanguage("start_upload");
            SaveElanatSlideshowOptionLanguage = aol.GetAddOnsLanguage("save_elanat_slideshow_option");
            SaveElanatSlideshowImagesLanguage = aol.GetAddOnsLanguage("save_elanat_slideshow_images");
            RefreshLanguage = aol.GetAddOnsLanguage("refresh");


            // Set Current Value
            XmlDocument ElanatSlideshowOptionDocument = new XmlDocument();
            ElanatSlideshowOptionDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_slideshow/option/elanat_slideshow_option.xml"));

            XmlNode node = ElanatSlideshowOptionDocument.SelectSingleNode("elanat_slideshow_option_root/option");

            SlideshowUseMaxWidthValue = (node["slideshow_use_max_width"].Attributes["active"].Value == "true");
            SlideshowUseInternalBoxValue = (node["slideshow_use_internal_box"].Attributes["active"].Value == "true");
            IncludeTextValue = (node["include_text"].Attributes["active"].Value == "true");
            UseTextBackgroundValue = (node["use_text_background"].Attributes["active"].Value == "true");
            SlideshowWidthValue = node["slideshow_width"].Attributes["value"].Value;
            SlideshowHeightValue = node["slideshow_height"].Attributes["value"].Value;
            ChangeSlideDelayValue = node["change_slide_delay"].Attributes["value"].Value;
            TextStyleValue = node["text_style"].Attributes["value"].Value;

            SlideImageObjectFitOptionListSelectedValue = node["slide_image_object_fit"].Attributes["value"].Value;
            TextLocationOptionListSelectedValue = node["text_location"].Attributes["value"].Value;
            ChangeSlideAnimationOptionListSelectedValue = node["change_slide_animation"].Attributes["value"].Value;


            // Set Slide Image Object Fit
            ListItem[] SlideImageObjectFitListItem = new ListItem[4];
            SlideImageObjectFitListItem[0] = new ListItem(aol.GetAddOnsLanguage("contain"), "contain");
            SlideImageObjectFitListItem[1] = new ListItem(aol.GetAddOnsLanguage("cover"), "cover");
            SlideImageObjectFitListItem[2] = new ListItem(aol.GetAddOnsLanguage("fill"), "fill");
            SlideImageObjectFitListItem[3] = new ListItem(aol.GetAddOnsLanguage("unset"), "unset");
            SlideImageObjectFitOptionListValue += SlideImageObjectFitListItem.HtmlInputToOptionTag(SlideImageObjectFitOptionListSelectedValue);

            // Set Text Location
            ListItem[] TextLocationListItem = new ListItem[4];
            TextLocationListItem[0] = new ListItem(aol.GetAddOnsLanguage("right"), "right");
            TextLocationListItem[1] = new ListItem(aol.GetAddOnsLanguage("left"), "left");
            TextLocationListItem[2] = new ListItem(aol.GetAddOnsLanguage("center"), "center");
            TextLocationListItem[3] = new ListItem(aol.GetAddOnsLanguage("unset"), "unset");
            TextLocationOptionListValue += TextLocationListItem.HtmlInputToOptionTag(TextLocationOptionListSelectedValue);

            // Set Change Slide Animation
            ListItem[] ChangeSlideAnimationListItem;
            List<string> ChangeSlideAnimationList = GetChangeSlideAnimationList();

            List<ListItem> ListListItem = new List<ListItem>();

            foreach (string SlideAnimation in ChangeSlideAnimationList)
                ListListItem.Add(new ListItem(aol.GetAddOnsLanguage(SlideAnimation), SlideAnimation));

            ChangeSlideAnimationListItem = ListListItem.ToArray();
            ChangeSlideAnimationOptionListValue += ChangeSlideAnimationListItem.HtmlInputToOptionTag(ChangeSlideAnimationOptionListSelectedValue);


            SetImageList();
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_SlideshowWidth", "");
            InputRequest.Add("txt_SlideshowHeight", "");
            InputRequest.Add("txt_ChangeSlideDelay", "");
            InputRequest.Add("ddlst_SlideImageObjectFit", SlideImageObjectFitOptionListValue);
            InputRequest.Add("ddlst_TextLocation", TextLocationOptionListValue);
            InputRequest.Add("ddlst_ChangeSlideAnimation", ChangeSlideAnimationOptionListValue);
            InputRequest.Add("txt_TextStyle", "");


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "add_on/module/elanat_slideshow/");

            SlideshowWidthAttribute += vc.ImportantInputAttribute["txt_SlideshowWidth"];
            SlideshowHeightAttribute += vc.ImportantInputAttribute["txt_SlideshowHeight"];
            ChangeSlideDelayAttribute += vc.ImportantInputAttribute["txt_ChangeSlideDelay"];
            SlideImageObjectFitAttribute += vc.ImportantInputAttribute["ddlst_SlideImageObjectFit"];
            TextLocationAttribute += vc.ImportantInputAttribute["ddlst_TextLocation"];
            ChangeSlideAnimationAttribute += vc.ImportantInputAttribute["ddlst_ChangeSlideAnimation"];
            TextStyleAttribute += vc.ImportantInputAttribute["txt_TextStyle"];

            SlideshowWidthCssClass = SlideshowWidthCssClass.AddHtmlClass(vc.ImportantInputClass["txt_SlideshowWidth"]);
            SlideshowHeightCssClass = SlideshowHeightCssClass.AddHtmlClass(vc.ImportantInputClass["txt_SlideshowHeight"]);
            ChangeSlideDelayCssClass = ChangeSlideDelayCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ChangeSlideDelay"]);
            SlideImageObjectFitCssClass = SlideImageObjectFitCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_SlideImageObjectFit"]);
            TextLocationCssClass = TextLocationCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_TextLocation"]);
            ChangeSlideAnimationCssClass = ChangeSlideAnimationCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_ChangeSlideAnimation"]);
            TextStyleCssClass = TextStyleCssClass.AddHtmlClass(vc.ImportantInputClass["txt_TextStyle"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.SitePath + "add_on/module/elanat_slideshow/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //SlideshowWidthCssClass = SlideshowWidthCssClass.AddHtmlClass(vc.WarningFieldClass["txt_SlideshowWidth"]);
                //SlideshowHeightCssClass = SlideshowHeightCssClass.AddHtmlClass(vc.WarningFieldClass["txt_SlideshowHeight"]);
                //ChangeSlideDelayCssClass = ChangeSlideDelayCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ChangeSlideDelay"]);
                //SlideImageObjectFitCssClass = SlideImageObjectFitCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_SlideImageObjectFit"]);
                //TextLocationCssClass = TextLocationCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_TextLocation"]);
                //ChangeSlideAnimationCssClass = ChangeSlideAnimationCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_ChangeSlideAnimation"]);
                //TextStyleCssClass = TextStyleCssClass.AddHtmlClass(vc.WarningFieldClass["txt_TextStyle"]);
            }
        }

        public void SaveElanatSlideshowOption()
        {
            XmlDocument ElanatSlideshowOptionDocument = new XmlDocument();
            ElanatSlideshowOptionDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_slideshow/option/elanat_slideshow_option.xml"));

            bool SlideshowUseInternalBoxValueChanged = (ElanatSlideshowOptionDocument.SelectSingleNode("elanat_slideshow_option_root/option/slideshow_use_max_width").Attributes["active"].Value.TrueFalseToBoolean() != SlideshowUseInternalBoxValue);

            ElanatSlideshowOptionDocument.SelectSingleNode("elanat_slideshow_option_root/option/slideshow_use_max_width").Attributes["active"].Value = SlideshowUseMaxWidthValue.BooleanToTrueFalse();
            ElanatSlideshowOptionDocument.SelectSingleNode("elanat_slideshow_option_root/option/slideshow_use_internal_box").Attributes["active"].Value = SlideshowUseInternalBoxValue.BooleanToTrueFalse();
            ElanatSlideshowOptionDocument.SelectSingleNode("elanat_slideshow_option_root/option/include_text").Attributes["active"].Value = IncludeTextValue.BooleanToTrueFalse();
            ElanatSlideshowOptionDocument.SelectSingleNode("elanat_slideshow_option_root/option/use_text_background").Attributes["active"].Value = UseTextBackgroundValue.BooleanToTrueFalse();

            ElanatSlideshowOptionDocument.SelectSingleNode("elanat_slideshow_option_root/option/slideshow_width").Attributes["value"].Value = SlideshowWidthValue;
            ElanatSlideshowOptionDocument.SelectSingleNode("elanat_slideshow_option_root/option/slideshow_height").Attributes["value"].Value = SlideshowHeightValue;
            ElanatSlideshowOptionDocument.SelectSingleNode("elanat_slideshow_option_root/option/change_slide_delay").Attributes["value"].Value = ChangeSlideDelayValue;
            ElanatSlideshowOptionDocument.SelectSingleNode("elanat_slideshow_option_root/option/slide_image_object_fit").Attributes["value"].Value = SlideImageObjectFitOptionListSelectedValue;
            ElanatSlideshowOptionDocument.SelectSingleNode("elanat_slideshow_option_root/option/text_location").Attributes["value"].Value = TextLocationOptionListSelectedValue;
            ElanatSlideshowOptionDocument.SelectSingleNode("elanat_slideshow_option_root/option/change_slide_animation").Attributes["value"].Value = ChangeSlideAnimationOptionListSelectedValue;
            ElanatSlideshowOptionDocument.SelectSingleNode("elanat_slideshow_option_root/option/text_style").Attributes["value"].Value = TextStyleValue;

            ElanatSlideshowOptionDocument.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_slideshow/option/elanat_slideshow_option.xml"));


            // Set Static Head Internal Or External Box
            if (SlideshowUseInternalBoxValueChanged)
            {
                XmlDocument CatalogDocument = new XmlDocument();
                CatalogDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_slideshow/catalog.xml"));

                if (SlideshowUseInternalBoxValue)
                    CatalogDocument.SelectSingleNode("module_catalog_root/module_static_head").InnerXml = "";
                else
                {
                    XmlDocument TemplateDocument = new XmlDocument();
                    TemplateDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_slideshow/template/template.xml"));
                    string SlideshowStaticHeadExternalBoxTemplateXml = TemplateDocument.SelectSingleNode("slideshow_root/option/static_head_external_box").SetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage()).InnerXml;

                    CatalogDocument.SelectSingleNode("module_catalog_root/module_static_head").InnerXml = SlideshowStaticHeadExternalBoxTemplateXml;
                }

                CatalogDocument.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_slideshow/catalog.xml"));
            }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_elanat_slideshow_option", null);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("elanat_slideshow_option_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_slideshow/"), "success");
        }

        public List<string> GetChangeSlideAnimationList()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_slideshow/template/template.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("slideshow_root/slideshow/slide_animation_list").ChildNodes;
            List<string> list = new List<string>();
            foreach (XmlNode node in NodeList)
                list.Add(node.Name);

            return list;
        }

        public void SetImageList()
        {
            XmlDocument TemplateDocument = new XmlDocument();
            TemplateDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_slideshow/template/template.xml"));
            string SlideshowImageItemTemplate = TemplateDocument.SelectSingleNode("slideshow_root/option/image_item").SetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage()).InnerText;
            string SumSlideshowImageItemTemplate = "";

            XmlDocument OptionDocument = new XmlDocument();
            OptionDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_slideshow/option/elanat_slideshow_option.xml"));
            XmlNodeList ImageNodeList = OptionDocument.SelectSingleNode("elanat_slideshow_option_root/image_list").ChildNodes;

            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_slideshow/");
            string LinkHrefLanguage = aol.GetAddOnsLanguage("link_href");
            string TextLanguage = aol.GetAddOnsLanguage("text");
            string DeleteLanguage = aol.GetAddOnsLanguage("delete");

            SlideshowImageItemTemplate = SlideshowImageItemTemplate.Replace("$_asp_lang link_href;", LinkHrefLanguage);
            SlideshowImageItemTemplate = SlideshowImageItemTemplate.Replace("$_asp_lang text;", TextLanguage);
            SlideshowImageItemTemplate = SlideshowImageItemTemplate.Replace("$_asp_lang delete;", DeleteLanguage);

            int ImageNumber = 0;

            foreach (XmlNode node in ImageNodeList)
            {
                string TmpSlideshowImageItemTemplate = SlideshowImageItemTemplate;

                TmpSlideshowImageItemTemplate = TmpSlideshowImageItemTemplate.Replace("$_asp image_name;", node.Attributes["name"].Value);
                TmpSlideshowImageItemTemplate = TmpSlideshowImageItemTemplate.Replace("$_asp image_link;", node.Attributes["link"].Value);
                TmpSlideshowImageItemTemplate = TmpSlideshowImageItemTemplate.Replace("$_asp image_text;", node.Attributes["text"].Value);
                TmpSlideshowImageItemTemplate = TmpSlideshowImageItemTemplate.Replace("$_asp indexer;", (ImageNumber++).ToString());
                TmpSlideshowImageItemTemplate = TmpSlideshowImageItemTemplate.Replace("$_asp checked;", "checked");


                SumSlideshowImageItemTemplate += TmpSlideshowImageItemTemplate;
            }


            DirectoryInfo dirInfo = new DirectoryInfo(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "client/elanat_slideshow/image"));
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


                string TmpSlideshowImageItemTemplate = SlideshowImageItemTemplate;

                TmpSlideshowImageItemTemplate = TmpSlideshowImageItemTemplate.Replace("$_asp image_name;", file.Name);
                TmpSlideshowImageItemTemplate = TmpSlideshowImageItemTemplate.Replace("$_asp image_link;", "");
                TmpSlideshowImageItemTemplate = TmpSlideshowImageItemTemplate.Replace("$_asp image_text;", "");
                TmpSlideshowImageItemTemplate = TmpSlideshowImageItemTemplate.Replace("$_asp indexer;", (ImageNumber++).ToString());
                TmpSlideshowImageItemTemplate = TmpSlideshowImageItemTemplate.Replace("$_asp checked;", ((ImageUsed) ? "checked" : "unchecked"));

                SumSlideshowImageItemTemplate += TmpSlideshowImageItemTemplate;
            }

            SlideshowImageItemValue = SumSlideshowImageItemTemplate;
        }

        public void StartUpload()
        {
            string Path = HttpContext.Current.Server.MapPath(StaticObject.SitePath + "client/elanat_slideshow/image");
            string ImagePhysicalName = "";

            // If Use Image Path
            if (UseImagePathValue)
            {
                if (string.IsNullOrEmpty(ImagePathTextValue))
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_image_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_slideshow/"), "problem");

                System.Net.WebClient webClient = new System.Net.WebClient();

                ImagePhysicalName = System.IO.Path.GetFileName(ImagePathTextValue);
                ImagePhysicalName = FileAndDirectory.GetNewFileNameIfFileNameExist(Path, ImagePhysicalName);


                string ImageExtension = System.IO.Path.GetExtension(ImagePhysicalName);

                if (!FileAndDirectory.IsImageExtension(ImageExtension))
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_select_a_image_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_slideshow/"), "problem");

                webClient.DownloadFile(ImagePathTextValue, Path + "/" + ImagePhysicalName.ToFileNameEncode());
            }
            else
            {
                if (!ImagePathUploadValue.HtmlInputHasFile())
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_image_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_slideshow/"), "problem");

                ImagePhysicalName = System.IO.Path.GetFileName(ImagePathUploadValue.FileName);
                ImagePhysicalName = FileAndDirectory.GetNewFileNameIfFileNameExist(Path, ImagePhysicalName);


                string ImageExtension = System.IO.Path.GetExtension(ImagePhysicalName);

                if (!FileAndDirectory.IsImageExtension(ImageExtension))
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_select_a_image_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_slideshow/"), "problem");

                ImagePathUploadValue.SaveAs(Path + "/" + ImagePhysicalName.ToFileNameEncode());
            }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("upload_image", Path + "/" + ImagePhysicalName);


            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());
            rf.AddLocalMessage(Language.GetAddOnsLanguage("image_was_upload", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_slideshow/"), "success");
            rf.AddPageLoad(StaticObject.SitePath + "add_on/module/elanat_slideshow/option/action/ElanatSlideshowUploadImage.aspx?image_name=" + ImagePhysicalName, "div_ImageBoxList");
            rf.AddReturnFunction("el_SetLastIndex()");
            rf.RedirectToResponseFormPage();
        }

        public void SaveElanatSlideshowImages()
        {
            XmlDocument ElanatSlideshowOptionDocument = new XmlDocument();
            ElanatSlideshowOptionDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_slideshow/option/elanat_slideshow_option.xml"));

            ElanatSlideshowOptionDocument.SelectSingleNode("elanat_slideshow_option_root/image_list").InnerXml = null;

            for (int i = SlideshowImageNameValue.Count - 1; i >= 0; i--)
            {
                XmlElement ImageElement = ElanatSlideshowOptionDocument.CreateElement("image");
                ImageElement.SetAttribute("name", SlideshowImageNameValue[i]);
                ImageElement.SetAttribute("link", SlideshowImageLinkValue[i]);
                ImageElement.SetAttribute("text", SlideshowImageTextValue[i]);

                ElanatSlideshowOptionDocument.SelectSingleNode("elanat_slideshow_option_root/image_list").AppendChild(ImageElement);
            }

            ElanatSlideshowOptionDocument.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_slideshow/option/elanat_slideshow_option.xml"));


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_elanat_slideshow_image_list", null);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("elanat_slideshow_images_list_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_slideshow/"), "success");
        }
    }
}