using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_btn_Click(object sender, EventArgs e)
        {
            if(login_uname.Text=="admin" && login_pass.Text=="12345")
            {
                Session["admin"] = "true";
                Response.Redirect("admin.aspx");
                
            }
            int status = 0;
            string cs = "data source=.; database=RailwayManagement; integrated security=SSPI";
            SqlConnection con = new SqlConnection(cs);

            try
            {               
                SqlCommand cmd = new SqlCommand("login", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", login_uname.Text);
                cmd.Parameters.AddWithValue("@password", login_pass.Text);
                cmd.Parameters.AddWithValue("@usertpye", "passenger");
                SqlParameter obj = new SqlParameter();
                obj.ParameterName = "@status";
                obj.SqlDbType = System.Data.SqlDbType.Int;
                obj.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(obj);
                con.Open();
                cmd.ExecuteNonQuery();
                status = Convert.ToInt32(cmd.Parameters["@status"].Value);

            }
            catch
            {
                Response.Write("Something went wrong");
            }
            finally
            {
                con.Close();
            }
            if (status==0)
            {
                Response.Write("Invalid login.");
            }
            else if(status==1)
            {
                Session["UserName"] = login_uname.Text;
                Response.Redirect("userPage.aspx");
            }
        }
    } 
}