using CodeBehind;
using Elanat.DataUse;

namespace Elanat
{
    public partial class ModuleElanatFaqOptionController : CodeBehindController
    {
        public ModuleElanatFaqOptionModel model = new ModuleElanatFaqOptionModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveElanatFaqOption"]))
            {
                btn_SaveElanatFaqOption_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveElanatFaqs"]))
            {
                btn_SaveElanatFaqs_Click(context);
                return;
            }


            model.SetValue();

            View(model);
        }

        protected void btn_SaveElanatFaqOption_Click(HttpContext context)
        {
            model.FaqUseInternalBoxValue = context.Request.Form["cbx_FaqUseInternalBox"] == "on";


            model.SaveElanatFaqOption();

            View(model);
        }

        protected void btn_SaveElanatFaqs_Click(HttpContext context)
        {
            foreach (string key in context.Request.Form.Keys)
            {
                int i = 0;

                // "txt_FaqQuestion_" Length Is 16
                if (key.Length < 17)
                    continue;

                if (key.Substring(0, 16) != "txt_FaqQuestion_")
                    continue;
                else
                    i = key.GetTextAfterValue("txt_FaqQuestion_").ToNumber();


                model.FaqQuestionValue.Add(context.Request.Form["txt_FaqQuestion_" + i.ToString()]);
                model.FaqAnswerValue.Add(context.Request.Form["txt_FaqAnswer_" + i.ToString()]);
            }


            model.SaveElanatFaqs();

            View(model);
        }
    }
}