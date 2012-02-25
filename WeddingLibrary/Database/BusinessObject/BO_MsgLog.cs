﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataAccess;
using DataAccess.Data;
using DataMapping;
using WeddingLibrary.Database.DataObject;

namespace WeddingLibrary.Database.BusinessObject
{
    public class BO_MsgLog
    {
        #region This source code was auto-generated by tool,Version=2.0.1004.01

        //------------------------------------------------------------------------------
        // <auto-generated>
        //     Date time = 2/11/2012 5:03:55 PM
        //     This code was generated by tool,Version=2.0.1004.01.
        //     Changes to this code may cause incorrect behavior and will be lost if
        //     the code is regenerated.
        // </auto-generated>
        //------------------------------------------------------------------------------

        #region Condition functions
        ///<summary>
        ///Get conditions by primary key.
        ///</summary>
        public static ParameterCollection GetConditionsByPrimaryKey(string MsgCode, string BigDateCode)
        {
            ParameterCollection primaryConditions = new ParameterCollection();
            primaryConditions.AddCondition(ParameterType.Initial, TokenTypes.Equal, DO_MsgLog.Columns.MsgCode, MsgCode);
            primaryConditions.AddCondition(ParameterType.And, TokenTypes.Equal, DO_MsgLog.Columns.BigDateCode, BigDateCode);
            return primaryConditions;
        }

        ///<summary>
        ///Get the tokenType of the column of condition query.
        ///</summary>
        private static TokenTypes GetColumnTokenType(TokenTypes defaultTokenType, DO_MsgLog.Columns column, Dictionary<DO_MsgLog.Columns, TokenTypes> extTokens)
        {
            if (extTokens != null && extTokens.ContainsKey(column))
                return extTokens[column];
            else
                return defaultTokenType;
        }

        ///<summary>
        ///Get conditions by object with Multi-TokenType.
        ///</summary>
        public static ParameterCollection GetConditionsByObject(DO_MsgLog.UO_MsgLog parameterObj, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_MsgLog.Columns, TokenTypes> extTokens)
        {
            ParameterCollection objectConditions = new ParameterCollection();
            TokenTypes tt = tokenTypes;
            ParameterType pt = isAnd ? ParameterType.And : ParameterType.Or;
            if (!string.IsNullOrEmpty(parameterObj.MsgCode))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_MsgLog.Columns.MsgCode, extTokens), DO_MsgLog.Columns.MsgCode, parameterObj.MsgCode);
            }
            if (!string.IsNullOrEmpty(parameterObj.BigDateCode))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_MsgLog.Columns.BigDateCode, extTokens), DO_MsgLog.Columns.BigDateCode, parameterObj.BigDateCode);
            }
            if (!string.IsNullOrEmpty(parameterObj.MsgTemplateCode))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_MsgLog.Columns.MsgTemplateCode, extTokens), DO_MsgLog.Columns.MsgTemplateCode, parameterObj.MsgTemplateCode);
            }
            if (!string.IsNullOrEmpty(parameterObj.ReplyMsgCode))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_MsgLog.Columns.ReplyMsgCode, extTokens), DO_MsgLog.Columns.ReplyMsgCode, parameterObj.ReplyMsgCode);
            }
            if (!string.IsNullOrEmpty(parameterObj.GuesetCode))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_MsgLog.Columns.GuesetCode, extTokens), DO_MsgLog.Columns.GuesetCode, parameterObj.GuesetCode);
            }
            if (!string.IsNullOrEmpty(parameterObj.MsgSubject))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_MsgLog.Columns.MsgSubject, extTokens), DO_MsgLog.Columns.MsgSubject, parameterObj.MsgSubject);
            }
            if (!string.IsNullOrEmpty(parameterObj.MsgContent))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_MsgLog.Columns.MsgContent, extTokens), DO_MsgLog.Columns.MsgContent, parameterObj.MsgContent);
            }
            if (parameterObj.CreateOn != DateTime.MinValue)
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_MsgLog.Columns.CreateOn, extTokens), DO_MsgLog.Columns.CreateOn, parameterObj.CreateOn);
            }
            if (!string.IsNullOrEmpty(parameterObj.CreateBy))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_MsgLog.Columns.CreateBy, extTokens), DO_MsgLog.Columns.CreateBy, parameterObj.CreateBy);
            }
            if (parameterObj.UpdateOn != DateTime.MinValue)
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_MsgLog.Columns.UpdateOn, extTokens), DO_MsgLog.Columns.UpdateOn, parameterObj.UpdateOn);
            }
            if (!string.IsNullOrEmpty(parameterObj.UpdateBy))
            {
                objectConditions.AddCondition(pt, GetColumnTokenType(tt, DO_MsgLog.Columns.UpdateBy, extTokens), DO_MsgLog.Columns.UpdateBy, parameterObj.UpdateBy);
            }
            return objectConditions;
        }
        #endregion

        #region Query functions

        ///<summary>
        ///Get all records.
        ///</summary>
        public static DO_MsgLog.UOList_MsgLog GetAllList()
        {
            DO_MsgLog da = new DO_MsgLog();
            return da.GetAllList();
        }

        ///<summary>
        ///Get all records count.
        ///</summary>
        public static int GetAllRecordsCount()
        {
            DO_MsgLog da = new DO_MsgLog();
            return da.GetRecordsCount();
        }

        ///<summary>
        ///Get records count.
        ///</summary>
        public static int GetRecordsCount(DO_MsgLog.UO_MsgLog parameterObj)
        {
            return GetRecordsCount(parameterObj, true, TokenTypes.Equal, null);
        }

        ///<summary>
        ///Get records count.
        ///</summary>
        public static int GetRecordsCount(DO_MsgLog.UO_MsgLog parameterObj, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_MsgLog.Columns, TokenTypes> extTokens)
        {
            DO_MsgLog da = new DO_MsgLog();
            return da.GetRecordsCount(GetConditionsByObject(parameterObj, isAnd, tokenTypes, extTokens));
        }

        ///<summary>
        ///Get list by object.
        ///</summary>
        public static DO_MsgLog.UOList_MsgLog GetList(DO_MsgLog.UO_MsgLog parameterObj, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_MsgLog.Columns, TokenTypes> extTokens)
        {
            return parameterObj.GetList(GetConditionsByObject(parameterObj, isAnd, tokenTypes, extTokens));
        }

        ///<summary>
        ///Get list by object.
        ///</summary>
        public static DO_MsgLog.UOList_MsgLog GetList(DO_MsgLog.UO_MsgLog parameterObj)
        {
            return GetList(parameterObj, true, TokenTypes.Equal, null);
        }

        ///<summary>
        ///Get object by primary key.
        ///</summary>
        public static DO_MsgLog.UO_MsgLog GetObject(string MsgCode, string BigDateCode)
        {
            DO_MsgLog da = new DO_MsgLog();
            DO_MsgLog.UOList_MsgLog l = da.GetList(GetConditionsByPrimaryKey(MsgCode, BigDateCode));
            return l.Count > 0 ? l[0] : null;
        }

        ///<summary>
        ///Get paging list.
        ///</summary>
        public static PagingResult<DO_MsgLog.UO_MsgLog, DO_MsgLog.UOList_MsgLog> GetPagingList(DO_MsgLog.UO_MsgLog parameterObj, int pageNumber, int pageSize, string sortBy, bool isAsc, bool isAnd, TokenTypes tokenTypes, Dictionary<DO_MsgLog.Columns, TokenTypes> extTokens)
        {
            return parameterObj.GetPagingList(GetConditionsByObject(parameterObj, isAnd, tokenTypes, extTokens), pageNumber, pageSize, sortBy, isAsc);
        }

        ///<summary>
        ///Get paging list.
        ///</summary>
        public static PagingResult<DO_MsgLog.UO_MsgLog, DO_MsgLog.UOList_MsgLog> GetPagingList(DO_MsgLog.UO_MsgLog parameterObj, int pageNumber, int pageSize, string sortBy, bool isAsc)
        {
            return parameterObj.GetPagingList(GetConditionsByObject(parameterObj, true, TokenTypes.Like, null), pageNumber, pageSize, sortBy, isAsc);
        }
        #endregion

        #region Update functions
        ///<summary>
        ///Update object by primary key.
        ///</summary>
        public static bool UpdateObject(DO_MsgLog.UO_MsgLog obj, string MsgCode, string BigDateCode)
        {
            return obj.Update(GetConditionsByPrimaryKey(MsgCode, BigDateCode)) > 0;
        }

        ///<summary>
        ///Update object by primary key(with transation).
        ///</summary>
        public static bool UpdateObject(DO_MsgLog.UO_MsgLog obj, string MsgCode, string BigDateCode, IDbConnection connection, IDbTransaction transaction)
        {
            return obj.Update(connection, transaction, GetConditionsByPrimaryKey(MsgCode, BigDateCode)) > 0;
        }
        #endregion

        #region Delete functions
        ///<summary>
        ///Delete object by primary key.
        ///</summary>
        public static int Delete(string MsgCode, string BigDateCode)
        {
            DO_MsgLog da = new DO_MsgLog();
            return da.Delete(GetConditionsByPrimaryKey(MsgCode, BigDateCode));
        }

        ///<summary>
        ///Delete object by primary key(with transation).
        ///</summary>
        public static int Delete(string MsgCode, string BigDateCode, IDbConnection connection, IDbTransaction transaction)
        {
            DO_MsgLog da = new DO_MsgLog();
            return da.Delete(connection, transaction, GetConditionsByPrimaryKey(MsgCode, BigDateCode));
        }
        #endregion

        #endregion

        #region User extensions

        #endregion
    }
}