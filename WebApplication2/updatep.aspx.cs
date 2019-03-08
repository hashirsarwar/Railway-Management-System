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
    public partial class updatep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!String.IsNullOrEmpty(Request.QueryString["unsuccess"]))
            {
                Response.Write("Invalid Password");
            }
            if (!String.IsNullOrEmpty(Request.QueryString["success"]))
            {
                Response.Write("Password updated successfully");
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            string str = "data source=.; database=RailwayManagement; integrated security=SSPI";
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("select [password] from [user] where username='" + Session["UserName"] + "'", con);
            sda.SelectCommand = cmd;
            sda.Fill(ds);
            string p = ds.Tables[0].Rows[0]["password"].ToString();
            if(p==TextBox1.Text)
            {
                cmd = new SqlCommand("changepass", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", Session["UserName"]);
                cmd.Parameters.AddWithValue("@oldpin", p);
                cmd.Parameters.AddWithValue("@newpin", TextBox2.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("~/updatep.aspx?success=true");
            }
            else
                Response.Redirect("~/updatep.aspx?unsuccess=true");
        }
    }
}