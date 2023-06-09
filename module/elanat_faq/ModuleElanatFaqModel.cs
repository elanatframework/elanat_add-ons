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
    public class ModuleElanatFaqModel
    {
        public string FaqItem = "";
        public string FaqInnerScriptValue = "";
        public string FaqInnerStyleValue = "";

        public void SetValue()
        {
            XmlDocument TemplateDocument = new XmlDocument();
            TemplateDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_faq/template/template.xml"));
            string FaqItemTemplate = TemplateDocument.SelectSingleNode("faq_root/faq/faq_item").SetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage()).InnerText;
            string SumFaqItemTemplate = "";


            XmlDocument OptionDocument = new XmlDocument();
            OptionDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_faq/option/elanat_faq_option.xml"));
            XmlNode OptionNode = OptionDocument.SelectSingleNode("elanat_faq_option_root/option");
            XmlNodeList FaqNodeList = OptionDocument.SelectSingleNode("elanat_faq_option_root/faq_list").ChildNodes;

            bool FaqUseInternalBox = OptionNode["faq_use_internal_box"].Attributes["active"].Value.TrueFalseToBoolean();

            if (FaqUseInternalBox)
            {
                FaqInnerScriptValue = "<script>" + PageLoader.LoadWithText(StaticObject.SitePath + "client/elanat_faq/script/elanat_faq.js") + "</script>";
                FaqInnerStyleValue = "<style>" + PageLoader.LoadWithText(StaticObject.SitePath + "client/elanat_faq/style/elanat_faq.css") + "</style>";
            }

            int FaqNumber = 0;

            foreach (XmlNode node in FaqNodeList)
            {
                string TmpFaqItemTemplate = FaqItemTemplate;

                TmpFaqItemTemplate = TmpFaqItemTemplate.Replace("$_asp faq_question;", node.Attributes["question"].Value);
                TmpFaqItemTemplate = TmpFaqItemTemplate.Replace("$_asp faq_answer;", node.InnerText);
                TmpFaqItemTemplate = TmpFaqItemTemplate.Replace("$_asp faq_number;", (FaqNumber++).ToString());

                SumFaqItemTemplate += TmpFaqItemTemplate;
            }


            FaqItem = SumFaqItemTemplate;
        }
    }
}