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
using System.Xml.Linq;

public partial class V1_Components_Guest_GuestEdit : WeddingLibrary.Web.TemplateControl
{
    public WeddingLibrary.Database.DataObject.DO_Guest.UO_Guest Guest { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Guest == null) Guest = new WeddingLibrary.Database.DataObject.DO_Guest.UO_Guest();
    }
}
