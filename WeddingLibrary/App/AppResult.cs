using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeddingLibrary.App
{
    public class AppResult<T>
    {
        public string Error { get; set; }
        public T Result { get; set; }

        public AppResult(T t, string error)
        {
            this.Result = t;
            this.Error = error;
        }


        public AppResult(string error)
        {
            this.Error = error;
        }

        public static string GetResult(string error)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new AppResult<string>(error));
        }
    }
}
