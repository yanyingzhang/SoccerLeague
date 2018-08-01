using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddItem : System.Web.UI.UserControl
{
    public string clubName
    {
        get
        {
            return cnametxt.Text;
        }
        set
        {
            cnametxt.Text = value;
        }
    }
    public string clubCity
    {
        get
        {
            return citytxt.Text;
        }
        set
        {
            citytxt.Text = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}