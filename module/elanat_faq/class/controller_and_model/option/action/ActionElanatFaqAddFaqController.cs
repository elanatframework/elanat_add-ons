using CodeBehind;

namespace Elanat
{
    public partial class ActionElanatFaqAddFaqController : CodeBehindController
    {
        public ActionElanatFaqAddFaqModel model = new ActionElanatFaqAddFaqModel();

        public void PageLoad(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Query["index"]))
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            if (!context.Request.Query["index"].ToString().IsNumber())
            {
                Write("false");

                IgnoreViewAndModel = true;

                return;
            }

            string Index = context.Request.Query["index"].ToString();

            model.SetValue(Index);

            View(model);
        }
    }
}