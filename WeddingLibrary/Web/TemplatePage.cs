using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeddingLibrary.Web
{
    public class TemplatePage : CommonLibrary.WebObject.TemplatePage
    {
        public SessionObject CurrentSession
        {
            get
            {
                return SessionHelper.GetCurrentSession();
            }
        }

        protected override void OnPreLoad(EventArgs e)
        {
            base.OnPreLoad(e);
            if (CurrentSession == null)
            {
                Response.Redirect("~/V1/Login.aspx");
            }
        }
    }
}
