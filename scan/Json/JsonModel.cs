//using Newtonsoft.Json;
using scan.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace scan.Json
{
   public class JsonModel
    {
       /* public static List<SubjectModel> CreateBeceSubjects(string filename)
        {
            string Json = LoadJson(filename);
            var model = JsonConvert.DeserializeObject<List<SubjectModel>>(Json);
            return model;
        }*/
       
        public static string LoadJson(string filename)
        {
            using (StreamReader r = new StreamReader(filename))
            {
                string json = r.ReadToEnd();
                return json;
            }
        }
    }
}
