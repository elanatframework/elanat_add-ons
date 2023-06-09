using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ModuleElanatGalleryOption : System.Web.UI.Page
    {
        public ModuleElanatGalleryOptionModel model = new ModuleElanatGalleryOptionModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveElanatGalleryOption"]))
                btn_SaveElanatGalleryOption_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_StartUpload"]))
                btn_StartUpload_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_SaveElanatGalleryImages"]))
                btn_SaveElanatGalleryImages_Click(sender, e);


            model.SetValue();
        }

        protected void btn_SaveElanatGalleryOption_Click(object sender, EventArgs e)
        {
            model.GalleryUseInternalBoxValue = Request.Form["cbx_GalleryUseInternalBox"] == "on";


            model.SaveElanatGalleryOption();
        }

        protected void btn_StartUpload_Click(object sender, EventArgs e)
        {
            model.ImagePathUploadValue = Request.Files["upd_ImagePath"];
            model.UseImagePathValue = Request.Form["cbx_UseImagePath"] == "on";
            model.ImagePathTextValue = Request.Form["txt_ImagePath"];


            model.StartUpload();
        }

        protected void btn_SaveElanatGalleryImages_Click(object sender, EventArgs e)
        {
            foreach (string key in Request.Form.AllKeys)
            {
                int i = 0;

                // "hdn_GalleryImageName_" Length Is 21
                if (key.Length < 22)
                    continue;

                if (key.Substring(0, 21) != "hdn_GalleryImageName_")
                    continue;
                else
                    i = key.GetTextAfterValue("hdn_GalleryImageName_").ToNumber();

                if (string.IsNullOrEmpty(Request.Form["cbx_GalleryImageActive_" + i]))
                    continue;

                if (Request.Form["cbx_GalleryImageActive_" + i] != "on")
                    continue;

                model.GalleryImageNameValue.Add(Request.Form["hdn_GalleryImageName_" + i.ToString()]);
                model.GalleryImageTextValue.Add(Request.Form["txt_GalleryImageText_" + i.ToString()]);
            }


            model.SaveElanatGalleryImages();
        }
    }
}