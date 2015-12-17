using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using 艾维斯特.background.dataHelper;
using System.Web.UI.HtmlControls;

namespace 艾维斯特.background.AdvertisingFile
{
    public partial class Advertising : basePage
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        bindInfo("select * from tb_img where pid=0");
        //    }
        //}
        public override void pageLoad()
        {
            //base.pageLoad();
            if (!IsPostBack)
            {
                bindInfo("select * from tb_img where pid=0");
            }
        }
        public void bindInfo(string sqlText)
        {
            DataSet ds = dataHelper.dbHelper.getDS(sqlText);
            gv.DataSource = ds;
            gv.DataBind();
        }
        /// <summary>
        /// 获取产品图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string getSrc(int id)
        {
            DataSet ds = dataHelper.dbHelper.getDS("select * from tb_img where pid=0 and id="+id);
            return ds.Tables[0].Rows[0]["picpath"].ToString();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdvertisingManager.aspx");
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            int num = 0;
            foreach (GridViewRow gvr in gv.Rows)
            {
                HtmlInputCheckBox hick= gvr.Cells[0].FindControl("chk") as HtmlInputCheckBox;
                if (hick.Checked)
                {
                    num = Convert.ToInt32(gvr.Cells[1].Text);
                }
            }                        
            Response.Redirect("AdvertisingManager.aspx?id="+num);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string nums = "";
            foreach (GridViewRow gvr in gv.Rows)
            {
                HtmlInputCheckBox hick = gvr.Cells[0].FindControl("chk") as HtmlInputCheckBox;
                if (hick.Checked)
                {
                    nums += gvr.Cells[1].Text.ToString()+",";
                }                
            }
            nums=nums.TrimEnd(',');            
            dataHelper.dbHelper.cmdExecute("delete tb_img where id in("+nums+")");
            dataHelper.dbHelper.pageMsg(this, "删除成功", "Advertising.aspx");
        }
        public string setShowOrHide(int num)
        {
            string str ="";

            DataSet ds=dbHelper.getDS("select * from tb_img where pid=0 and id="+num);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["ishide"]) == 0)
                {
                    str = "否";
                }
                else
                {
                    str = "是";
                }
            }
            return str;
        }

        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gv_PageIndexChanging(object sender,GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;
            bindInfo("select * from tb_img where pid=0 and ishide=0");
         
        }
    }

}