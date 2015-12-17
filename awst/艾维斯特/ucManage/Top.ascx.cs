using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using 艾维斯特.background.dataHelper;

namespace 艾维斯特.ucManage
{
    public partial class Top : System.Web.UI.UserControl
    {
        public string bindMenu = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            bindMainMenu();
        }
        public void bindMainMenu()
        {
            DataSet ds = dbHelper.getDS("select * from tb_menu where pid=0 and isHide=0 order by sort");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    bindMenu += "<li><a href=\""+dr["linkUrl"].ToString()+"\">" + dr[1].ToString() + "</a></li>";
                }
            }
        }
    }
}