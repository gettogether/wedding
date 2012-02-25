using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeddingLibrary.Web
{
    public class TemplateControl : CommonLibrary.WebObject.TemplateControl
    {
        public SessionObject CurrentSession
        {
            get
            {
                return SessionHelper.GetCurrentSession();
            }
        }
    }
}
