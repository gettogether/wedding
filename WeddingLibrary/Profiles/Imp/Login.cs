using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeddingLibrary.Database.DataObject;
using WeddingLibrary.Database.BusinessObject;

namespace WeddingLibrary.Profiles.Imp
{
    public class Login
    {
        public static Profiles.Entities.UO_User GetLogin(string email, string password)
        {
            string pwdEncrypt = Functions.Common.DesEncrypt(password);
            DO_Login.UO_Login uoLogin= Database.BusinessObject.BO_Login.GetObjectByEamilAndPassword(email, pwdEncrypt);
            if (uoLogin != null)
            {
                Profiles.Entities.UO_User ret = new WeddingLibrary.Profiles.Entities.UO_User();
                DataMapping.ObjectHelper.CopyAttributes<DO_Login.UO_Login, Profiles.Entities.UO_User>(uoLogin, ret);
                return ret;
            }
            return null;
        }
    }
}
