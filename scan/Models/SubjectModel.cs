using System;
using System.Collections.Generic;
using System.Text;

namespace scan.Models
{
    public class RemoteInventory
    {
        public string FileName { get; set; }
        public int Records { get; set; }
        public string SystemNo { get; set; }
        public bool IsDiscard { get; set; }
    }

    public class RemoteSubject
    {
        public string code { get; set; }//code
        public string subj_code { get; set; }//subject_code
        public string subject { get; set; }//subject
        public string descript { get; set; }//descript
        public List<string> paper { get; set; }//paper
    }
    public class SubjectModel
    {
        public string subj_code { get; set; }
        public string code { get; set; }
        public string subject { get; set; }
        public string descript { get; set; }
        public List<string> paper { get; set; }
        public string exam { get; set; }
    }

    public class SubjectsModel
    {
        public List<SubjectModel> Objective { get; set; }
        public List<SubjectModel> Essay { get; set; }

    }

   
   

    
   
}
