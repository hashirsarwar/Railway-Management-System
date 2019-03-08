using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class delRes : System.Web.UI.Page
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
        protected void GV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GV.Rows[e.RowIndex];
            string x = row.Cells[1].Text;
            int id = Convert.ToInt32(x);
            string str = "data source=.; database=RailwayManagement; integrated security=SSPI";
            con = new SqlConnection(str);


            SqlCommand cmd = new SqlCommand("cancelreservation", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            SqlParameter obj = new SqlParameter();
            obj.ParameterName = "@result";
            obj.SqlDbType = System.Data.SqlDbType.Int;
            obj.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(obj);
            con.Open();
            cmd.ExecuteNonQuery();
            int result = Convert.ToInt32(cmd.Parameters["@result"].Value);
            con.Close();

            dt.Clear();
            Response.Redirect("delRes.aspx");
        }
    }
}