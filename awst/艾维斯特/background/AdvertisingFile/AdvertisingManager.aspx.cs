using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace 艾维斯特.background.AdvertisingFile
{
    public partial class AdvertisingManager : dataHelper.basePage
    {
        public string operation = string.Empty;
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        if (Request.QueryString["id"] == null)
        //        {
        //            operation = "添加图片";
        //        }
        //        else
        //        {
        //            operation = "编辑图片";
        //            bindInfo();
        //        }
        //    }
        //}
        public override void pageLoad()
        {
            //base.pageLoad();
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    operation = "添加图片";
                }
                else
                {
                    operation = "编辑图片";
                    bindInfo();
                }
            }
        }
        /// <summary>
        /// 绑定要修改的图片的信息
        /// </summary>
        public void bindInfo()
        {
            DataSet ds = dataHelper.dbHelper.getDS("select * from tb_img where id="+Convert.ToInt32(Request.QueryString["id"]));
            if (ds.Tables[0].Rows.Count > 0)
            {
                name.Value = ds.Tables[0].Rows[0]["title"].ToString();
                type.Value = ds.Tables[0].Rows[0]["pid"].ToString();
                EditColumnRightsort.Value = ds.Tables[0].Rows[0]["sort"].ToString();
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["ishide"]) == 0)
                {
                    show.Checked = true;                    
                }
                else
                {
                    hide.Checked = true;
                }
                upLoadImg.Src = ds.Tables[0].Rows[0]["picpath"].ToString();                
                ViewState["pic"] = upLoadImg.Src;
            }          
        }
        protected void upLoadBtn_Click(object sender, EventArgs e)
        {
            string fileName = upLoad.PostedFile.FileName;
            int fileLength = upLoad.PostedFile.ContentLength;
            string ext = System.IO.Path.GetExtension(fileName);
            if (ext.ToLower() == ".jpg" || ext.ToLower() == ".png" || ext.ToLower() == ".gif")
            {
                upLoad.SaveAs(Server.MapPath("../../Upload/") + fileName);
                upLoadImg.Src = "../../Upload/" + fileName;
                ViewState["pic"] = upLoadImg.Src;
                name.Value = "Upload/"+fileName;
                
                dataHelper.dbHelper.pageMsg2(this,"图片上传成功");
            }
            else
            {
                dataHelper.dbHelper.pageMsg2(this, "请上传图片");
            }   
        }
        protected void submitBtn_ServerClick(object sender, EventArgs e)
        {
            string sqlText = "";           
            int num=show.Checked==true?0:1;            
            SqlParameter[] para ={
                                 new SqlParameter("@title",name.Value),
                                 new SqlParameter("@pid",Convert.ToInt32(type.Value)),
                                 new SqlParameter("@sort",Convert.ToInt32(EditColumnRightsort.Value)),
                                 new SqlParameter("@ishide",num),
                                 new SqlParameter("@picpath",ViewState["pic"].ToString()),
                                 new SqlParameter("@cdate",DateTime.Now),
                                 new SqlParameter("@id",Convert.ToInt32(Request.QueryString["id"]))
                                };
            //编辑功能
            if (Request.QueryString["id"] != null)
            {
                sqlText = "update tb_img set title=@title,pid=@pid,sort=@sort,ishide=@ishide,picpath=@picpath,cdate=@cdate where id=@id";                
                dataHelper.dbHelper.cmdExecute(sqlText, para);
                dataHelper.dbHelper.pageMsg(this, "更新成功", "Advertising.aspx");                
            }
            else {    //添加功能
                sqlText = "insert into tb_img values(@title,@pid,@sort,@ishide,@picpath,@cdate)";
                dataHelper.dbHelper.cmdExecute(sqlText, para);
                dataHelper.dbHelper.pageMsg(this, "添加成功", "Advertising.aspx");
            }
        }
    }
}