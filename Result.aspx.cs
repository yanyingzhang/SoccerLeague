using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Result : System.Web.UI.Page
{
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
            LoadGameResult();
        }
    }

    private void LoadGameResult()
    {
        SqlConnection conn = null;
        SqlDataAdapter adapter;
        DataSet dataSet = new DataSet();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ClubCollectionDB"].ConnectionString;
                conn = new SqlConnection(connectionString);
                gameGrid.DataKeyNames = new string[] { "gameid" };
                adapter = new SqlDataAdapter("select gameid,matchdate,hostClub,result,guestClub from MatchesList WHERE matchdate <  GETDATE()", conn);
                adapter.Fill(dataSet, "MatchesList");
            }
            catch (Exception e)
            {
                msgLbl.Text = e.Message;
            }
            ViewState["MatchesListDataSet"] = dataSet;

        string sortExpression;
        if (gridSortDirection == SortDirection.Ascending)
        {
            sortExpression = gridSortExpression + " ASC"; //need space before ASC
        }
        else
        {
            sortExpression = gridSortExpression + " DESC"; // need space before DESC
        }
        dataSet.Tables["MatchesList"].DefaultView.Sort = sortExpression;
        gameGrid.DataSource = dataSet.Tables["MatchesList"].DefaultView;
        gameGrid.DataBind();
    }
    private SortDirection gridSortDirection
    {
        get
        {
            if (ViewState["GridSortDirection"] == null)
            {
                ViewState["GridSortDirection"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["GridSortDirection"];
        }
        set
        {
            ViewState["GridSortDirection"] = value;
        }
    }
    private string gridSortExpression
    {
        get
        {
            if (ViewState["GridSortExpression"] == null)
            {
                ViewState["GridSortExpression"] = "matchdate";
            }
            return (string)ViewState["GridSortExpression"];
        }
        set
        {
            ViewState["GridSortExpression"] = value;
        }
    }
    protected void gameGrid_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;
        if (sortExpression == gridSortExpression)
        {
            if (gridSortDirection == SortDirection.Ascending)
            {
                gridSortDirection = SortDirection.Descending;
            }
            else
            {
                gridSortDirection = SortDirection.Ascending;
            }
        }
        else
        {
            gridSortDirection = SortDirection.Ascending;
        }
        gridSortExpression = sortExpression;
        LoadGameResult();
    }

    protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDetail();
    }

    private void BindDetail()
    {
        int selectedRowIndex = gameGrid.SelectedIndex;
        int gameid = (int)gameGrid.DataKeys[selectedRowIndex].Value;
        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader reader;
        string connectionString = ConfigurationManager.ConnectionStrings["ClubCollectionDB"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand("SELECT gameid, matchdate, hostClub, result, guestClub from MatchesList where gameid=@gameid", conn);

        comm.Parameters.Add("gameid", SqlDbType.Int);
        comm.Parameters["gameid"].Value = gameid;
        try
        {
            conn.Open();
            reader = comm.ExecuteReader();
            gameDetail.DataSource = reader;
            gameDetail.DataKeyNames = new string[] { "gameid" };
            gameDetail.DataBind();
            reader.Close();
        }
        finally
        {
            conn.Close();
        }
    }

    protected void DetailsView_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        if (HttpContext.Current.Request.IsAuthenticated)
        {
            gameDetail.ChangeMode(e.NewMode);
            BindDetail();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void DetailsView_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        int gameid = (int)gameDetail.DataKey.Value;
        TextBox resultTextBox = (TextBox)gameDetail.FindControl("editResultTB");
        string result = resultTextBox.Text;
        SqlConnection conn;
        SqlCommand comm;
        string connectionString = ConfigurationManager.ConnectionStrings["ClubCollectionDB"].ConnectionString;
        conn = new SqlConnection(connectionString);
        comm = new SqlCommand("Update MatchesList set result=@result Where gameid=@gameid", conn);

        comm.Parameters.Add("gameid", SqlDbType.Int);
        comm.Parameters.Add("result", SqlDbType.Text);
        comm.Parameters["gameid"].Value = gameid;
        comm.Parameters["result"].Value = result;
        try
        {
            conn.Open();
            comm.ExecuteNonQuery();
            msgLbl.Text = "Information updated.";
        }
        catch
        {

            msgLbl.Text = "Error";
        }
        finally
        {
            conn.Close();
        }
        //gameDetail.ChangeMode(DetailsViewMode.ReadOnly);
        LoadGameResult();
    }
    
}