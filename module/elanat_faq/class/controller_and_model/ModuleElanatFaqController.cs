using CodeBehind;

namespace Elanat
{
    public partial class ModuleElanatFaqController : CodeBehindController
    {
        public ModuleElanatFaqModel model = new ModuleElanatFaqModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}