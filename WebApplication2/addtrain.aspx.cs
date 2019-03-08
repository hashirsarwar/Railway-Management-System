using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class addtrain : System.Web.UI.Page
    {
        static string val;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!String.IsNullOrEmpty(Request.QueryString["success"]))
            {
                Response.Write("Done");
            }
            string str = "data source=.; database=RailwayManagement; integrated security=SSPI";
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("select id,pick_up+'-'+arrival as r from route", con);
            con.Open();
            DropDownList1.DataSource = cmd.ExecuteReader();
            
            DropDownList1.DataTextField = "r";
            DropDownList1.DataValueField = "id";
            DropDownList1.DataBind();
            con.Close();
            DropDownList1.Items.Insert(0, new ListItem("Select", "NA"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "data source=.; database=RailwayManagement; integrated security=SSPI";
            SqlConnection con = new SqlConnection(str);
            string command = "insert into train (train_number,availableseats,date_pickup,pickup_time,route_id) values(@t,@a,@d,@p,@r)";
            SqlCommand cmd = new SqlCommand(command,con);
            cmd.Parameters.AddWithValue("@t", TextBox1.Text);
            cmd.Parameters.AddWithValue("@a", TextBox2.Text);
            cmd.Parameters.AddWithValue("@d", TextBox3.Text);
            cmd.Parameters.AddWithValue("@p", TextBox4.Text);
            cmd.Parameters.AddWithValue("@r", val);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("~/addtrain.aspx?success=true");

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            val = DropDownList1.SelectedValue;
        }
    }
}