using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Text;

namespace 艾维斯特.background.NewsFile
{
    public partial class News : System.Web.UI.Page
    {
        public string sqlSelectText = "select * from tb_newsInfo";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindInfo();
                DataSet ds = dataHelper.dbHelper.getDS("select * from tb_menu where pid=" + Convert.ToInt32(Request.QueryString["id"]));
                ddlType.DataSource = ds;
                ddlType.DataTextField = "title";
                ddlType.DataValueField = "id";
                ddlType.DataBind();
                ddlType.Items.Add(new ListItem("所有类别", "0"));
                ddlType.SelectedValue = "0";
            }

        }
        protected void bindInfo()
        {
            DataSet ds = dataHelper.dbHelper.getDS("select * from tb_newsInfo");
            gv.DataSource = ds;
            gv.DataBind();
        }
        protected void bindInfo(string sqlText)
        {
            DataSet ds = dataHelper.dbHelper.getDS(sqlText);
            gv.DataSource = ds;
            gv.DataBind();
        }
        /// <summary>
        /// 通过gv绑定的pid获取父标题名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string getParentName(int id)
        {
            DataSet ds = dataHelper.dbHelper.getDS("select * from tb_menu where id=" + id);
            return ds.Tables[0].Rows[0]["title"].ToString();
        }
        protected void gv_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("onmouseover", "c=this.style.background;this.style.background='#e6f0fc'");
            e.Row.Attributes.Add("onmouseout", "this.style.background=c");
        }
        /// <summary>
        /// 删除选中新闻
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            //找到选中的checkbox
            StringBuilder sb = new StringBuilder();
            foreach (GridViewRow gvr in gv.Rows)
            {
                HtmlInputCheckBox hib = gvr.Cells[0].FindControl("chk") as HtmlInputCheckBox;
                if (hib.Checked)
                {
                    sb.Append(gvr.Cells[1].Text.ToString() + ",");
                }
            }
            //去掉最一个,
            sb.Remove(sb.Length - 1, 1);
            dataHelper.dbHelper.cmdExecute("delete tb_newsInfo where id in(" + sb.ToString() + ")");
            dataHelper.dbHelper.pageMsg(this, "删除成功", "News.aspx");
        }

        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;
            string sqlText = getSort(bindInfoByConditions() + " and title like '%" + searchText.Value + "%'");
            bindInfo(sqlText);
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnVerify_Click(object sender, EventArgs e)
        {
            string nums = string.Empty;
            foreach (GridViewRow gvr in gv.Rows)
            {
                HtmlInputCheckBox hicb = gvr.Cells[0].FindControl("chk") as HtmlInputCheckBox;
                if (hicb.Checked)
                {
                    nums += gvr.Cells[1].Text.ToString() + ",";
                }
            }
            nums = nums.TrimEnd(',');
            dataHelper.dbHelper.cmdExecute("update tb_newsInfo set isverify=1 where id in(" + nums + ")");
            dataHelper.dbHelper.pageMsg(this, "已经审核", "News.aspx");
        }

        /// <summary>
        /// 排序方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
        {

            string sqlText = getSort(bindInfoByConditions());
            bindInfo(sqlText);
        }

        /// <summary>
        /// 快速定位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

            string sqlText = getSort(bindInfoByConditions());
            bindInfo(sqlText);
        }
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlText = getSort(bindInfoByConditions());
            bindInfo(sqlText);
        }
        public string bindInfoByConditions()
        {
            switch (ddlSelect.SelectedIndex)
            {
                case 0:
                    sqlSelectText += " where 1=1";
                    break;
                //已审核
                case 1:
                    sqlSelectText += " where isverify=1";
                    break;
                //未审核
                case 2:
                    sqlSelectText += " where isverify=0";
                    break;
                //已推荐
                case 3:
                    sqlSelectText += " where isrecommand=1";
                    break;
                //未推荐
                case 4:
                    sqlSelectText += " where isrecommand=0";
                    break;
            }
            if (Convert.ToInt32(ddlType.SelectedValue) != 0)
            {
                sqlSelectText += " and pid=" + ddlType.SelectedValue;
            }
            return sqlSelectText;
        }
        /// <summary>
        /// 按顺序排列
        /// </summary>
        /// <returns></returns>
        public string getSort(string sqlSelectText)
        {
            switch (ddlSort.SelectedIndex)
            {
                case 0:
                    sqlSelectText += "";
                    break;
                case 1:
                    sqlSelectText += " order by id";
                    break;
                case 2:
                    sqlSelectText += " order by id desc";
                    break;
                case 3:
                    sqlSelectText += " order by cdate";
                    break;
                case 4:
                    sqlSelectText += " order by cdate desc";
                    break;
            }
            return sqlSelectText;
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            string sqlText = getSort(bindInfoByConditions() + " and title like '%" + searchText.Value + "%'");
            bindInfo(sqlText);
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewsInformationManager.aspx?");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            //定义变量num用来进行传值，因num无值设其为0，但0并无作用，求更好的办法
            int num = 0;
            foreach (GridViewRow dvr in gv.Rows)
            {
                HtmlInputCheckBox hck = dvr.Cells[0].FindControl("chk") as HtmlInputCheckBox;
                if (hck.Checked)
                {
                    num = Convert.ToInt32(dvr.Cells[1].Text);
                }
            }
            Response.Redirect("NewsInformationManager.aspx?id=" + num);
        }                
    }
}