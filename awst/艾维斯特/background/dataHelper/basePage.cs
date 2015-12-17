using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 艾维斯特.background.dataHelper
{
    public class basePage:System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string name = Request.QueryString["name"];
                //nameSpan.InnerText = name;
                if (Session["UserName"] == null)
                {
                    //string path = "/background/login.aspx";
                    //string js = "<script>alert('请登陆');window.location.href='/background/login.aspx'</script>";
                    //Response.Write(js);
                }
                else
                {
                    //pageLoad()要写在else里否则会暴露页面信息                                   
                }
                pageLoad();             
            }            
        }
        public virtual void pageLoad()
        {
         
        }

    }

}