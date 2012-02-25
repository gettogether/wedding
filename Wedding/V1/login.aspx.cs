using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class V1_login : CommonLibrary.WebObject.TemplatePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["out"]))
        {
            Session.Abandon();
        }
//        Response.Write(CommonLibrary.Utility.NumberHelper.Rounding((decimal)(26 / 10), CommonLibrary.Utility.NumberHelper.RoundingTypes.Ceiling, 0).ToString());
    }
}
