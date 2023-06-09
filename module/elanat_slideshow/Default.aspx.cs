using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ModuleElanatSlideshow : System.Web.UI.Page
    {
        public ModuleElanatSlideshowModel model = new ModuleElanatSlideshowModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            model.SetValue();
        }
    }
}