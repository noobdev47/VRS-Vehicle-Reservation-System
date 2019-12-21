using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles_Reservation_System.Logic
{
    class Boss
    {
        private string managerUname;
        private string managerName;
        private string managerPword;

        public Boss(string uname, string name, string pword)
        {
            managerUname = uname;
            managerName = name;
            managerPword = pword;
        }

        public string getManagerUname()
        {
            return this.managerUname;
        }

        public string getManagerName()
        {
            return this.managerName;
        }

        public string getManagerPword()
        {
            return this.managerPword;
        }
    }
}
