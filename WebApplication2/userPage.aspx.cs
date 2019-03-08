using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication2
{
    public partial class userPage : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"]==null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                if (!String.IsNullOrEmpty(Request.QueryString["Rsuccess"]))
                {
                    Response.Write("Seat reserved successfully");
                }
                string cs = "data source=.; database=RailwayManagement; integrated security=SSPI";
                SqlConnection con = new SqlConnection(cs);
                cmd.CommandText = "select * from [user] where username='" + Session["UserName"] + "'";
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                sda.Fill(ds);
                lb.Text = ds.Tables[0].Rows[0]["fname"].ToString() + " " + ds.Tables[0].Rows[0]["lname"].ToString();
            }
        }

        protected void addR_Click(object sender, EventArgs e)
        {
            Response.Redirect("reserve.aspx");
        }

        protected void viewR_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewRes.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["UserName"] = null;
            Response.Redirect("login.aspx");
        }

        protected void del_Click(object sender, EventArgs e)
        {
            Response.Redirect("delRes.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("updatep.aspx");
        }
    }
}