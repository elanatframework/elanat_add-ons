using CodeBehind;

namespace Elanat
{
    public partial class ModuleElanatGalleryController : CodeBehindController
    {
        public ModuleElanatGalleryModel model = new ModuleElanatGalleryModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}