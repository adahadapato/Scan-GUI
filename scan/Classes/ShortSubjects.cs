using System;
using System.Collections.Generic;
using System.Text;

namespace scan
{
    static class ShortSubjects
    {
        static string shortsubj;
        public static string getShortSubject(string subject, string exam, string Job)
        {
            string[] subj = Subjects.getSubjects(exam,Job);
            for (int i = 0; i < subj.Length; i++)
            {
                if (subject == subj[i].Substring(42, subj[i].Length - 42))
                {
                    shortsubj = subj[i].Substring(20, 7).Trim() ;
                    break;
                }
            }

            return shortsubj;
        }
    }
}
