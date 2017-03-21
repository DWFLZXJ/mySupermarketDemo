using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using RL.DBUtility;

namespace Supermarket
{
    public partial class CommodityAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowMyInfo();
            }

        }
        private void ShowMyInfo(){
            string str;
            try
            {
                str = Request.QueryString["name"].ToString();
            }
            catch
            {
                str = "0";
            }

           //string str = Request.QueryString["name"].ToString();
                
            
            if (str != "0")
                {
                    string sql = "select CommodityName,SortID,CommodityPrice,IsDiscount,ReducedPrice from Commodity where CommodityName = @CommodityName";
                    SqlParameter[] pms = {
                                  new SqlParameter("@CommodityName",SqlDbType.VarChar,50),
                                  };
                    pms[0].Value = str;//为参数赋值
                    DataSet ds = DbHelperSQL.Query(sql, pms);//执行sql语句，并利用DataSet将数据填充到本地内存中
                    textCommodityName.Text = Convert.ToString(ds.Tables[0].Rows[0][0]);
                    textPrice.Text = Convert.ToString(ds.Tables[0].Rows[0][2]);
                    textReducePrice.Text = Convert.ToString(ds.Tables[0].Rows[0][4]);
                    cbIsDiscount.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0][3]);

                    int sortID = Convert.ToInt32(ds.Tables[0].Rows[0][1]);
                    string sql1 = "select SortName from CommoditySort where SortID = @SortID";
                    SqlParameter[] pms1 = {
                                  new SqlParameter("@SortID",SqlDbType.Int),
                                  };
                    pms1[0].Value = sortID;//为参数赋值
                    DataSet ds1 = DbHelperSQL.Query(sql1, pms1);
                    DropDownListEvent.SelectedValue = Convert.ToString(ds1.Tables[0].Rows[0][0]);
                }
                else
                { }
            }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string name = textCommodityName.Text;
            decimal price = Convert.ToDecimal(textPrice.Text);
            if (textReducePrice.Text == "")
            {
                textReducePrice.Text = textPrice.Text;
            }
            decimal reducePrice = Convert.ToDecimal(textReducePrice.Text);
            //获取SortID
            string selection = DropDownListEvent.SelectedValue;
            string sql1 = "select SortID from CommoditySort where SortName = @selection";
            SqlParameter[] pms1 = {
                                  new SqlParameter("@selection",SqlDbType.NVarChar,50),
                                  };
            pms1[0].Value = selection;//为参数赋值
            DataSet ds = DbHelperSQL.Query(sql1, pms1);
            int sortID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            //获取是否打折
            bool isDicount = cbIsDiscount.Checked;
            //根据传过来的参数选择用哪种方式更改数据
            //通过session获取userID
            int UserID;
            if (Session["user"] != null)
            {
                string sqlUserID = "select UserID from Users where UserName = @UserName";
                SqlParameter[] pmsUserID = {
                                  new SqlParameter("@UserName",SqlDbType.NVarChar,50),
                                  };
                pms1[0].Value = Session["user"];//为参数赋值
                DataSet dsUserID = DbHelperSQL.Query(sqlUserID, pmsUserID);
                UserID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            else
            {
                UserID = 1;
            }
            string str;
            try
            {
                str = Request.QueryString["name"].ToString();
            }
            catch
            {
                str = "0";
            }
            //保存功能
            if (str == "0")
            {
                
                //判断输入的名称是否相同，如果不相同则进行保存(未实现)
                    //sql语句，插入操作
                    string sql = "INSERT INTO Commodity(CommodityName,SortID,CommodityPrice,IsDiscount,ReducedPrice,CreateUserId)" +
                    "VALUES(@CommodityName,@SortID,@CommodityPrice,@IsDiscount,@ReducedPrice,@CreateUserId)";
                    SqlParameter[] pms = { 
                                    new SqlParameter("@CommodityName",SqlDbType.NVarChar,50),
                                    new SqlParameter("@SortID",SqlDbType.Int),
                                    new SqlParameter("@CommodityPrice",SqlDbType.Decimal),
                                    new SqlParameter("@IsDiscount",SqlDbType.Bit),
                                    new SqlParameter("@ReducedPrice",SqlDbType.Decimal),
                                    new SqlParameter("@CreateUserId",SqlDbType.Int)
                                 };//创建参数
                    pms[0].Value = name;//为参数赋值
                    pms[1].Value = sortID;//为参数赋值
                    pms[2].Value = price;//为参数赋值
                    pms[3].Value = isDicount;//为参数赋值
                    pms[4].Value = reducePrice;//为参数赋值
                    pms[5].Value = UserID;
                    DbHelperSQL.ExecuteSql(sql, pms);
                    Response.Redirect("CommoditySort.aspx");
                }  
           //更新功能
            else
            {
                string sqlUpdate = "UPDATE Commodity SET CommodityName = @CommodityName,SortID = @SortID,CommodityPrice = @CommodityPrice,IsDiscount = @IsDiscount," +
                                   "ReducedPrice = @ReducedPrice WHERE CommodityName = @str ";
                SqlParameter[] pms = { 
                                    new SqlParameter("@CommodityName",SqlDbType.NVarChar,50),
                                    new SqlParameter("@SortID",SqlDbType.Int),
                                    new SqlParameter("@CommodityPrice",SqlDbType.Decimal),
                                    new SqlParameter("@IsDiscount",SqlDbType.Bit),
                                    new SqlParameter("@ReducedPrice",SqlDbType.Decimal),
                                    new SqlParameter("@str",SqlDbType.VarChar,50)
                                 };//创建参数
                pms[0].Value = name;//为参数赋值
                pms[1].Value = sortID;//为参数赋值
                pms[2].Value = price;//为参数赋值
                pms[3].Value = isDicount;//为参数赋值
                pms[4].Value = reducePrice;//为参数赋值
                pms[5].Value = str;//为参数赋值
                DbHelperSQL.ExecuteSql(sqlUpdate, pms);
                Response.Redirect("CommoditySort.aspx");
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("CommoditySort.aspx"); 
        }

     
    }
}