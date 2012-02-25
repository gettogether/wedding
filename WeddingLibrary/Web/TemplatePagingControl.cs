using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeddingLibrary.Web
{
    public class TemplatePagingControl : TemplateControl
    {
        #region Attributes

        private int _pageindex = 1;
        public int PageIndex
        {
            get { return _pageindex; }
            set { _pageindex = value; }
        }
        private int _pagesize = 5;
        public int PageSize
        {
            get { return _pagesize; }
            set { _pagesize = value; }
        }
        private bool _IsAsc = false;
        public bool IsAsc
        {
            get { return _IsAsc; }
            set { _IsAsc = value; }
        }
        private string _Sort = "";
        public string Sort
        {
            get { return _Sort; }
            set { _Sort = value; }
        }

        private int _Total;

        public int Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        private string _JsFunction;

        public string JsFunction
        {
            get { return _JsFunction; }
            set { _JsFunction = value; }
        }

        private object _BindingResult;

        public object BindingResult
        {
            get { return _BindingResult; }
            set { _BindingResult = value; }
        }



        #endregion

        #region Functions
        public string ShowPaging(int buttonCount, string pageUrl, string javascript)
        {
            return CommonLibrary.WebObject.Paging.GetPagingString(buttonCount, PageIndex, PageSize, Total, pageUrl, javascript);
        }

        public string ShowPaging(string pageUrl, string javascript)
        {
            return CommonLibrary.WebObject.Paging.GetPagingString(5, PageIndex, PageSize, Total, pageUrl, javascript);
        }

        public string ShowPaging(string pageUrl)
        {
            return CommonLibrary.WebObject.Paging.GetPagingString(5, PageIndex, PageSize, Total, pageUrl, "");
        }

        public string GetSortHeader(string title, string sortBy, string javascript)
        {
            return CommonLibrary.WebObject.HtmlHelper.GetSortHeader(javascript, title, sortBy, IsAsc, Sort);
        }
        public string ShowPaging()
        {
            return ShowPaging("", JsFunction + "({0}," + PageSize + ",'" + Sort + "'," + (!IsAsc ? "false" : "true") + ")");
        }
        public string GetSortHeader(string title, string sortBy)
        {
            return GetSortHeader(title, sortBy, JsFunction + "(1," + PageSize + ",'" + sortBy + "'," + (IsAsc ? "false" : "true") + ")");
        }

        public string GenPageSize(string id)
        {
            return CommonLibrary.WebObject.HtmlHelper.GenPageSize(id, "select", PageSize, JsFunction + "(1,{0})");
        }

        public string GenPageSize()
        {
            return CommonLibrary.WebObject.HtmlHelper.GenPageSize("sPageSize", "select", PageSize, JsFunction + "(1,{0})");
        }

        public void SetData<T, C>(DataAccess.Data.Interfaces.IPagingResult<T, C> result)
        {
            this.BindingResult = result.Result;
            this.Total = result.Total;
        }
        public void SetData<T, C>(C c)
            where T : class, new()
            where C : ICollection<T>, new()
        {
            this.BindingResult = c;
            this.Total = c.Count;
        }
        public void SetData<T>(CommonLibrary.ObjectBase.ListBase<T> list)
            where T : class, new()
        {
            this.BindingResult = list;
            this.Total = list.Count;
        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            //if (Total == 0)
            //{
            //    Response.Clear();
            //    Response.Write(CommonLibrary.Resources.Resource.RcdNotFnd);
            //    Response.End();
            //}
            base.OnLoad(e);
        }
    }
}
