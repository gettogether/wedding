using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeddingLibrary.Database.DataObject;

namespace WeddingLibrary.Database.Imp
{
    public class Schedule
    {
        public static int GetRecordCountByBigDateCode(string bigDateCode)
        {
            DataAccess.ParameterCollection conditions = new DataAccess.ParameterCollection();
            conditions.AddCondition(DataAccess.ParameterType.Initial, DataAccess.TokenTypes.Equal, DO_Schedule.Columns.BigDateCode, bigDateCode);
            return new DO_Schedule().GetRecordsCount(conditions);
        }


        public static DO_Schedule.UO_Schedule GetObjectByBigDateCodeAndScheduleCode(string bigDateCode, string scheduleCode)
        {
            DataAccess.ParameterCollection conditions = new DataAccess.ParameterCollection();
            conditions.AddCondition(DataAccess.ParameterType.Initial, DataAccess.TokenTypes.Equal, DO_Schedule.Columns.BigDateCode, bigDateCode);
            conditions.AddCondition(DataAccess.ParameterType.And, DataAccess.TokenTypes.Equal, DO_Schedule.Columns.ScheduleCode, scheduleCode);
            DO_Schedule.UOList_Schedule l = new DO_Schedule().GetList(conditions);
            return l.Count > 0 ? l[0] : null;
        }
    }
}
