using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ModuleElanatFaqOption : System.Web.UI.Page
    {
        public ModuleElanatFaqOptionModel model = new ModuleElanatFaqOptionModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveElanatFaqOption"]))
                btn_SaveElanatFaqOption_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_SaveElanatFaqs"]))
                btn_SaveElanatFaqs_Click(sender, e);


            model.SetValue();
        }

        protected void btn_SaveElanatFaqOption_Click(object sender, EventArgs e)
        {
            model.FaqUseInternalBoxValue = Request.Form["cbx_FaqUseInternalBox"] == "on";


            model.SaveElanatFaqOption();
        }

        protected void btn_SaveElanatFaqs_Click(object sender, EventArgs e)
        {
            foreach (string key in Request.Form.AllKeys)
            {
                int i = 0;

                // "txt_FaqQuestion_" Length Is 16
                if (key.Length < 17)
                    continue;

                if (key.Substring(0, 16) != "txt_FaqQuestion_")
                    continue;
                else
                    i = key.GetTextAfterValue("txt_FaqQuestion_").ToNumber();


                model.FaqQuestionValue.Add(Request.Form["txt_FaqQuestion_" + i.ToString()]);
                model.FaqAnswerValue.Add(Request.Form["txt_FaqAnswer_" + i.ToString()]);
            }


            model.SaveElanatFaqs();
        }
    }
}