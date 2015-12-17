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
    public partial class ucBottom : System.Web.UI.UserControl
    {
        public string companyInfo = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            bind();
        }
        public void bind()
        {
            //<%--公司电话：027－87166527 公司传真：027-87530722 公司QQ：1740864522 公司地址：武汉市洪山区雄楚大街450号
            //         <br />
            //         公司邮箱：avist_wh@163.com 技术支持：<a href="#">仙桃赵斌</a> <a href="#">[网站管理]</a> 
            //         <br />
            //         武汉艾维斯特科技有限公司 版权所有 ©--%>
            DataSet ds = 艾维斯特.background.dataHelper.dbHelper.getDS("select * from tb_companyInfo");
            if (ds.Tables[0].Rows.Count > 0)
            {
                companyInfo = "公司电话:" + ds.Tables[0].Rows[0]["phone"] + "&nbsp;公司传真:" + ds.Tables[0].Rows[0]["fax"] + "&nbsp;公司QQ:" + ds.Tables[0].Rows[0]["qq"] + "&nbsp;公司地址:" + ds.Tables[0].Rows[0]["address"];
                companyInfo += "<br>公司邮箱:" + ds.Tables[0].Rows[0]["email"] + "&nbsp;技术支持:" + ds.Tables[0].Rows[0]["support"];
                companyInfo += "<br>" + ds.Tables[0].Rows[0]["copyright"] + "&nbsp;版权所有©";            
            }
            
        }
    }
}