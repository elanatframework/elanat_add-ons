using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ModuleElanatSlideshowOption : System.Web.UI.Page
    {
        public ModuleElanatSlideshowOptionModel model = new ModuleElanatSlideshowOptionModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveElanatSlideshowOption"]))
                btn_SaveElanatSlideshowOption_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_StartUpload"]))
                btn_StartUpload_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_SaveElanatSlideshowImages"]))
                btn_SaveElanatSlideshowImages_Click(sender, e);


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveElanatSlideshowOption_Click(object sender, EventArgs e)
        {
            model.SlideshowUseMaxWidthValue = Request.Form["cbx_SlideshowUseMaxWidth"] == "on";
            model.SlideshowUseInternalBoxValue = Request.Form["cbx_SlideshowUseInternalBox"] == "on";
            model.IncludeTextValue = Request.Form["cbx_IncludeText"] == "on";
            model.UseTextBackgroundValue = Request.Form["cbx_UseTextBackground"] == "on";
            model.SlideshowWidthValue = Request.Form["txt_SlideshowWidth"];
            model.SlideshowHeightValue = Request.Form["txt_SlideshowHeight"];
            model.ChangeSlideDelayValue = Request.Form["txt_ChangeSlideDelay"];
            model.SlideImageObjectFitOptionListSelectedValue = Request.Form["ddlst_SlideImageObjectFit"];
            model.TextLocationOptionListSelectedValue = Request.Form["ddlst_TextLocation"];
            model.ChangeSlideAnimationOptionListSelectedValue = Request.Form["ddlst_ChangeSlideAnimation"];
            model.TextStyleValue = Request.Form["txt_TextStyle"];


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.SaveElanatSlideshowOption();
        }

        protected void btn_StartUpload_Click(object sender, EventArgs e)
        {
            model.ImagePathUploadValue = Request.Files["upd_ImagePath"];
            model.UseImagePathValue = Request.Form["cbx_UseImagePath"] == "on";
            model.ImagePathTextValue = Request.Form["txt_ImagePath"];


            model.StartUpload();
        }

        protected void btn_SaveElanatSlideshowImages_Click(object sender, EventArgs e)
        {
            foreach (string key in Request.Form.AllKeys)
            {
                int i = 0;
				
				// "hdn_SlideshowImageName_" Length Is 23
                if (key.Length < 24)
                    continue;

                if (key.Substring(0, 23) != "hdn_SlideshowImageName_")
                    continue;
                else
                    i = key.GetTextAfterValue("hdn_SlideshowImageName_").ToNumber();

                if (string.IsNullOrEmpty(Request.Form["cbx_SlideshowImageActive_" + i]))
                    continue;

                if (Request.Form["cbx_SlideshowImageActive_" + i] != "on")
                    continue;

                model.SlideshowImageNameValue.Add(Request.Form["hdn_SlideshowImageName_" + i.ToString()]);
                model.SlideshowImageTextValue.Add(Request.Form["txt_SlideshowImageText_" + i.ToString()]);
                model.SlideshowImageLinkValue.Add(Request.Form["txt_SlideshowImageLink_" + i.ToString()]);
            }


            model.SaveElanatSlideshowImages();
        }
    }
}