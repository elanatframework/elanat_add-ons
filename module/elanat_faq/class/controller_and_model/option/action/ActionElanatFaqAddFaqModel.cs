using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionElanatFaqAddFaqModel : CodeBehindModel
    {
        public void SetValue(string Index)
        {
            XmlDocument TemplateDocument = new XmlDocument();
            TemplateDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/module/elanat_faq/template/template.xml"));
            string FaqItemTemplate = TemplateDocument.SelectSingleNode("faq_root/option/faq_item").SetNodeVariant(StaticObject.GetCurrentSiteGlobalLanguage()).InnerText;

            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/module/elanat_faq/");
            string QuestionLanguage = aol.GetAddOnsLanguage("question");
            string AnswerLanguage = aol.GetAddOnsLanguage("answer");
            string DeleteLanguage = aol.GetAddOnsLanguage("delete");

            FaqItemTemplate = FaqItemTemplate.Replace("$_asp_lang question;", QuestionLanguage);
            FaqItemTemplate = FaqItemTemplate.Replace("$_asp_lang answer;", AnswerLanguage);
            FaqItemTemplate = FaqItemTemplate.Replace("$_asp_lang delete;", DeleteLanguage);
            FaqItemTemplate = FaqItemTemplate.Replace("$_asp faq_question;", "");
            FaqItemTemplate = FaqItemTemplate.Replace("$_asp faq_answer;", "");
            FaqItemTemplate = FaqItemTemplate.Replace("$_asp indexer;", Index);


            Write(FaqItemTemplate);
        }
    }
}