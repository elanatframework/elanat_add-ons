using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ModuleElanatSlideshowModel
    {
        public string SlideshowWidth = "";
        public string SlideshowHeight = "";
        public string SlideItem = "";
        public string ChangeSlideCenterLocationValue = "";
        public string ChangeSlideUnderIconItem = "";
        public string ChangeSlideDelay = "";
        public string ChangeSlideAnimation = "";
        public string SlideshowAnimationTemplate = "";
        public string SlideshowInnerScriptValue = "";
        public string SlideshowInnerStyleValue = "";

        public void SetValue()
        {
            XmlDocument TemplateDocument = new XmlDocument();
            TemplateDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_slideshow/template/template.xml"));
            string SlideshowSlideItemTemplate = TemplateDocument.SelectSingleNode("slideshow_root/slideshow/slide_item").SetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage()).InnerText;
            string SumSlideshowSlideItemTemplate = "";
            string SlideshowChangeSlideUnderIconListItemTemplate = TemplateDocument.SelectSingleNode("slideshow_root/slideshow/change_slide_under_icon_list_item").SetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage()).InnerText;
            string SumSlideshowChangeSlideUnderIconListItemTemplate = "";
            string SlideshowLinkTemplate = TemplateDocument.SelectSingleNode("slideshow_root/slideshow/link").SetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage()).InnerText;


            XmlDocument OptionDocument = new XmlDocument();
            OptionDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_slideshow/option/elanat_slideshow_option.xml"));
            XmlNode OptionNode = OptionDocument.SelectSingleNode("elanat_slideshow_option_root/option");
            XmlNodeList ImageNodeList = OptionDocument.SelectSingleNode("elanat_slideshow_option_root/image_list").ChildNodes;


            bool SlideshowUseInternalBox = OptionNode["slideshow_use_internal_box"].Attributes["active"].Value.TrueFalseToBoolean();
            bool SlideshowUseMaxWidth = OptionNode["slideshow_use_max_width"].Attributes["active"].Value.TrueFalseToBoolean();
            bool IncludeText = OptionNode["include_text"].Attributes["active"].Value.TrueFalseToBoolean();
            bool UseTextBackground = OptionNode["use_text_background"].Attributes["active"].Value.TrueFalseToBoolean();
            SlideshowWidth = OptionNode["slideshow_width"].Attributes["value"].Value + "px";
            SlideshowHeight = OptionNode["slideshow_height"].Attributes["value"].Value + "px";
            ChangeSlideDelay = OptionNode["change_slide_delay"].Attributes["value"].Value;
            string SlideImageObjectFit = OptionNode["slide_image_object_fit"].Attributes["value"].Value;
            string TextLocation = OptionNode["text_location"].Attributes["value"].Value;
            ChangeSlideAnimation = OptionNode["change_slide_animation"].Attributes["value"].Value;
            string TextStyle = OptionNode["text_style"].Attributes["value"].Value;

            if (SlideshowUseInternalBox)
            {
                SlideshowInnerScriptValue = PageLoader.LoadWithText(StaticObject.SitePath + "client/elanat_slideshow/script/elanat_slideshow.js");
                SlideshowInnerStyleValue = PageLoader.LoadWithText(StaticObject.SitePath + "client/elanat_slideshow/style/elanat_slideshow.css");
            }

            if (SlideshowUseMaxWidth)
                SlideshowWidth = "100%";

            ChangeSlideCenterLocationValue = ((OptionNode["slideshow_height"].Attributes["value"].Value.ToNumber() / 2) + 50).ToString();

            SlideshowAnimationTemplate = TemplateDocument.SelectSingleNode("slideshow_root/slideshow/slide_animation_list/" + ChangeSlideAnimation).SetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage()).InnerText;

            SlideshowSlideItemTemplate = SlideshowSlideItemTemplate.Replace("$_asp slideshow_height;", SlideshowHeight);
            SlideshowSlideItemTemplate = SlideshowSlideItemTemplate.Replace("$_asp slide_image_object_fit;", SlideImageObjectFit);
            SlideshowSlideItemTemplate = SlideshowSlideItemTemplate.Replace("$_asp text_location;", TextLocation);
            SlideshowSlideItemTemplate = SlideshowSlideItemTemplate.Replace("$_asp change_slide_animation;", ChangeSlideAnimation);

            SlideshowSlideItemTemplate = (IncludeText) ? SlideshowSlideItemTemplate.Replace("$_asp text_hide_show;", "show") : SlideshowSlideItemTemplate.Replace("$_asp text_hide_show;", "hide");
            SlideshowSlideItemTemplate = (IncludeText) ? SlideshowSlideItemTemplate.Replace("$_asp text_style;", TextStyle) : "";
            SlideshowSlideItemTemplate = (IncludeText && UseTextBackground) ? SlideshowSlideItemTemplate.Replace("$_asp zone_use_background;", "use") : SlideshowSlideItemTemplate.Replace("$_asp zone_use_background;", "zone");

            string ImageHideShowValue = "show";
            string ImageIconSelectValue = "el_select";
            int ImageNumber = 0;

            foreach (XmlNode node in ImageNodeList)
            {
                string TmpSlideshowSlideItemTemplate = SlideshowSlideItemTemplate;

                TmpSlideshowSlideItemTemplate = TmpSlideshowSlideItemTemplate.Replace("$_asp image_name;", node.Attributes["name"].Value);
                TmpSlideshowSlideItemTemplate = TmpSlideshowSlideItemTemplate.Replace("$_asp image_hide_show;", ImageHideShowValue);

                if (IncludeText)
                    TmpSlideshowSlideItemTemplate = TmpSlideshowSlideItemTemplate.Replace("$_asp text;", node.Attributes["text"].Value);

                if (!string.IsNullOrEmpty(node.Attributes["link"].Value))
                {
                    string TmpSlideshowLinkTemplate = SlideshowLinkTemplate;

                    TmpSlideshowLinkTemplate = TmpSlideshowLinkTemplate.Replace("$_asp slideshow_link;", node.Attributes["link"].Value);

                    TmpSlideshowSlideItemTemplate = TmpSlideshowLinkTemplate.Replace("$_asp item;", TmpSlideshowSlideItemTemplate);
                }

                SumSlideshowSlideItemTemplate += TmpSlideshowSlideItemTemplate;

                ImageHideShowValue = "hide";


                string TmpSlideshowChangeSlideUnderIconListItemTemplate = SlideshowChangeSlideUnderIconListItemTemplate;

                TmpSlideshowChangeSlideUnderIconListItemTemplate = TmpSlideshowChangeSlideUnderIconListItemTemplate.Replace("$_asp image_name;", node.Attributes["name"].Value);
                TmpSlideshowChangeSlideUnderIconListItemTemplate = TmpSlideshowChangeSlideUnderIconListItemTemplate.Replace("$_asp first_select;", ImageIconSelectValue);
                TmpSlideshowChangeSlideUnderIconListItemTemplate = TmpSlideshowChangeSlideUnderIconListItemTemplate.Replace("$_asp image_number;", (ImageNumber++).ToString());

                SumSlideshowChangeSlideUnderIconListItemTemplate += TmpSlideshowChangeSlideUnderIconListItemTemplate;

                ImageIconSelectValue = "";
            }


            SlideItem = SumSlideshowSlideItemTemplate;
            ChangeSlideUnderIconItem = SumSlideshowChangeSlideUnderIconListItemTemplate;
        }
    }
}