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
    public partial class viewRes : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection con;
        static DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        SqlDataAdapter sda = new SqlDataAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("login.aspx");
            }
            string str = "data source=.; database=RailwayManagement; integrated security=SSPI";
            con = new SqlConnection(str);

            cmd = new SqlCommand("select id from [user] where username='" + Session["UserName"] + "'", con);
            ds.Clear();
            sda.SelectCommand = cmd;
            sda.Fill(ds);
            string d = ds.Tables[0].Rows[0]["id"].ToString();
            int userid = Convert.ToInt32(d);

            cmd = new SqlCommand("select * from reservation join Ticket_Type on reservation.Ticket_class =ticket_type.ID where issue_by='" + userid + "'", con);

            sda.SelectCommand = cmd;
            sda.Fill(dt);
            GV.DataSource = dt;
            GV.DataBind();

        }
    }
}