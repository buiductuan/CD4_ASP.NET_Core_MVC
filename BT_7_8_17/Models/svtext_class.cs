using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace svtext.Models
{
    public class svtext_class
    {
        private string path_sv_diemdanh = Directory.GetCurrentDirectory()+"/wwwroot/data/svdiemdanh.txt";
        public string id {get;set;}
        public string name {get;set;}
        public string gender {get;set;}
        public string dob {get;set;}
        public string hometown {get;set;}

        public svtext_class(){}
        public svtext_class(string id,string name,string gender,string dob,string hometown)
        {
            this.id = id;
            this.name= name;
            this.gender = gender;
            this.dob = dob;
            this.hometown = hometown;
        }

        public void diemdanhsv(string id,string name,string date, string status,string note)
        {
            StreamWriter sw = File.AppendText(path_sv_diemdanh);
            sw.WriteLine();
            sw.Write(id+"#"+name+"#"+date+"#"+status+"#"+note);
            sw.Flush();
        }
    }
}