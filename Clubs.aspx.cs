/*
    This is the Clubs Page.
    This page display all the clubs from database.
    User can also see more details about the club information.
    This page link to the ClubDetails Page.
*/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Clubs : System.Web.UI.Page
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
    private object sqlDbType;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindList();
        }
    }

    protected void BindList()
    {
        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;
        string connectionString = ConfigurationManager.ConnectionStrings["ClubCollectionDB"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand("Select cname, ccity FROM ClubCollection", conn);
        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            clubGrid.DataSource = reader;
            clubGrid.DataBind();
            reader.Close();
        }
        catch
        {
            dbErrorLabel.Text = "Fail to load data";
        }
        finally
        {
            conn.Close();
        }
    }

        protected void clubGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedRowIndex = clubGrid.SelectedIndex;
        GridViewRow row = clubGrid.Rows[selectedRowIndex];
        string selectedClubName = row.Cells[0].Text;
        Response.Redirect("ClubDetails.aspx?ClubName=" + selectedClubName);
    }
}

/*
    COMP228 Assignment - Web Application Development
    Yanying Zhang - 300926213
*/
