using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["success"]))
            {
                Response.Write("Account created successfully");
            }
        }

        protected void Btn_Click(object sender, EventArgs e)
        {
            string cs = "data source=.; database=RailwayManagement; integrated security=SSPI";
            SqlConnection con = new SqlConnection(cs);
            int x = 0;
            string command = "insert into [user] (username,[Password],fname,lname,Age,Gender,Phone_no,CNIC,userType) values (@u,@p,@f,@l,@a,@g,@ph,@c,'passenger')";
            try
            {
                
                SqlCommand cmd = new SqlCommand(command, con);
                cmd.Parameters.AddWithValue("@u", uname.Text);
                cmd.Parameters.AddWithValue("@f", fname.Text);
                cmd.Parameters.AddWithValue("@l", lname.Text);
                cmd.Parameters.AddWithValue("@p", pass.Text);
                cmd.Parameters.AddWithValue("@a", age.Text);
                cmd.Parameters.AddWithValue("@g", gender.SelectedItem.Value.ToString());
                cmd.Parameters.AddWithValue("@ph", phone.Text);
                cmd.Parameters.AddWithValue("@c", cnic.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                x = 1;
                Response.Write("Unable to create account. Some info might be invalid");
            }
            finally
            {
                con.Close();
            }
            if(x==0)
            {
                Response.Redirect("~/signup.aspx?success=true");
            }

        }
    }
}