﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Date time = 2/11/2012 5:06:29 PM
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
    public class DO_Title : DOBase<DO_Title.UO_Title, DO_Title.UOList_Title>
    {
        public enum Columns
        {
            /// <summary>
            ///Primary Key,Database Type:varchar,Max Length:50,Is Nullable:NO
            /// </summary>
            BigDateCode,
            /// <summary>
            ///Primary Key,Database Type:varchar,Max Length:50,Is Nullable:NO
            /// </summary>
            TitleCode,
            /// <summary>
            ///Database Type:nvarchar,Max Length:100,Is Nullable:NO
            /// </summary>
            TitleName,
            /// <summary>
            ///Database Type:datetime,Is Nullable:NO,Default Value:(getdate())
            /// </summary>
            CreateOn,
            /// <summary>
            ///Database Type:varchar,Max Length:100,Is Nullable:NO
            /// </summary>
            CreateBy,
            /// <summary>
            ///Database Type:datetime,Is Nullable:YES
            /// </summary>
            UpdateOn,
            /// <summary>
            ///Database Type:varchar,Max Length:100,Is Nullable:YES
            /// </summary>
            UpdateBy,
        }
        public DO_Title()
        {
            ConnInfo = new ConnectionInformation("Title", Config.ConnectionKeys.Wedding, new string[] { "BigDateCode", "TitleCode" });
        }
        public class UO_Title : UOBase<UO_Title, UOList_Title>
        {
            #region Columns
            private string _BigDateCode;
            /// <summary>
            ///Primary Key,Database Type:varchar,Max Length:50,Is Nullable:NO
            /// </summary>
            [Mapping("BigDateCode,un-insert,un-update")]
            public string BigDateCode
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
            private string _TitleCode;
            /// <summary>
            ///Primary Key,Database Type:varchar,Max Length:50,Is Nullable:NO
            /// </summary>
            [Mapping("TitleCode,un-insert,un-update")]
            public string TitleCode
            {
                get
                {
                    return _TitleCode;
                }
                set
                {
                    _TitleCode = value;
                }
            }
            private string _TitleName;
            /// <summary>
            ///Database Type:nvarchar,Max Length:100,Is Nullable:NO
            /// </summary>
            [Mapping("TitleName")]
            public string TitleName
            {
                get
                {
                    return _TitleName;
                }
                set
                {
                    _TitleName = value;
                }
            }
            private DateTime _CreateOn;
            /// <summary>
            ///Database Type:datetime,Is Nullable:NO,Default Value:(getdate())
            /// </summary>
            [Mapping("CreateOn,un-insert,un-update")]
            public DateTime CreateOn
            {
                get
                {
                    return _CreateOn;
                }
                set
                {
                    _CreateOn = value;
                }
            }
            private string _CreateBy;
            /// <summary>
            ///Database Type:varchar,Max Length:100,Is Nullable:NO
            /// </summary>
            [Mapping("CreateBy,un-update")]
            public string CreateBy
            {
                get
                {
                    return _CreateBy;
                }
                set
                {
                    _CreateBy = value;
                }
            }
            private DateTime _UpdateOn;
            /// <summary>
            ///Database Type:datetime,Is Nullable:YES
            /// </summary>
            [Mapping("UpdateOn,un-insert")]
            public DateTime UpdateOn
            {
                get
                {
                    return _UpdateOn;
                }
                set
                {
                    _UpdateOn = value;
                }
            }
            private string _UpdateBy;
            /// <summary>
            ///Database Type:varchar,Max Length:100,Is Nullable:YES
            /// </summary>
            [Mapping("UpdateBy,un-insert")]
            public string UpdateBy
            {
                get
                {
                    return _UpdateBy;
                }
                set
                {
                    _UpdateBy = value;
                }
            }
            #endregion

            public UO_Title()
            {
                ConnInfo = new DO_Title().ConnInfo;
            }
        }
        public class UOList_Title : CommonLibrary.ObjectBase.ListBase<UO_Title>
        {
            public UOList_Title()
            {
            }
        }
    }
}
