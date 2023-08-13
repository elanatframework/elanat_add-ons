using CodeBehind;

namespace Elanat
{
    public partial class ActionElanatSlideshowUploadImageController : CodeBehindController
    {
        public ActionElanatSlideshowUploadImageModel model = new ActionElanatSlideshowUploadImageModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["image_name"]))
            {
                IgnoreViewAndModel = true;
                return;
            }

            model.ImageNameValue = context.Request.Query["image_name"].ToString();


            model.SetValue();

            View(model);
        }
    }
}