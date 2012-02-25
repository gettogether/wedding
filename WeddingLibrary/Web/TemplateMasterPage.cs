using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeddingLibrary.Web
{
    public class TemplateMasterPage : CommonLibrary.WebObject.TemplateMasterPage
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
