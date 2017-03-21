using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RL.DBUtility;
using System.Text;
using System.Data.SqlClient;

namespace Supermarket
{
    public partial class CommoditySort : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //隐藏ID列
                gvCommodity.Columns[6].Visible = false;
                //设置主键
                gvCommodity.DataKeyNames = new string[] { "CommodityID" };

                StringBuilder sbSql = new StringBuilder();//构造字符串，string会引入一些垃圾
                sbSql.AppendLine("SELECT CommodityID,CommodityName,CommoditySort.SortName,CommodityPrice,IsDiscount,ReducedPrice from Commodity,CommoditySort where Commodity.SortID = CommoditySort.SortID");//提前写好sql语句

                DataSet ds = DbHelperSQL.Query(sbSql.ToString());
                gvCommodity.DataSource = ds;
                gvCommodity.DataBind();
            }

        }
        //数据绑定
        private void BindData()
        {

        }


        protected void buttonSearch_Click(object sender, EventArgs e)
        {
            //操作前的准备
            string Cname = "%" + textSearch.Text + "%";//获取数据并添加模糊查询
            //准备好sql语句
            string sql = "SELECT CommodityID,CommodityName,CommoditySort.SortName,CommodityPrice,IsDiscount,ReducedPrice from Commodity,CommoditySort where Commodity.SortID = CommoditySort.SortID and CommodityName like @CommodityName";
            SqlParameter[] pms = { 
                                 new SqlParameter("@CommodityName",SqlDbType.NVarChar,50)
                                 };//创建参数
            pms[0].Value = Cname;//为参数赋值
            //DataSet是将查询结果填充到本地内存中，这样即使与连接断开，服务器的连接断开，都不会影响数据的读取。
            //但是它也有一个坏处，就是只有小数据量才能往里面存放，数据量大了就给你的本地内存冲爆了。电脑会卡死去。
            //大数据量的话还得用SqlDataReader  
            DataSet ds = DbHelperSQL.Query(sql, pms);//执行sql语句，并利用DataSet将数据填充到本地内存中
            gvCommodity.DataSource = ds.Tables[0];//DataGridView获取ds中的数据
            gvCommodity.DataBind();

        }

        protected void buttonAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("CommodityAdd.aspx"); 
        }

        protected void dropDownListEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dCname = dropDownListEvents.SelectedValue;
            string sql1 = "SELECT CommodityID,CommodityName,SortName,commodityPrice,IsDiscount,ReducedPrice FROM dbo.Commodity INNER JOIN dbo.CommoditySort ON Commodity.SortID=CommoditySort.SortID where SortName = @SortName";
            SqlParameter[] pms1 = {
                                      new SqlParameter("@SortName",SqlDbType.NVarChar,50)
                                  };
            pms1[0].Value = dCname;
            DataSet da = DbHelperSQL.Query(sql1, pms1);
            gvCommodity.DataSource = da.Tables[0];
            gvCommodity.DataBind();

        }

        protected void butttonDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.gvCommodity.Rows.Count; i++)
            {
                


                string id = this.gvCommodity.Rows[i].Cells[0].Text;
                CheckBox cb = this.gvCommodity.Rows[i].FindControl("cbSelection") as CheckBox;
                if (cb.Checked)
                {
                    //此方法可获取hyperlinkfield里的文字：HyperLink data = (HyperLink)this.gvCommodity.Rows[i].Cells[1].Controls[0];
                    //如若想获取ItemTemplate下的hyperlink下绑定数据的文字，需要先进行text设置，获取的是绑定数据的文字
                    //获取主键
                    int key = Convert.ToInt32(gvCommodity.DataKeys[i].Values["CommodityID"]); 
                    string sql2 = "DELETE FROM dbo.Commodity WHERE CommodityID = @CommodityID";
                    SqlParameter[] pms2 ={
                                         new SqlParameter("@CommodityID",SqlDbType.Int)
                                      };
                    pms2[0].Value = key;
                    DbHelperSQL.ExecuteSql(sql2, pms2);
                    Response.Write("<script>alert('删除成功');</script>");
                    Response.Redirect("CommoditySort.aspx");
                }
            }
        }

        protected void buttonAdd_Click1(object sender, EventArgs e)
        {
            Response.Redirect("CommodityAdd.aspx");
        }

    }
}