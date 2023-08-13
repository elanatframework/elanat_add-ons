using CodeBehind;

namespace Elanat
{
    public partial class ModuleElanatSlideshowController : CodeBehindController
    {
        public ModuleElanatSlideshowModel model = new ModuleElanatSlideshowModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}