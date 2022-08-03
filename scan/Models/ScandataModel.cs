using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scan.Models
{
    public class ScanDataApiModel
    {
        public string ExamYear { get; set; }
        public string OperatorId { get; set; }
        public string ScanType { get; set; }
        public string ScanFile { get; set; }
        public string JobDir { get; set; }
        public string ExamType { get; set; }
        public string Job { get; set; }
        public string SystemNo { get; set; }
        public string Subject { get; set; }
        public List<string> Responses { get; set; }
    }

    public class ScanData
    {
        public string ReferenceNo { get; set; }
        public string CandidateNo { get; set; }
        public string SchoolNo { get; set; }
        public string Subject { get; set; }
        public string SerialNo { get; set; }
        public string Response { get; set; }
        public string FileNo { get; set; }
        public string UserId { get; set; }
        public string DeviceId { get; set; }
        public DateTime Date { get; set; }
    }
}
