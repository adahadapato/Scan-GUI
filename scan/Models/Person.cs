using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scan.Models
{
    public class StaffDetails
    {
        public string personnelNo { get; set; }
        public string name { get; set; }
        public string status { get; set; }
    }
    /*public class Person
    {
        public string username { get; set; }
        public bool status { get; set; }
        public string name { get; set; }
        public List<string> roles { get; set; }
        public bool isAdmin { get; set; }
        public string personnelNo { get; set; }
    }*/

    public class Person
    {
        //public bool isAdmin { get; set; }
        public string personnelNo { get; set; }
        public string name { get; set; }
        public string examType { get; set; }
        public string examYear { get; set; }
        public string job { get; set; }
        public string scanType { get; set; }
        public bool isBlind { get; set; }
        public bool isResit { get; set; }
        public bool isSuplementary { get; set; }
        public int expectedSheets { get; set; }
        public string systemType { get; set; }
        public string examination { get; set; }
        public string access_token { get; set; }
        public bool IsChangePassword { get; set; }
    }
}
