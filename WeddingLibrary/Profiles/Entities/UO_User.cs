using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeddingLibrary.Profiles.Entities
{
    public class UO_User
    {
        public string LoginEmail { get; set; }
        public int LoginType { get; set; }
        public string LoginFirstname { get; set; }
        public string LoginLastname { get; set; }
        public string CroomName { get; set; }
        public string BrideName { get; set; }
    }
}
