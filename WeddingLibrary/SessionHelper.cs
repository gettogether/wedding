using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeddingLibrary.Database.DataObject;

namespace WeddingLibrary
{
    public class SessionHelper
    {
        public static SessionObject GetCurrentSession()
        {
            if (System.Web.HttpContext.Current != null)
                return System.Web.HttpContext.Current.Session[Definition.Session.SESSION_KEY] == null ? null : (SessionObject)System.Web.HttpContext.Current.Session[Definition.Session.SESSION_KEY];
            return null;
        }

        public static void SetSession(SessionObject sess)
        {
            if (System.Web.HttpContext.Current != null)
                System.Web.HttpContext.Current.Session[Definition.Session.SESSION_KEY] = sess;
        }

        public static SessionObject GetTestSession()
        {
            string email, pwd;
            email = "wedding-app@qq.com";
            pwd = "111111";
            SessionObject currentSession = new SessionObject();
            currentSession.Profile = new WeddingLibrary.Profiles.LoginProfile();
            currentSession.Profile.LoginUser = WeddingLibrary.Profiles.Imp.Login.GetLogin(email,pwd);
            DO_BigDateJoin.UOList_BigDateJoin bigDates = WeddingLibrary.Database.Imp.BigDate.GetListByEmail(email);
            if (bigDates.Count > 0)
            {
                WeddingLibrary.Profiles.Entities.UO_BigDate bigDate = new WeddingLibrary.Profiles.Entities.UO_BigDate();
                DataMapping.ObjectHelper.CopyAttributes<DO_BigDateJoin.UO_BigDateJoin, WeddingLibrary.Profiles.Entities.UO_BigDate>(bigDates[0], bigDate);
                currentSession.Profile.BigDate = bigDate;
            }
            return currentSession;
        }
    }
}
