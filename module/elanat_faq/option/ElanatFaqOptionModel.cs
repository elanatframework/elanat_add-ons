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
    public class ModuleElanatFaqOptionModel
    {
        public string ElanatFaqLanguage { get; set; }
        public string ElanatFaqsLanguage { get; set; }
        public string FaqUseInternalBoxLanguage { get; set; }
        public string SaveElanatFaqOptionLanguage { get; set; }
        public string SaveElanatFaqsLanguage { get; set; }
        public string AddLanguage { get; set; }

        public bool FaqUseInternalBoxValue { get; set; } = false;

        public string FaqItemValue { get; set; }

        public List<string> FaqQuestionValue = new List<string>();
        public List<string> FaqAnswerValue = new List<string>();

        public bool FindEvaluateError = false;


        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_faq/");
            ElanatFaqLanguage = aol.GetAddOnsLanguage("elanat_faq");
            FaqUseInternalBoxLanguage = aol.GetAddOnsLanguage("faq_use_internal_box");
            SaveElanatFaqOptionLanguage = aol.GetAddOnsLanguage("save_elanat_faq_option");
            SaveElanatFaqsLanguage = aol.GetAddOnsLanguage("save_elanat_faqs");
            AddLanguage = aol.GetAddOnsLanguage("add");


            // Set Current Value
            XmlDocument ElanatFaqOptionDocument = new XmlDocument();
            ElanatFaqOptionDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_faq/option/elanat_faq_option.xml"));

            XmlNode node = ElanatFaqOptionDocument.SelectSingleNode("elanat_faq_option_root/option");

            FaqUseInternalBoxValue = (node["faq_use_internal_box"].Attributes["active"].Value == "true");

            SetFaqList();
        }

        public void SaveElanatFaqOption()
        {
            XmlDocument ElanatFaqOptionDocument = new XmlDocument();
            ElanatFaqOptionDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_faq/option/elanat_faq_option.xml"));

            ElanatFaqOptionDocument.SelectSingleNode("elanat_faq_option_root/option/faq_use_internal_box").Attributes["active"].Value = FaqUseInternalBoxValue.BooleanToTrueFalse();

            ElanatFaqOptionDocument.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_faq/option/elanat_faq_option.xml"));


            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_faq/catalog.xml"));

            if (FaqUseInternalBoxValue)
                CatalogDocument.SelectSingleNode("module_catalog_root/module_static_head").InnerXml = "";
            else
            {
                XmlDocument TemplateDocument = new XmlDocument();
                TemplateDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_faq/template/template.xml"));
                string FaqStaticHeadExternalBoxTemplateXml = TemplateDocument.SelectSingleNode("faq_root/option/static_head_external_box").SetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage()).InnerXml;

                CatalogDocument.SelectSingleNode("module_catalog_root/module_static_head").InnerXml = FaqStaticHeadExternalBoxTemplateXml;
            }

            CatalogDocument.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_faq/catalog.xml"));


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_elanat_faq_option", null);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("elanat_faq_option_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_faq/"), "success");
        }

        public void SetFaqList()
        {
            XmlDocument TemplateDocument = new XmlDocument();
            TemplateDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_faq/template/template.xml"));
            string FaqItemTemplate = TemplateDocument.SelectSingleNode("faq_root/option/faq_item").SetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage()).InnerText;
            string SumFaqItemTemplate = "";

            XmlDocument OptionDocument = new XmlDocument();
            OptionDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_faq/option/elanat_faq_option.xml"));
            XmlNodeList FaqNodeList = OptionDocument.SelectSingleNode("elanat_faq_option_root/faq_list").ChildNodes;

            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_faq/");
            string QuestionLanguage = aol.GetAddOnsLanguage("question");
            string AnswerLanguage = aol.GetAddOnsLanguage("answer");
            string DeleteLanguage = aol.GetAddOnsLanguage("delete");

            FaqItemTemplate = FaqItemTemplate.Replace("$_asp_lang question;", QuestionLanguage);
            FaqItemTemplate = FaqItemTemplate.Replace("$_asp_lang answer;", AnswerLanguage);
            FaqItemTemplate = FaqItemTemplate.Replace("$_asp_lang delete;", DeleteLanguage);

            int FaqNumber = 0;

            foreach (XmlNode node in FaqNodeList)
            {
                string TmpFaqItemTemplate = FaqItemTemplate;

                TmpFaqItemTemplate = TmpFaqItemTemplate.Replace("$_asp faq_question;", node.Attributes["question"].Value);
                TmpFaqItemTemplate = TmpFaqItemTemplate.Replace("$_asp faq_answer;", node.InnerText);
                TmpFaqItemTemplate = TmpFaqItemTemplate.Replace("$_asp indexer;", (FaqNumber++).ToString());


                SumFaqItemTemplate += TmpFaqItemTemplate;
            }

            FaqItemValue = SumFaqItemTemplate;
        }

        public void SaveElanatFaqs()
        {
            XmlDocument ElanatFaqOptionDocument = new XmlDocument();
            ElanatFaqOptionDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_faq/option/elanat_faq_option.xml"));

            ElanatFaqOptionDocument.SelectSingleNode("elanat_faq_option_root/faq_list").InnerXml = null;

            for (int i = FaqAnswerValue.Count - 1; i >= 0; i--)
            {
                XmlElement FaqElement = ElanatFaqOptionDocument.CreateElement("faq");
                FaqElement.SetAttribute("question", FaqQuestionValue[i]);
                FaqElement.InnerText = FaqAnswerValue[i];

                ElanatFaqOptionDocument.SelectSingleNode("elanat_faq_option_root/faq_list").AppendChild(FaqElement);
            }

            ElanatFaqOptionDocument.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "add_on/module/elanat_faq/option/elanat_faq_option.xml"));


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_elanat_faqs_list", null);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("elanat_faqs_list_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_faq/"), "success");
        }
    }
}