using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Supermarket
{
    public partial class CommodityAdd : System.Web.UI.Page
    {
        private int cId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.AllKeys.Contains("cid"))
            {
                cId = int.Parse(Request.QueryString["cid"]);
            }
            if (cId > 0)
            {
                Response.Write("<script>alert('这是带参数的跳转');</script>");
            }
            else
            {
                Response.Write("<script>alert('这是不带参数的跳转');</script>");
            }

        }
    }
}