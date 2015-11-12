using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace 艾维斯特.background
{
    public partial class abc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindInfo();
            }
        }
        protected void bindInfo()
        {
            DataSet ds = dataHelper.dbHelper.getDS("select * from tb_menu");
            gv.DataSource = ds;
            gv.DataBind();
        }
    }
}