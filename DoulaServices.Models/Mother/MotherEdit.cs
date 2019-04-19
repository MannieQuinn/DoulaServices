using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoulaServices.Models
{
    public class MotherEdit
    {
        public int MotherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MotherLocation { get; set; }
        public DateTime DueDate { get; set; }
        public bool BreastFeeding { get; set; }
    }
}
