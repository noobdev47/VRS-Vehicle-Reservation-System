using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles_Reservation_System.Logic
{
    class EntryOp
    {
        private string entryOpUname;
        private string entryOpName;
        private string entryOpPword;

        public EntryOp(string uname, string name, string pword)
        {
            entryOpUname = uname;
            entryOpName = name;
            entryOpPword = pword;
        }

        public string getEntryOpUname()
        {
            return this.entryOpUname;
        }

        public string getEntryOpName()
        {
            return this.entryOpName;
        }

        public string getEntryOpPword()
        {
            return this.entryOpPword;
        }
    }
}
