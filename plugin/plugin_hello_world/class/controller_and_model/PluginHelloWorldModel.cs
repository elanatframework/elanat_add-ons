using CodeBehind;

namespace Elanat
{
    public partial class PluginHelloWorldModel : CodeBehindModel
    {
        public string HelloWorldMessage { get; private set; } = "";
        public void SetValue()
        {
            HelloWorldMessage = "Hello World!";
        }
    }
}