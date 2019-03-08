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
    public partial class viewusers : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection con;
        static DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("login.aspx");
            }
            string str = "data source=.; database=RailwayManagement; integrated security=SSPI";
            con = new SqlConnection(str);
            cmd = new SqlCommand("select * from [user]", con);
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            GV.DataSource = dt;
            GV.DataBind();
        }
        protected void GV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GV.Rows[e.RowIndex];
            string x = row.Cells[1].Text;
            //int id = Convert.ToInt32(x);
            string str = "data source=.; database=RailwayManagement; integrated security=SSPI";
            con = new SqlConnection(str);
            cmd = new SqlCommand("delete from [user] where id='" + x + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("viewusers.aspx");
        }
    }
}
    