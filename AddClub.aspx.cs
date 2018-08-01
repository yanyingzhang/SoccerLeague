/*
    This is the AddClub Page.
    This page is for the user to add clubs and players.
*/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddClub : System.Web.UI.Page
{
    // load the theme for the page
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if ((String)Session["theme"] != null)
        {
            Page.Theme = (String)Session["theme"];
        }
        else
        {
            Page.Theme = "Light"; // set the default theme as "Light".
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadClubList();
        }
    }
    

    
    protected void cancelBtn2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AddClub.aspx");
    }

    // Add a Club
    protected void saveBtn_Click(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.IsAuthenticated)
        {
            SqlConnection conn;
            SqlCommand comm;

            string connectionString = ConfigurationManager.ConnectionStrings["ClubCollectionDB"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("Insert into ClubCollection (cnumber,cname, ccity, caddress)" +
                "values (@cnumber,@cname,@ccity,@caddress)", conn);

            comm.Parameters.Add("@cnumber", SqlDbType.Int);
            comm.Parameters.Add("@cname", SqlDbType.Text);
            comm.Parameters.Add("@ccity", SqlDbType.Text);
            comm.Parameters.Add("@caddress", SqlDbType.Text);

            comm.Parameters["@cnumber"].Value = Convert.ToInt32(reginumtxt.Text);
            comm.Parameters["@cname"].Value = smart.clubName;
            comm.Parameters["@ccity"].Value = smart.clubCity;
            comm.Parameters["@caddress"].Value = addresstxt.Text;

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                LoadClubList();
                addClubLbl.Text = "The club has been saved successfully.";
            }
            catch
            {
                dbErrorMessage.Text = "Error submitting data.";
            }
            finally
            {
                conn.Close();
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void cancelBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AddClub.aspx");
    }

    private void LoadClubList()
    {
        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;

        string connectionString = ConfigurationManager.ConnectionStrings["ClubCollectionDB"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand("select cname from ClubCollection", conn);

        try { 
        conn.Open();
        reader = comm.ExecuteReader();
        selectClub.DataSource = reader;
        selectClub.DataValueField = "cname";
        selectClub.DataTextField = "cname";
        selectClub.DataBind();
        selectClub.SelectedValue = smart.clubName;
            reader.Close();
        }
        catch
        {
            dbErrorMessage.Text = "Error loading club lists.";
        }
        finally
        {
            conn.Close();
        }
    }

    // Add a player to the club
    protected void addPlayerBtn_Click(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.IsAuthenticated)
        {
            SqlConnection conn;
            SqlCommand comm;

            string connectionString = ConfigurationManager.ConnectionStrings["ClubCollectionDB"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("Insert into PlayerList (playername,cname, jnumber,birthday)" +
                "values (@playername,@cname,@jnumber,@birthday)", conn);

            comm.Parameters.Add("@playername", SqlDbType.Text);
            comm.Parameters.Add("@cname", SqlDbType.Text);
            comm.Parameters.Add("@jnumber", SqlDbType.Int);
            comm.Parameters.Add("@birthday", SqlDbType.Text);

            comm.Parameters["@playername"].Value = pnametxt.Text;
            comm.Parameters["@cname"].Value = selectClub.SelectedItem.Text;
            comm.Parameters["@jnumber"].Value = Convert.ToInt32(jnumtxt.Text);
            comm.Parameters["@birthday"].Value = bdtxt.Text;

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                playerlbl.Text = "Player information has been saved. Thank you!";
            }
            catch
            {
                playerlbl.Text = "Error submitting data.";
            }
            finally
            {
                conn.Close();
            }
        }else
        {
            Response.Redirect("Login.aspx");
        }
    }
}

/*
    COMP228 Assignment - Web Application Development
    Yanying Zhang - 300926213
*/
