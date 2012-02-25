using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeddingLibrary.App
{
    public class Login
    {
        #region Columns
        private string _LoginEmail;
        public string LoginEmail
        {
            get
            {
                return _LoginEmail;
            }
            set
            {
                _LoginEmail = value;
            }
        }
        private int _LoginType;
        public int LoginType
        {
            get
            {
                return _LoginType;
            }
            set
            {
                _LoginType = value;
            }
        }
        private string _LoginFirstname;
        public string LoginFirstname
        {
            get
            {
                return _LoginFirstname;
            }
            set
            {
                _LoginFirstname = value;
            }
        }
        private string _LoginLastname;
        public string LoginLastname
        {
            get
            {
                return _LoginLastname;
            }
            set
            {
                _LoginLastname = value;
            }
        }
        private string _CroomName;
        public string CroomName
        {
            get
            {
                return _CroomName;
            }
            set
            {
                _CroomName = value;
            }
        }
        private string _BrideName;
        public string BrideName
        {
            get
            {
                return _BrideName;
            }
            set
            {
                _BrideName = value;
            }
        }

        #endregion
    }
}
