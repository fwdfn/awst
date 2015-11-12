using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Timers;

namespace 艾维斯特.background.NewsFile
{
    public partial class NewsInformationManager : System.Web.UI.Page
    {
        public string columnInfo = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindType();
                if (Request.QueryString["id"] != null)
                {
                    columnInfo = "修改新闻信息";
                    bindUpdateInfo(Convert.ToInt32(Request.QueryString["id"]));
                }
                else
                {
                    columnInfo = "添加新闻信息";
                }                
            }              
        }
        /// <summary>
        /// 绑定父级栏目
        /// </summary>
        public void bindType()
        {
            ddlType.DataSource = dataHelper.dbHelper.getDS("select * from tb_menu where pid=5");
            ddlType.DataTextField = "title";
            ddlType.DataValueField = "id";
            ddlType.DataBind();
        }
        /// <summary>
        /// 绑定要修改的新闻信息
        /// </summary>
        /// <param name="id"></param>
        public void bindUpdateInfo(int id)
        {
            DataSet ds = dataHelper.dbHelper.getDS("select * from tb_newsInfo where id=" + id);
            NewsTitle.Value=ds.Tables[0].Rows[0]["title"].ToString();
            ddlType.SelectedValue=ds.Tables[0].Rows[0]["pid"].ToString();
            //DataSet ds2 = dataHelper.dbHelper.getDS("select * from tb_menu where pid=" + Convert.ToInt32(ds.Tables[0].Rows[0]["pid"]));
            EditColumnRightsort.Value = ds.Tables[0].Rows[0]["sort"].ToString();
            LinkUrl.Value = ds.Tables[0].Rows[0]["picpath"].ToString();
            ddlNewSource.SelectedValue = (ds.Tables[0].Rows[0]["source"].ToString()=="本站原创")?"0":"1";
            Clicks.Value = ds.Tables[0].Rows[0]["clicks"].ToString();
            txtColor.Value = ds.Tables[0].Rows[0]["titlecolor"].ToString();
            txtContent.Value = ds.Tables[0].Rows[0]["content"].ToString();
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["ishide"]) == 1)
            {
                isHide.Checked=true;
            }
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["ishot"]) == 1)
            {
                isHot.Checked = true;
            }
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["isrecommand"]) == 1)
            {
                isRecommand.Checked = true;
            }
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["isverify"]) == 1)
            {
                isVerify.Checked = true;
            }
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["isindex"]) == 1)
            {
                isIndex.Checked = true;
            }           
        }
        protected void submitBtn_ServerClick(object sender, EventArgs e)
        {
            string sqlText = string.Empty;
            SqlParameter[] para ={
                                     new SqlParameter("@title",NewsTitle.Value),
                                     new SqlParameter("@pid",ddlType.SelectedValue),
                                     new SqlParameter("@ishide",isHide.Checked?1:0),
                                     new SqlParameter("@isrecommand",isRecommand.Checked?1:0),
                                     new SqlParameter("@ishot",isHot.Checked?1:0),
                                     new SqlParameter("@isverify",isVerify.Checked?1:0),
                                     new SqlParameter("@isindex",isIndex.Checked?1:0),
                                     new SqlParameter("@sort",EditColumnRightsort.Value),
                                     new SqlParameter("@content",txtContent.Value),
                                     new SqlParameter("@titlecolor",txtColor.Value),
                                     new SqlParameter("@picpath",LinkUrl.Value),
                                     new SqlParameter("@source",ddlNewSource.SelectedValue=="0"?"本站原创":"外部新闻"),
                                     new SqlParameter("@clicks",Clicks.Value),
                                     new SqlParameter("@cdate",DateTime.Now),
                                     new SqlParameter("@id",Convert.ToInt32(Request.QueryString["id"]))
                                    }; 
            //修改功能
            if (Request.QueryString["id"] != null)
            {
                sqlText = "update tb_newsInfo set title=@title,pid=@pid,ishide=@ishide,isrecommand=@isrecommand,ishot=@ishot,isverify=@isverify,isindex=@isindex,sort=@sort,content=@content,titlecolor=@titlecolor,picpath=@picpath,source=@source,clicks=@clicks where id=@id";
                dataHelper.dbHelper.cmdExecute(sqlText, para);
                dataHelper.dbHelper.pageMsg(this, "修改成功", "../News.aspx");
            }
            else
            //添加功能
            {                    
                sqlText = "insert into tb_newsInfo values(@title,@pid,@ishide,@isrecommand,@ishot,@isverify,@isindex,@sort,@content,@titlecolor,@picpath,@source,@clicks,@cdate)";               
                dataHelper.dbHelper.cmdExecute(sqlText,para);
                dataHelper.dbHelper.pageMsg(this,"添加成功","../News.aspx");                
            }
        }
        //protected void uploadBtn_Click(object sender,EventArgs e)
        //{

        //}    
    }
}