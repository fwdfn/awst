using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 艾维斯特
{
    public partial class index4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void time_Tick(object sender, EventArgs e)
        {
            showTime.InnerText = DateTime.Now.ToString();
        }
    }
}