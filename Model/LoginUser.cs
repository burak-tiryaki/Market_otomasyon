using Market_otomasyon.Enumaration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_otomasyon.Model
{
    public class LoginUser
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string authority { get; set; }
        public string email { get; set; }
        public string securityQue { get; set; }
        public string securityAns { get; set; }
        public LoginStatus status { get; set; }
    }
}
