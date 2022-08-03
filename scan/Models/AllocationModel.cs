using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scan.Models
{
    public class AllocationModel
    {
        public string State { get; set; }
        public string Code { get; set; }
        public string Subject { get; set; }
        public int NumberOfSchools { get; set; }
        public int NumberOfCandidates { get; set; }
        public int NumberScanned { get; set; }
    }
}
