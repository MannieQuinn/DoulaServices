using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoulaServices.Data
{
    public class DoMo
    {
        public int DoMoId { get; set; }
        public Guid OwnerId { get; set; }
        public string DoulaName { get; set; }
        public string FirstName { get; set; }
        public string Notes { get; set; }
        public virtual Doula Doula { get; set; }
        public virtual Mother Mother { get; set; }
    }
}
