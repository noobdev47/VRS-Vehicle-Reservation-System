using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles_Reservation_System.Logic
{
    class Administrator
    {
        private string adminUname;
        private string adminName;
        private string adminPword;

        public Administrator(string uname, string name, string pword)
        {
            adminUname = uname;
            adminName = name;
            adminPword = pword;
        }

        public string getAdminUname()
        {
            return this.adminUname;
        }

        public string getAdminName()
        {
            return this.adminName;
        }

        public string getAdminPword()
        {
            return this.adminPword;
        }
    }
}
