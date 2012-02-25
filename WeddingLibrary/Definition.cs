using System;
using System.Collections.Generic;
using System.Text;

namespace WeddingLibrary
{
    public class Definition
    {
        public Definition()
        {

        }

        public class Cache
        {
            public const string ERROR_DESCRIPTION_KEY = "Wedding-Error-Description";
        }

        public class Session
        {
            public const string SESSION_KEY = "Wedding-Session";
        }

        public class Database
        {
            public enum Columns
            {
                BigDateCode
            }
        }
    }

}