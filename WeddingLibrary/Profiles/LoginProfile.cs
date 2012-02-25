using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeddingLibrary.Profiles
{
    public class LoginProfile
    {
        public Entities.UO_User LoginUser { get; set; }
        public Entities.UO_BigDate BigDate { get; set; }
    }
}
