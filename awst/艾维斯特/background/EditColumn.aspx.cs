using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace 艾维斯特.background
{
    //asp:fileupload里上传文件的文件名  id.FileName
    //                        文件大小  id.FileContent.Length
    //                      文件扩展名  System.IO.Path.getExtension("文件名");
    //                    文件上传路径  id.SaveAS(server.MapPath(路径+文件名))
    
    public partial class EditColumn : System.Web.UI.Page
    {        
        public string columnInfo = string.Empty;
        public string uploadFileName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                columnInfo = "修改栏目信息";
            }
            else
            {
              columnInfo="添加栏目信息";
            }
            if (!IsPostBack)
            {
                bindInfo();
            }
        }
        /// <summary>
        /// 绑定要修改的信息
        /// </summary>
        protected void bindInfo()
        {
            //判断是不是修改
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                DataSet ds = dataHelper.dbHelper.getDS("select * from tb_menu where id=" + id);
                name.Value = ds.Tables[0].Rows[0]["title"].ToString();
                int num = Convert.ToInt32(ds.Tables[0].Rows[0]["isHide"]);
                if (num == 0)
                {
                    Show.Checked = true;
                }
                else
                {
                    Hide.Checked = true;
                }
                if (ds.Tables[0].Rows[0]["picPath"] != null || ds.Tables[0].Rows[0]["picPath"].ToString() != "")
                {
                    uploadImg.Src = "~/Upload/" + ds.Tables[0].Rows[0]["picPath"].ToString();
                }                
                linkUrl.Value = ds.Tables[0].Rows[0]["linkUrl"].ToString();
                EditColumnRightsort.Value = ds.Tables[0].Rows[0]["sort"].ToString();
                txtContent.Value = ds.Tables[0].Rows[0]["content"].ToString();
            }            
        }

        /// <summary>
        /// 上传文件功能
        /// 1：不能什么都不传
        /// 2：大小不能超过4M
        /// 3:只能上传图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void uploadBtn_Click(object sender, EventArgs e)
        {
            //获取上传文件名
            uploadFileName = upload.FileName;
            ViewState["pic"] = upload.FileName;
            if (uploadFileName.Length <= 0)
            {
                dataHelper.dbHelper.pageMsg2(this.Page, "请先选择你要上传的图片");
                return;
            }
            //获取上传文件大小
            long size= upload.FileContent.Length;
            //上传文件大小不能超过4M

            if (size > 4194304)
            {
                dataHelper.dbHelper.pageMsg2(this.Page, "文件不能超过4M");
                return;
            }         
            //获取上传文件的扩展名
            string ext = System.IO.Path.GetExtension(uploadFileName);
            if (ext.ToLower() == ".jpg" || ext.ToLower() == ".gif" || ext.ToLower() == ".png")
            {
                upload.SaveAs(Server.MapPath("../Upload/" + uploadFileName));
                uploadImg.Src = "../Upload/" + uploadFileName;
            }
            else
            {
                dataHelper.dbHelper.pageMsg2(this.Page, "请上传图片");
                return;
            }                           
        }

        /// <summary>
        /// 添加栏目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void submitBtn_ServerClick(object sender, EventArgs e)
        {
            int num = Hide.Checked ? 1 : 0;
            //添加功能
            string sqlText;            
            if (Request.QueryString["pid"] != null)
            {
                //传过来的id为子栏目的父id
                int id = Convert.ToInt32(Request.QueryString["pid"]);                
                sqlText = "insert into tb_menu values(@title,@pid,@isHide,@sort,@picPath,@content,@linkUrl,@cdate)";                
                SqlParameter[] para = {
                                  new SqlParameter("@title",name.Value),
                                  new SqlParameter("@pid",id),
                                  new SqlParameter("@isHide",num),
                                  new SqlParameter("@sort",EditColumnRightsort.Value),
                                  new SqlParameter("@picPath",ViewState["pic"]!=null?ViewState["pic"].ToString():""),
                                  new SqlParameter("@content",txtContent.Value),
                                  new SqlParameter("@linkUrl",linkUrl.Value),
                                  new SqlParameter("@cdate",DateTime.Now),                                                                       
                                  };
                
                dataHelper.dbHelper.cmdExecute(sqlText, para);                                
                dataHelper.dbHelper.pageMsg(this.Page, "添加成功", "column.aspx?id="+Convert.ToInt32(Request.QueryString["pid"]));
            }
            //修改功能
            if (Request.QueryString["id"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                sqlText = "update tb_menu set title=@title,isHide=@isHide,sort=@sort,picPath=@picPath,content=@content,linkUrl=@linkUrl,cdate=@cdate where id=@id";
                SqlParameter[] para = {
                                  new SqlParameter("@title",name.Value),                                  
                                  new SqlParameter("@isHide",num),
                                  new SqlParameter("@sort",EditColumnRightsort.Value),
                                  new SqlParameter("@picPath",""),
                                  new SqlParameter("@content",txtContent.Value),
                                  new SqlParameter("@linkUrl",linkUrl.Value),
                                  new SqlParameter("@cdate",DateTime.Now),   
                                  new SqlParameter("@id",id)                                                                    
                                  };
                DataSet ds=dataHelper.dbHelper.getDS("select * from tb_menu where id="+id);
                dataHelper.dbHelper.cmdExecute(sqlText, para);
                dataHelper.dbHelper.pageMsg(this.Page,"修改成功","column.aspx?id="+Convert.ToInt32(ds.Tables[0].Rows[0]["pid"]));
            }                        
        }
    }
}