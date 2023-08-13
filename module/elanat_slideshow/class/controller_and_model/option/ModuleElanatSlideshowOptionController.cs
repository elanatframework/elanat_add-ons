using CodeBehind;

namespace Elanat
{
    public partial class ModuleElanatSlideshowOptionController : CodeBehindController
    {
        public ModuleElanatSlideshowOptionModel model = new ModuleElanatSlideshowOptionModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveElanatSlideshowOption"]))
            {
                btn_SaveElanatSlideshowOption_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_StartUpload"]))
            {
                btn_StartUpload_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveElanatSlideshowImages"]))
            {
                btn_SaveElanatSlideshowImages_Click(context);
                return;
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SaveElanatSlideshowOption_Click(HttpContext context)
        {
            model.SlideshowUseMaxWidthValue = context.Request.Form["cbx_SlideshowUseMaxWidth"] == "on";
            model.SlideshowUseInternalBoxValue = context.Request.Form["cbx_SlideshowUseInternalBox"] == "on";
            model.IncludeTextValue = context.Request.Form["cbx_IncludeText"] == "on";
            model.UseTextBackgroundValue = context.Request.Form["cbx_UseTextBackground"] == "on";
            model.SlideshowWidthValue = context.Request.Form["txt_SlideshowWidth"];
            model.SlideshowHeightValue = context.Request.Form["txt_SlideshowHeight"];
            model.ChangeSlideDelayValue = context.Request.Form["txt_ChangeSlideDelay"];
            model.SlideImageObjectFitOptionListSelectedValue = context.Request.Form["ddlst_SlideImageObjectFit"];
            model.TextLocationOptionListSelectedValue = context.Request.Form["ddlst_TextLocation"];
            model.ChangeSlideAnimationOptionListSelectedValue = context.Request.Form["ddlst_ChangeSlideAnimation"];
            model.TextStyleValue = context.Request.Form["txt_TextStyle"];


            // Evaluate Field Check
            model.EvaluateField(context.Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }


            model.SaveElanatSlideshowOption();

            View(model);
        }

        protected void btn_StartUpload_Click(HttpContext context)
        {
            model.ImagePathUploadValue = context.Request.Form.Files["upd_ImagePath"];
            model.UseImagePathValue = context.Request.Form["cbx_UseImagePath"] == "on";
            model.ImagePathTextValue = context.Request.Form["txt_ImagePath"];


            model.StartUpload();

            View(model);
        }

        protected void btn_SaveElanatSlideshowImages_Click(HttpContext context)
        {
            foreach (string key in context.Request.Form.Keys)
            {
                int i = 0;
				
				// "hdn_SlideshowImageName_" Length Is 23
                if (key.Length < 24)
                    continue;

                if (key.Substring(0, 23) != "hdn_SlideshowImageName_")
                    continue;
                else
                    i = key.GetTextAfterValue("hdn_SlideshowImageName_").ToNumber();

                if (string.IsNullOrEmpty(context.Request.Form["cbx_SlideshowImageActive_" + i]))
                    continue;

                if (context.Request.Form["cbx_SlideshowImageActive_" + i] != "on")
                    continue;

                model.SlideshowImageNameValue.Add(context.Request.Form["hdn_SlideshowImageName_" + i.ToString()]);
                model.SlideshowImageTextValue.Add(context.Request.Form["txt_SlideshowImageText_" + i.ToString()]);
                model.SlideshowImageLinkValue.Add(context.Request.Form["txt_SlideshowImageLink_" + i.ToString()]);
            }


            model.SaveElanatSlideshowImages();

            View(model);
        }
    }
}