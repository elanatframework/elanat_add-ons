using CodeBehind;

namespace Elanat
{
    public partial class PluginHelloWorldController : CodeBehindController
    {
        public PluginHelloWorldModel model = new PluginHelloWorldModel();

        public void PageLoad(HttpContext context)
        {
            model.SetValue();

            View(model);
        }
    }
}