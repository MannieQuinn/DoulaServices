using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoulaServices.Models
{
    public class DoulaDetail
    {
        public int DoulaId { get; set; }
        public string DoulaName { get; set; }
        public string DoulaLocation { get; set; }
        public bool VbacExp { get; set; }
        public bool AvailJan { get; set; }
        public bool AvailFeb { get; set; }
        public bool AvailMar { get; set; }
        public bool AvailApr { get; set; }
        public bool AvailMay { get; set; }
        public bool AvailJun { get; set; }
        public bool AvailJul { get; set; }
        public bool AvailAug { get; set; }
        public bool AvailSep { get; set; }
        public bool AvailOct { get; set; }
        public bool AvailNov { get; set; }
        public bool AvailDec { get; set; }
    }
}
