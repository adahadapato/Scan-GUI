using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace scan
{
    static class SubjectCodes
    {
        static string subjcode,maxscore="00";
        public static string getScanFileSubjCodes(string subject, string paper, string Job, string exam)
        {
            string msub = subject.Trim() + paper.Trim();
            try
            {
                string[] subj = Subjects.getSubjects(exam,Job );

                for (int i = 0; i < subj.Length; i++)
                {
                    if (subject == subj[i].Substring(42, subj[i].Length - 42) && Job == "Obj" && exam == "BECE")
                    {
                        if (subj[i].Substring(15, 1).Trim() == "0")
                        {
                            subjcode = "9" + subj[i].Substring(16, 1).Trim();
                            break;
                        }
                        else
                        {
                            subjcode = subj[i].Substring(15, 2).Trim();
                            break;
                        }
                        
                    }
                    if (subject == subj[i].Substring(42, subj[i].Length -42) && Job == "Obj" && exam == "SSCE")
                    {
                        subjcode = subj[i].Substring(14, 3).Trim();// +subj[i].Substring(16, 1).Trim(); 
                         
                        break;
                    }

                    if (subject == subj[i].Substring(42, subj[i].Length - 42) && Job == "Obj" && exam == "NCEE" || exam == "NEEF")
                    {
                        subjcode = subj[i].Substring(14, 1).Trim()+subj[i].Substring(16, 1).Trim(); 

                        break;
                    }
                    //MessageBox.Show(subject + " " + subj[i].Substring(42, subj[i].Length - 42)+" "+Job);
                    //Bece EMS subject codes
                    if (subject == subj[i].Substring(42, subj[i].Length - 42) && Job == "Essay" && exam=="BECE")
                    {
                        subjcode = subj[i].Substring(29, 12).Trim();
                        switch (paper)
                        {
                            case "1":
                                subjcode = subjcode.Substring(0, 2);
                                break;
                            case "2":
                                subjcode = subjcode.Substring(2, 2);
                                break;
                            case "3":
                                subjcode = subjcode.Substring(4, 2);
                                break;
                            case "4":
                                subjcode = subjcode.Substring(6, 2);
                                break;
                            case "5":
                                subjcode = subjcode.Substring(8, 2);
                                break;
                            case "6":
                                subjcode = subjcode.Substring(10, 2);
                                break;
                            default :
                                subjcode="pppp";
                                break ;
                        }
                        break;
                        
                    }
                    //SSCE EMS subject codes.
                    if (subject == subj[i].Substring(42, subj[i].Length - 42) && Job == "Essay" && exam == "SSCE")
                    {
                        subjcode = subj[i].Substring(29, 12).Trim();
                        maxscore = subj[i].Substring(42, 8).Trim();
                        switch (paper)
                        {
                            case "1":
                                subjcode = subjcode.Substring(0, 3);
                                maxscore = maxscore.Substring(0, 2);
                                break;
                            case "2":
                                subjcode = subjcode.Substring(3, 3);
                                maxscore = maxscore.Substring(2, 2);
                                break;
                            /*case "3":
                                subjcode = subjcode.Substring(5, 3);
                                break;*/
                            case "4":
                                subjcode = subjcode.Substring(9, 3);
                                maxscore = maxscore.Substring(6, 2);
                                break;
                            
                            default:
                                subjcode = "pppp";
                                maxscore = "00";
                                break;
                        }
                        break;

                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Scan Subject Code");
                subjcode = "pppp";
            }
            //MessageBox.Show(subjcode);
            return subjcode;
        }

        public static string getSubjCodes(string subject,string paper,string Job, string exam)
        {
            string msub = subject.Trim() + paper.Trim();
            try
            {
                string[] subj = Subjects.getSubjects(exam,Job );

                for (int i = 0; i < subj.Length; i++)
                {
                    string s = subj[i].Substring(42, subj[i].Length - 42).Trim();
                    if (subject == s)
                    {
                        subjcode = subj[i].Substring(14, 4).Trim();
                        break;
                    }
                    else
                    {
                        subjcode = "pppp";
                        
                    }
                }

          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Paper Code");
                subjcode = "pppp";
            }
            return subjcode;
        }
    }
}
