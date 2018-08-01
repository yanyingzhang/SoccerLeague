/*
    This is the Home Page.
    This page introduces soccers and also link to the SetUp Page.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
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

    }
}

/*
    COMP228 Assignment - Web Application Development
    Yanying Zhang - 300926213
*/
