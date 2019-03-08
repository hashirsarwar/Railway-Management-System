using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace WebApplication2
{
    public partial class addroute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
                Response.Redirect("login.aspx");
            if (!String.IsNullOrEmpty(Request.QueryString["success"]))
            {
                Response.Write("Done");
            }
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            string x = tb1.Text;
            string y = tb2.Text;
            string str = "data source=.; database=RailwayManagement; integrated security=SSPI";
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("insert into route (pick_up,arrival) values ('" + x + "','" + y + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("~/addroute.aspx?success=true");
        }
    }
}