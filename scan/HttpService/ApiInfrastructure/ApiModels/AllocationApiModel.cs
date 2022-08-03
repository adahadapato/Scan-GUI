using HttpService.ApiHelper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scan.HttpService.ApiInfrastructure.ApiModels
{
    public class AllocationApiModel : ApiModel
    {
        public string State { get; set; }
        public string Code { get; set; }
        public string Subject { get; set; }
        public int NumberOfSchools { get; set; }
        public int NumberOfCandidates { get; set; }
        public int NumberScanned { get; set; }
    }
}
