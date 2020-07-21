using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackITManagementSystem.BLL
{
    class userBLL
    {
        public int user_id { get; set; }//get is a read only accessor and set is a write only accessor
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string full_name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public DateTime added_date { get; set; }
        public string image_name { get; set; }
    }
}
