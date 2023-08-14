using CodeBehind;

namespace Elanat
{
    public partial class ModuleElanatGalleryOptionController : CodeBehindController
    {
        public ModuleElanatGalleryOptionModel model = new ModuleElanatGalleryOptionModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveElanatGalleryOption"]))
            {
                btn_SaveElanatGalleryOption_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_StartUpload"]))
            {
                btn_StartUpload_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveElanatGalleryImages"]))
            {
                btn_SaveElanatGalleryImages_Click(context);
                return;
            }


            model.SetValue();

            View(model);
        }

        protected void btn_SaveElanatGalleryOption_Click(HttpContext context)
        {
            model.GalleryUseInternalBoxValue = context.Request.Form["cbx_GalleryUseInternalBox"] == "on";


            model.SaveElanatGalleryOption();

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

        protected void btn_SaveElanatGalleryImages_Click(HttpContext context)
        {
            foreach (string key in context.Request.Form.Keys)
            {
                int i = 0;

                // "hdn_GalleryImageName_" Length Is 21
                if (key.Length < 22)
                    continue;

                if (key.Substring(0, 21) != "hdn_GalleryImageName_")
                    continue;
                else
                    i = key.GetTextAfterValue("hdn_GalleryImageName_").ToNumber();

                if (string.IsNullOrEmpty(context.Request.Form["cbx_GalleryImageActive_" + i]))
                    continue;

                if (context.Request.Form["cbx_GalleryImageActive_" + i] != "on")
                    continue;

                model.GalleryImageNameValue.Add(context.Request.Form["hdn_GalleryImageName_" + i.ToString()]);
                model.GalleryImageTextValue.Add(context.Request.Form["txt_GalleryImageText_" + i.ToString()]);
            }


            model.SaveElanatGalleryImages();

            View(model);
        }
    }
}