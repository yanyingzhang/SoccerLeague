/*
 * This is the ClubDetails Page
 * This display more details of the club.
 * This page also provide user method to detele the club from the database.
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


public partial class ClubDetails : System.Web.UI.Page
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
            Page.Theme = "Light";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadClubInfo();
            LoadPlayerList();
        }
    }
    //Load the Club Information
    private void LoadClubInfo()
    {
        string selectedClub = Request.QueryString["ClubName"];

        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;
        string connectionString = ConfigurationManager.ConnectionStrings["ClubCollectionDB"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand("Select cname, ccity, cnumber,caddress FROM ClubCollection where cname = @cname", conn);
        comm.Parameters.Add("@cname", SqlDbType.VarChar);
        comm.Parameters["@cname"].Value = selectedClub;
        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            clubDetailInfo.DataSource = reader;
            clubDetailInfo.DataBind();
            reader.Close();
        }
        catch
        {
            dbErrorLabel.Text = "Fail to load club data";
        }
        finally
        {
            conn.Close();
        }
    }

    // Load Player List 
    private void LoadPlayerList()
    {
        string selectedClub = Request.QueryString["ClubName"];
        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;
        string connectionString = ConfigurationManager.ConnectionStrings["ClubCollectionDB"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand("Select playerid, playername, birthday, jnumber FROM PlayerList where cname = @cname", conn);
        comm.Parameters.Add("@cname", SqlDbType.VarChar);
        comm.Parameters["@cname"].Value = selectedClub;
        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            playerGrid.DataKeyNames = new string[] { "playerid" };
            playerGrid.DataSource = reader;
            playerGrid.DataBind();
            reader.Close();
        }
        catch
        {
            dbErrorLabel.Text = "Fail to load player data";
        }
        finally
        {
            conn.Close();
        }
    }
    
    protected void playerGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadPlayer();
    }
    private void LoadPlayer()
    {
        int selectedRowIndex = playerGrid.SelectedIndex;
        int playerid = (int)playerGrid.DataKeys[selectedRowIndex].Value;
        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;
        string connectionString = ConfigurationManager.ConnectionStrings["ClubCollectionDB"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand("SELECT playerid, playername, birthday, jnumber FROM PlayerList WHERE playerid = @playerid", conn);

        comm.Parameters.Add("playerid", SqlDbType.Int);
        comm.Parameters["playerid"].Value = playerid;
        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            playDetail.DataSource = reader;
            playDetail.DataKeyNames = new string[] { "playerid" };
            playDetail.DataBind();
            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }
    
    // Delete the club from database
    protected void deleteClubBtn_Click(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.IsAuthenticated)
        {
            string selectedClub = Request.QueryString["ClubName"];
            SqlConnection conn;
            SqlCommand comm;
            string connectionString = ConfigurationManager.ConnectionStrings["ClubCollectionDB"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("delete from ClubCollection where cname = @cname", conn);
            comm.Parameters.Add("@cname", SqlDbType.VarChar);
            comm.Parameters["@cname"].Value = selectedClub;
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                clubDetailInfo.Visible = false;
                deleteLabel.Text = "You have delete the club " + selectedClub;
            }
            catch
            {
                dbErrorLabel.Text = "Error";
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

    protected void playDetail_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        if (HttpContext.Current.Request.IsAuthenticated)
        {
            playDetail.ChangeMode(e.NewMode);
        LoadPlayer();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void playDetail_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
            int playerid = (int)playDetail.DataKey.Value;
            TextBox newNameTextBox = (TextBox)playDetail.FindControl("editName");
            string newName = newNameTextBox.Text;
            TextBox newBirthdayTextBox = (TextBox)playDetail.FindControl("editBirthday");
            string newBirthday = newBirthdayTextBox.Text;
            TextBox newJNumTextBox = (TextBox)playDetail.FindControl("editJnumber");
            string newJnumber = newJNumTextBox.Text;

            SqlConnection conn;
            SqlCommand comm;
            string connectionString = ConfigurationManager.ConnectionStrings["ClubCollectionDB"].ConnectionString;
            conn = new SqlConnection(connectionString);
            comm = new SqlCommand("Update PlayerList set playername=@playername, birthday=@birthday, jnumber=@jnumber Where playerid=@playerid", conn);

            comm.Parameters.Add("playerid", SqlDbType.Int);
            comm.Parameters.Add("playername", SqlDbType.Text);
            comm.Parameters.Add("birthday", SqlDbType.Text);
            comm.Parameters.Add("jnumber", SqlDbType.Text);

            comm.Parameters["playerid"].Value = playerid;
            comm.Parameters["playername"].Value = newName;
            comm.Parameters["birthday"].Value = newBirthday;
            comm.Parameters["jnumber"].Value = newJnumber;
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                ErrorLbl.Text = "Information updated.";
            }
            catch
            {

                ErrorLbl.Text = "Error";
            }
            finally
            {
                conn.Close();
            }
            playDetail.ChangeMode(DetailsViewMode.ReadOnly);
            LoadClubInfo();
            LoadPlayerList();
    }

}

/*
    COMP228 Assignment - Web Application Development
    Yanying Zhang - 300926213
*/
