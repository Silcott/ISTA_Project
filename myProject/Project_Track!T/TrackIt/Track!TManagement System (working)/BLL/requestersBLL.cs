using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackITManagementSystem.BLL
{
    class requestersBLL
    {
        public int ticket_id { get; set; }//use 'prop' trhen tab + tab for the property shortcut
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string ticket_creator_name { get; set; }
        public string phone { get; set; }
        public string location { get; set; }
        public string issue_category { get; set; }
        public string priority_level { get; set; }
        public string issue_decription { get; set; }
        public DateTime added_date { get; set; }
        public DateTime completed_date { get; set; }
        public SqlMoney cost { get; set; }
        public string file_name_path { get; set; }



    }
}
