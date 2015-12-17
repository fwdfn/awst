using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using 艾维斯特.background.dataHelper;
using System.Configuration;

namespace 艾维斯特.background
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {              
          
        }
        protected void login_btn_Click(object sender, EventArgs e)
        {
            //获取验证码
            string verifyCode = Request.Cookies["CheckCode"].Value;
            if (verity.Value.ToUpper() == verifyCode)
            {
                string sqlText = "select * from tb_admin where name='" + userName.Value + "'and pwd='" + userPwd.Value + "'";
                DataSet ds = dbHelper.getDS(sqlText);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //Session传递登陆用户，并将其登陆次数加1
                    Session["UserName"] = userName.Value;                                     
                    dbHelper.cmdExecute("update tb_admin set loginCount=loginCount+1 where name='" + userName.Value + "'");
                    dbHelper.pageMsg(this.Page, "登陆成功", "index.aspx","");
                }
                else
                {
                    dbHelper.pageMsg(this.Page, "用户名或密码错误", "");
                }
            }
            else
            {
                dbHelper.pageMsg(this.Page, "验证码错误","");                
            }
        }        
    }
}