﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Date time = 2/11/2012 5:00:12 PM
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
    public class DO_Decoration : DOBase<DO_Decoration.UO_Decoration, DO_Decoration.UOList_Decoration>
    {
        public enum Columns
        {
            /// <summary>
            ///Primary Key,Database Type:varchar,Max Length:50,Is Nullable:NO
            /// </summary>
            DecorationCode,
            /// <summary>
            ///Database Type:varchar,Max Length:50,Is Nullable:NO
            /// </summary>
            BigDateCode,
            /// <summary>
            ///Database Type:varchar,Max Length:50,Is Nullable:NO
            /// </summary>
            DecorationCatCode,
            /// <summary>
            ///Database Type:nvarchar,Max Length:100,Is Nullable:NO
            /// </summary>
            DecorationName,
            /// <summary>
            ///Database Type:int,Is Nullable:NO
            /// </summary>
            DecorationNum,
            /// <summary>
            ///Database Type:int,Is Nullable:YES
            /// </summary>
            DecorationLeft,
            /// <summary>
            ///Database Type:int,Is Nullable:YES
            /// </summary>
            DecorationTop,
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
        public DO_Decoration()
        {
            ConnInfo = new ConnectionInformation("Decoration", Config.ConnectionKeys.Wedding, new string[] { "DecorationCode" });
        }
        public class UO_Decoration : UOBase<UO_Decoration, UOList_Decoration>
        {
            #region Columns
            private string _DecorationCode;
            /// <summary>
            ///Primary Key,Database Type:varchar,Max Length:50,Is Nullable:NO
            /// </summary>
            [Mapping("DecorationCode,un-insert,un-update")]
            public string DecorationCode
            {
                get
                {
                    return _DecorationCode;
                }
                set
                {
                    _DecorationCode = value;
                }
            }
            private string _BigDateCode;
            /// <summary>
            ///Database Type:varchar,Max Length:50,Is Nullable:NO
            /// </summary>
            [Mapping("BigDateCode")]
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
            private string _DecorationCatCode;
            /// <summary>
            ///Database Type:varchar,Max Length:50,Is Nullable:NO
            /// </summary>
            [Mapping("DecorationCatCode")]
            public string DecorationCatCode
            {
                get
                {
                    return _DecorationCatCode;
                }
                set
                {
                    _DecorationCatCode = value;
                }
            }
            private string _DecorationName;
            /// <summary>
            ///Database Type:nvarchar,Max Length:100,Is Nullable:NO
            /// </summary>
            [Mapping("DecorationName")]
            public string DecorationName
            {
                get
                {
                    return _DecorationName;
                }
                set
                {
                    _DecorationName = value;
                }
            }
            private int _DecorationNum;
            /// <summary>
            ///Database Type:int,Is Nullable:NO
            /// </summary>
            [Mapping("DecorationNum")]
            public int DecorationNum
            {
                get
                {
                    return _DecorationNum;
                }
                set
                {
                    _DecorationNum = value;
                }
            }
            private int _DecorationLeft;
            /// <summary>
            ///Database Type:int,Is Nullable:YES
            /// </summary>
            [Mapping("DecorationLeft")]
            public int DecorationLeft
            {
                get
                {
                    return _DecorationLeft;
                }
                set
                {
                    _DecorationLeft = value;
                }
            }
            private int _DecorationTop;
            /// <summary>
            ///Database Type:int,Is Nullable:YES
            /// </summary>
            [Mapping("DecorationTop")]
            public int DecorationTop
            {
                get
                {
                    return _DecorationTop;
                }
                set
                {
                    _DecorationTop = value;
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

            public UO_Decoration()
            {
                ConnInfo = new DO_Decoration().ConnInfo;
            }
        }
        public class UOList_Decoration : CommonLibrary.ObjectBase.ListBase<UO_Decoration>
        {
            public UOList_Decoration()
            {
            }
        }
    }
}
