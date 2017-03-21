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
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    buttonLogin.Attributes.Add("OnClick", "return login()");
            //}
        }

        protected void buttonLogin_Click(object sender, EventArgs e)
        {
            string user = textUserName.Text;
            string pass = textPassword.Text;
            string sql = "select * from Users where Username='" + user + "' and Password ='" + pass + "'";
            if (DbHelperSQL.GetSingle(sql) != null)
            {
                //为用户名设置缓存
                Session["user"] = user;
                Session["pass"] = pass;
                Response.Redirect("CommoditySort.aspx");
            }
            else
            {
                Response.Write("<script>alert('请填写正确信息');</script>");
            }
        }
    }
}