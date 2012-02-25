﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Date time = 2/18/2012 6:39:19 PM
//     This code was generated by tool,Version=2.0.1004.01.
//     Changes to this code may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Data;
using DataMapping;

namespace WeddingLibrary.Database.DataObject
{
    public class DO_BigDateJoin : DOBase<DO_BigDateJoin.UO_BigDateJoin, DO_BigDateJoin.UOList_BigDateJoin>
    {
        public enum Columns
        {
            Email,
            BigDateCode,
            BigDateName,
            BigDate,
        }
        public DO_BigDateJoin()
        {
            ConnInfo = new ConnectionInformation("select bdd.Email,bd.BigDateCode,BigDateName,bd.BigDate from BigDateDetail bdd left join BigDate bd on bdd.BigDateCode=bd.BigDateCode", Config.ConnectionKeys.Wedding, new string[] { "Email" });
            ConnInfo.IsSqlSentence = true;
        }
        public class UO_BigDateJoin : UOBase<UO_BigDateJoin, UOList_BigDateJoin>
        {
            #region Columns
            private System.String _Email;
            [Mapping("Email,un-insert,un-update")]
            public System.String Email
            {
                get
                {
                    return _Email;
                }
                set
                {
                    _Email = value;
                }
            }
            private System.String _BigDateCode;
            [Mapping("BigDateCode")]
            public System.String BigDateCode
            {
                get
                {
                    return _BigDateCode;
                }
                set
                {
                    _BigDateCode = value;
                }
            }
            private System.String _BigDateName;
            [Mapping("BigDateName")]
            public System.String BigDateName
            {
                get
                {
                    return _BigDateName;
                }
                set
                {
                    _BigDateName = value;
                }
            }
            private System.DateTime _BigDate;
            [Mapping("BigDate")]
            public System.DateTime BigDate
            {
                get
                {
                    return _BigDate;
                }
                set
                {
                    _BigDate = value;
                }
            }
            #endregion

            public UO_BigDateJoin()
            {
                ConnInfo = new DO_BigDateJoin().ConnInfo;
            }
        }
        public class UOList_BigDateJoin : CommonLibrary.ObjectBase.ListBase<UO_BigDateJoin>
        {
            public UOList_BigDateJoin()
            {
            }
        }
    }
}
