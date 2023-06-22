using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace APIcsharp.Classes
{
    public class HolidayDTO
    {
        public string Base { get; set; }

        public Dictionary<string, Dictionary<string, DateTime>> Days { get; set; }

        public HolidayDTO() {
            Base = string.Empty;
            Days = new Dictionary<string, Dictionary<string, DateTime> >{ };


        }
    }
}
