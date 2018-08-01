/*
    This is the SetUp page.
    This page is created to set the theme.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetTheme : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
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

    // change theme 
    protected void Button_Click(object sender, EventArgs e)
    {
        if (darkTheme.Checked)
        {
            Session["theme"] = "Dark";
        }
        if (lightTheme.Checked)
        {
            Session["theme"] = "Light";
        }
        Response.Redirect("Home.aspx");
    }
}

/*
    COMP228 Assignment - Web Application Development
    Yanying Zhang - 300926213
*/
