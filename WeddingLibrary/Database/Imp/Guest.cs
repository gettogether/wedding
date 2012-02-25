using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeddingLibrary.Database.DataObject;
using WeddingLibrary.Database.BusinessObject;

namespace WeddingLibrary.Database.Imp
{
    public class Guest
    {
        public static int GetRecordCountByBigDateCode(string bigDateCode)
        {
            DataAccess.ParameterCollection conditions = new DataAccess.ParameterCollection();
            conditions.AddCondition(DataAccess.ParameterType.Initial, DataAccess.TokenTypes.Equal, DO_Guest.Columns.BigDateCode, bigDateCode);
            return new DO_Guest().GetRecordsCount(conditions);
        }

        public static bool DeleteByBigDateCodeAndGuestCodes(string bigDateCode, string[] guestCodes, string updateBy)
        {
            DataAccess.ParameterCollection conditions = new DataAccess.ParameterCollection();
            conditions.AddCondition(DataAccess.ParameterType.Initial, DataAccess.TokenTypes.Equal, DO_Guest.Columns.BigDateCode, bigDateCode);
            conditions.AddCondition(DataAccess.ParameterType.And, DataAccess.TokenTypes.In, DO_Guest.Columns.GuestCode, guestCodes);

            DataAccess.ParameterCollection values = new DataAccess.ParameterCollection();
            values.AddValue(DO_Guest.Columns.IsDeleted, 1);
            values.AddValue(DO_Guest.Columns.UpdateBy, updateBy);
            values.AddValue(DO_Guest.Columns.UpdateOn, DataAccess.DateTimeValues.DbTime);
            return new DO_Guest().Update(values, conditions) > 0;
        }

        public static DO_Guest.UO_Guest GetObjectByBigDateCodeAndGuestCode(string bigDateCode, string guestCode)
        {
            DataAccess.ParameterCollection conditions = new DataAccess.ParameterCollection();
            conditions.AddCondition(DataAccess.ParameterType.Initial, DataAccess.TokenTypes.Equal, DO_Guest.Columns.BigDateCode, bigDateCode);
            conditions.AddCondition(DataAccess.ParameterType.And, DataAccess.TokenTypes.Equal, DO_Guest.Columns.GuestCode, guestCode);
            DO_Guest.UOList_Guest l = new DO_Guest().GetList(conditions);
            return l.Count > 0 ? l[0] : null;
        }
    }
}
