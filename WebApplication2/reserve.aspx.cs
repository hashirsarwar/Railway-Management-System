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
    public partial class reserve : System.Web.UI.Page
    {
        static string date, pickup, arrival, pickuptime,ticketclass;
        static int seatR;
        static string str = "data source=.; database=RailwayManagement; integrated security=SSPI";
        SqlConnection con = new SqlConnection(str);
        SqlDataAdapter sda = new SqlDataAdapter();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            date = DropDownList2.SelectedValue;
            cmd = new SqlCommand("select pick_up from [route] join train on [route].id = train.route_id where date_pickup='" + date + "'", con);
            con.Open();
            DropDownList4.DataSource = cmd.ExecuteReader();
            DropDownList4.DataTextField = "pick_up";
            DropDownList4.DataValueField = "pick_up";
            DropDownList4.DataBind();
            con.Close();
            DropDownList4.Items.Insert(0, new ListItem("Select", "NA"));
        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            arrival = DropDownList5.SelectedValue;
            cmd = new SqlCommand("select pickup_time from [route] join train on [route].id = train.route_id where date_pickup='" + date + "' and pick_up='" + pickup + "' and arrival='" + arrival + "'", con);
            con.Open();
            DropDownList3.DataSource = cmd.ExecuteReader();
            DropDownList3.DataTextField = "pickup_time";
            DropDownList3.DataValueField = "pickup_time";
            DropDownList3.DataBind();
            con.Close();
            DropDownList3.Items.Insert(0, new ListItem("Select", "NA"));
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            pickuptime = DropDownList3.SelectedValue;
            cmd = new SqlCommand("select availableseats from [route] join train on [route].id = train.route_id where date_pickup = '" + date + "' and pick_up = '" + pickup + "' and arrival = '" + arrival + "' and pickup_time = '" + pickuptime + "'", con);
            ds.Clear();
            sda.SelectCommand = cmd;
            sda.Fill(ds);
            string x = ds.Tables[0].Rows[0]["availableseats"].ToString();
            int seats = Convert.ToInt32(x);

            cmd = new SqlCommand("select seat_no from reservation", con);
            ds.Clear();
            sda.SelectCommand = cmd;
            sda.Fill(ds);
            int s = ds.Tables[0].Select("seat_no is not null").Length;
            int count = 1;
            int m = 0;
            DropDownList1.Items.Insert(0, new ListItem("Select", "NA"));

            for (int a = 1; a < seats + 1; a++)
            {

                for (int i = 0; i < s; i++)
                {
                    if (a == Convert.ToInt32(ds.Tables[0].Rows[i]["seat_no"].ToString()))
                    {
                        m = 1;
                        seats++;
                    }
                }
                if (m != 1)
                {
                    DropDownList1.Items.Insert(count, new ListItem(a.ToString(), a.ToString()));
                    count++;
                }
                m = 0;

            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            seatR = Convert.ToInt32(DropDownList1.SelectedItem.Text);
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            pickup = DropDownList4.SelectedValue;
            cmd = new SqlCommand("select arrival from [route] join train on [route].id = train.route_id where date_pickup='" + date + "' and pick_up='" + pickup + "'", con);
            con.Open();
            DropDownList5.DataSource = cmd.ExecuteReader();
            DropDownList5.DataTextField = "arrival";
            DropDownList5.DataValueField = "arrival";
            DropDownList5.DataBind();
            con.Close();
            DropDownList5.Items.Insert(0, new ListItem("Select", "NA"));
        }

        protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ticketclass = DropDownList.SelectedValue;
            cmd = new SqlCommand("select date_pickup from train", con);
            con.Open();
            DropDownList2.DataSource = cmd.ExecuteReader();
            DropDownList2.DataTextField = "date_pickup";
            DropDownList2.DataValueField = "date_pickup";
            DropDownList2.DataTextFormatString = "{0:dd-MM-yyyy}";
            DropDownList2.DataBind();
            con.Close();
            DropDownList2.Items.Insert(0, new ListItem("Select", "NA"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("login.aspx");
            }
            
            else
            {
                
                if (!String.IsNullOrEmpty(Request.QueryString["err"]))
                {
                    Response.Write("Enter all fields");
                }
                SqlCommand cmd = new SqlCommand("select * from ticket_type", con);
                con.Open();
                DropDownList.DataSource = cmd.ExecuteReader();
                DropDownList.DataTextField = "title";
                DropDownList.DataValueField = "id";
                DropDownList.DataBind();
                con.Close();
                DropDownList.Items.Insert(0, new ListItem("Select", "NA"));
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (arrival==null || pickup==null||pickuptime==null ||seatR==0||date==null)
            {
                Response.Redirect("~/reserve.aspx?err=true");
            }
            SqlCommand cmd = new SqlCommand("select t.id as train_id from train t join [route] r on r.ID=t.Route_ID where r.Arrival='"+arrival+"' and r.pick_up='"+pickup+"' and t.date_pickup='"+date+"' and pickup_time='"+pickuptime+"'",con);
            ds.Clear();
            sda.SelectCommand = cmd;
            sda.Fill(ds);
            string d = ds.Tables[0].Rows[0]["train_id"].ToString();
            int trainid = Convert.ToInt32(d);

            cmd = new SqlCommand("select id from [user] where username='"+Session["UserName"]+"'", con);
            ds.Clear();
            sda.SelectCommand = cmd;
            sda.Fill(ds);
            d = ds.Tables[0].Rows[0]["id"].ToString();
            int userid = Convert.ToInt32(d);

            cmd = new SqlCommand("reserveseat", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ticket_class", ticketclass);
            cmd.Parameters.AddWithValue("@train_id", trainid);
            cmd.Parameters.AddWithValue("@issue_by", userid);
            cmd.Parameters.AddWithValue("@seat_no", seatR);

            SqlParameter obj = new SqlParameter();
            obj.ParameterName = "@result";
            obj.SqlDbType = System.Data.SqlDbType.Int;
            obj.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(obj);
            con.Open();
            cmd.ExecuteNonQuery();
            int result = Convert.ToInt32(cmd.Parameters["@result"].Value);

            if (result==1)
            {
                Response.Redirect("~/userPage.aspx?Rsuccess=true");
            }
        }
    }
}