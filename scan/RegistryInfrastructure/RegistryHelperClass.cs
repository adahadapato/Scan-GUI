using System;


namespace scan.RegistryInfrastructure
{
    public class RegistryHelperClass
    {
        private readonly IRegistryMapper regMapper = new RegistryMapper();

         public string ApiToken
         {
             get { return regMapper.Getvalue("ApiToken").ToString(); }
             set { regMapper.Setvalue("ApiToken", value); }
         }
        public int TokenExpiryDate
        {
            get { return Convert.ToInt32(regMapper.Getvalue("TokenExpiryDate")); }
            set { regMapper.Setvalue("TokenExpiryDate", value.ToString()); }
        }

        public int TotalScanned
        {
            get { return Convert.ToInt32(regMapper.Getvalue("TotalScanned")); }
            set { regMapper.Setvalue("TotalScanned", value.ToString()); }
        }

        public string DeviceId
        {
            get { return regMapper.Getvalue("DeviceId").ToString(); }
            set { regMapper.Setvalue("DeviceId", value); }
        }
        //
        public string SosDir
        {
            get { return regMapper.Getvalue("sosDir").ToString(); }
            set { regMapper.Setvalue("sosDir", value); }
        }

        public bool StartBatch
        {
            get { return Convert.ToBoolean(regMapper.Getvalue("startBatch")); }
            set { regMapper.Setvalue("startBatch", value.ToString()); }
        }
        
        public string SOSInpBatchFileName
        {
            get { return regMapper.Getvalue("SOSInpBatchFileName").ToString(); }
            set { regMapper.Setvalue("SOSInpBatchFileName", value); }
        }
        public string ScanStatus
        {
            get { return regMapper.Getvalue("Status").ToString(); }
            set { regMapper.Setvalue("Status", value); }
        }
        public string ExamType
        {
            get { return regMapper.Getvalue("examType").ToString(); }
            set { regMapper.Setvalue("examType", value); }
        }

        public string Examination
        {
            get { return regMapper.Getvalue("examination").ToString(); }
            set { regMapper.Setvalue("examination", value); }
        }
        public string ExamYear
        {
            get { return regMapper.Getvalue("examYear").ToString(); }
            set { regMapper.Setvalue("examYear", value); }
        }
        //
        public int ExpectedSheets
        {
            get { return Convert.ToInt32(regMapper.Getvalue("ExpectedSheets").ToString()); }
            set { regMapper.Setvalue("ExpectedSheets", value.ToString()); }
        }
        public string Job
        {
            get { return regMapper.Getvalue("Job").ToString(); }
            set { regMapper.Setvalue("Job", value); }
        }
        public bool LogOut
        {
            get { return Convert.ToBoolean(regMapper.Getvalue("Logout")); }
            set { regMapper.Setvalue("Logout", value.ToString()); }
        }
        public string BatchNumber
        {
            get { return regMapper.Getvalue("batchnumber").ToString(); }
            set { regMapper.Setvalue("batchnumber", value); }
        }
        public string ScanType
        {
            get { return regMapper.Getvalue("ScanType").ToString(); }
            set { regMapper.Setvalue("ScanType", value); }
        }

        public string ScanDir
        {
            get { return regMapper.Getvalue("scanDir").ToString(); }
            set { regMapper.Setvalue("scanDir", value); }
        }
        public string Status
        {
            get { return regMapper.Getvalue("Status").ToString(); }
            set { regMapper.Setvalue("Status", value); }
        }
        //
        public bool IsBlind
        {
            get { return Convert.ToBoolean(regMapper.Getvalue("Blind")); }
            set
            {
                regMapper.Setvalue("Blind", value.ToString());
            }
        }
        public bool IsSuplementary
        {
            get { return Convert.ToBoolean(regMapper.Getvalue("Suplementary")); }
            set
            {
                regMapper.Setvalue("Suplementary", value.ToString());
            }
        }
        public bool IsResit
        {
            get { return Convert.ToBoolean(regMapper.Getvalue("resit")); }
            set
            {
                regMapper.Setvalue("resit", value.ToString());
            }
        }

        public bool IsBlank
        {
            get { return Convert.ToBoolean(regMapper.Getvalue("Blank")); }
            set
            {
                regMapper.Setvalue("Blank", value.ToString());
            }
        }
        public bool IsAdmin
        {
            get { return Convert.ToBoolean(regMapper.Getvalue("IsAdmin")); }
            set
            {
                regMapper.Setvalue("IsAdmin", value.ToString());
            }
        }
        
        public string UID
        {
            get { return regMapper.Getvalue("UID").ToString(); }
            set
            {
                regMapper.Setvalue("UID", value);
            }
        }
        //Blank
        public string ShortSubj
        {
            get { return regMapper.Getvalue("shortsubj").ToString(); }
            set { regMapper.Setvalue("shortsubj", value); }
        }
        public string Subject
        {
            get { return regMapper.Getvalue("subject").ToString(); }
            set { regMapper.Setvalue("subject", value); }
        }

        public string SubjCode
        {
            get { return regMapper.Getvalue("SubjCode").ToString(); }
            set { regMapper.Setvalue("SubjCode", value); }
        }
        public string State
        {
            get { return regMapper.Getvalue("state").ToString(); }
            set { regMapper.Setvalue("state", value); }
        }

        public string StateCode
        {
            get { return regMapper.Getvalue("stateCode").ToString(); }
            set { regMapper.Setvalue("stateCode", value); }
        }
        public string OperatorId
        {
            get { return regMapper.Getvalue("OperatorId").ToString(); }
            set { regMapper.Setvalue("OperatorId", value); }
        }

        public int AnswerSheet
        {
            get { return Convert.ToInt32(regMapper.Getvalue("AnswerSheet").ToString()); }
            set { regMapper.Setvalue("AnswerSheet", value.ToString()); }
        }
        //paper
        public string Paper
        {
            get { return regMapper.Getvalue("paper").ToString(); }
            set { regMapper.Setvalue("paper", value); }
        }
        public string LastDecodeLoaded
        {
            get { return regMapper.GetvalueEx("LastDecodeLoaded").ToString(); }
            set { regMapper.SetvalueEx("LastDecodeLoaded", value); }
        }
    }
}
