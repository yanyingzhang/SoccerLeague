/*
    This is the MatchSecheduling Page.
    User can select two clubs to create a match.
    This page also displays all the scheduled matches.
*/

using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MatchScheduling : System.Web.UI.Page
{
    // loading the theme of the page
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if ((String)Session["theme"] != null)
        {
            Page.Theme = (String)Session["theme"];
        }
        else
        {
            Page.Theme = "Light";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadHostClubs();
            LoadGuestClubs();
            LoadMatches();
        }
    }
    private void LoadMatches()
    {
        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;

        string connectionString = ConfigurationManager.ConnectionStrings["ClubCollectionDB"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand("select gameid,matchdate,hostClub,guestClub from MatchesList WHERE matchdate >=  GETDATE() ORDER BY matchdate", conn);
        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            gameListGrid.DataSource = reader;
            gameListGrid.DataBind();
            reader.Close();
        }
        catch
        {
            gamesList.Text = "Error loading mathches.";
        }
        finally
        {
            conn.Close();
        }
    }
    private void LoadHostClubs()
    {
        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;

        string connectionString = ConfigurationManager.ConnectionStrings["ClubCollectionDB"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand("select cname from ClubCollection", conn);

        try
        {
            conn.Open();

            reader = comm.ExecuteReader();
            hostTeam.DataSource = reader;
            hostTeam.DataValueField = "cname";
            hostTeam.DataTextField = "cname";
            hostTeam.DataBind();

            guestTeam.DataSource = reader;
            guestTeam.DataValueField = "cname";
            guestTeam.DataTextField = "cname";
            guestTeam.DataBind();

            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }
    private void LoadGuestClubs()
    {
        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;

        string connectionString = ConfigurationManager.ConnectionStrings["ClubCollectionDB"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand("select cname from ClubCollection", conn);

        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            guestTeam.DataSource = reader;
            guestTeam.DataValueField = "cname";
            guestTeam.DataTextField = "cname";
            guestTeam.DataBind();
            
            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }


    protected void scheduleCalendar_SelectionChanged(object sender, EventArgs e)
    {
        string dataString = scheduleCalendar.SelectedDate.ToShortDateString();
        timeLbl.Text = "You have selected " + dataString;
    }

    protected void scheduleBtn_Click(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.IsAuthenticated)
        {
            DateTime newDate = (scheduleCalendar.SelectedDate).Date;
            string newHost = hostTeam.SelectedValue.ToString();
            string newGuest = guestTeam.SelectedValue.ToString();

            DateTime todayDate = DateTime.Today;

            if (newHost != newGuest)
            {
                validateLbl.Visible = false;
                addNewMatch(newDate, newHost, newGuest);
            }
            else
            {
                validateLbl.Visible = true;
            }
        }else
        {
            Response.Redirect("Login.aspx");
        }
    }
    private void addNewMatch(DateTime newDate, string newHost, string newGuest)
    {
        SqlConnection conn;
        SqlCommand comm;

        string connectionString = ConfigurationManager.ConnectionStrings["ClubCollectionDB"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand("Insert into MatchesList (matchDate, hostClub, guestClub)" +
            "values (@matchDate,@hostClub,@guestClub)", conn);
        
        comm.Parameters.Add("@matchDate", SqlDbType.DateTime);
        comm.Parameters.Add("@hostClub", SqlDbType.Text);
        comm.Parameters.Add("@guestClub", SqlDbType.Text);
        
        comm.Parameters["@matchDate"].Value = newDate;
        comm.Parameters["@hostClub"].Value = newHost;
        comm.Parameters["@guestClub"].Value = newGuest;
        try
        {
            conn.Open();
            comm.ExecuteNonQuery();
        }
        catch
        {
            submitError.Text = "Error to submit matches.";
        }
        finally
        {
            conn.Close();
        }
        LoadMatches();
    }

    // this method limits the users to select the match date
    // user cannot select the date before today
    protected void scheduleCalendar_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.Date <= DateTime.Now)
        {
            e.Cell.BackColor = System.Drawing.Color.Gray;
            e.Day.IsSelectable = false;
        }
    }
}

/*
    COMP228 Assignment - Web Application Development
    Yanying Zhang - 300926213
*/
