using System;
using System.Collections.Generic;
using System.Text;

namespace scan
{
    
    static class PaperCode
    {
        static string paperCode;
        public static string getPaperCode(string subject, string paper, string exam)
        {
            
            if (paper != "00")
            {
                paperCode = subject.Substring(0, 1);
                paperCode += paper.Trim();
                paperCode += subject.Substring(1, 1);
            }
            if (exam.Substring(0, 4) == "BECE")
            {
                paperCode = subject;
                paperCode += paper.Trim();

            }
            else
            {
                paperCode = subject;
            }


            return paperCode;
        }

    }
}
