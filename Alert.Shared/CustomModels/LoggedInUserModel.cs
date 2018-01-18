using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alert.Shared.CustomModels
{
    public class LoggedInUserModel
    {
        public int ApplicationUserId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string Image { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Address { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string UserName { get; set; }
        
        public Nullable<int> UserIdentityKey { get; set; }
        public bool success { get; set; }
        public string ErrorMessage { get; set; }

    }
}
