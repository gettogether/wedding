using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeddingLibrary.Web
{
    public class TemplateCallbackPage : CommonLibrary.WebObject.TemplateCallbackPage
    {
        public SessionObject CurrentSession
        {
            get
            {
                return SessionHelper.GetCurrentSession();
            }
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (CurrentSession == null)
            {
                Response.Write("Timeout");
                Response.End();
            }
        }
    }
}
