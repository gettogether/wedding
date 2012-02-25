﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Date time = 2/11/2012 5:00:55 PM
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
    public class DO_DecorationCat : DOBase<DO_DecorationCat.UO_DecorationCat, DO_DecorationCat.UOList_DecorationCat>
    {
        public enum Columns
        {
            /// <summary>
            ///Database Type:nvarchar,Max Length:50,Is Nullable:NO
            /// </summary>
            DecorationCatName,
            /// <summary>
            ///Database Type:varchar,Max Length:50,Is Nullable:NO
            /// </summary>
            DecorationCatCode,
            /// <summary>
            ///Database Type:int,Is Nullable:NO,Remark:0=Table,1=Pillar
            /// </summary>
            DecorationCatType,
        }
        public DO_DecorationCat()
        {
            ConnInfo = new ConnectionInformation("DecorationCat", Config.ConnectionKeys.Wedding);
        }
        public class UO_DecorationCat : UOBase<UO_DecorationCat, UOList_DecorationCat>
        {
            #region Columns
            private string _DecorationCatName;
            /// <summary>
            ///Database Type:nvarchar,Max Length:50,Is Nullable:NO
            /// </summary>
            [Mapping("DecorationCatName")]
            public string DecorationCatName
            {
                get
                {
                    return _DecorationCatName;
                }
                set
                {
                    _DecorationCatName = value;
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
            private int _DecorationCatType;
            /// <summary>
            ///Database Type:int,Is Nullable:NO,Remark:0=Table,1=Pillar
            /// </summary>
            [Mapping("DecorationCatType")]
            public int DecorationCatType
            {
                get
                {
                    return _DecorationCatType;
                }
                set
                {
                    _DecorationCatType = value;
                }
            }
            #endregion

            public UO_DecorationCat()
            {
                ConnInfo = new DO_DecorationCat().ConnInfo;
            }
        }
        public class UOList_DecorationCat : CommonLibrary.ObjectBase.ListBase<UO_DecorationCat>
        {
            public UOList_DecorationCat()
            {
            }
        }
    }
}