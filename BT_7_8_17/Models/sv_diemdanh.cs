using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace sv_diemdanh.Models
{
    public class sv_diemdanh_class
    {
        private string path = Directory.GetCurrentDirectory()+"/wwwroot/data/svdiemdanh.txt";
        public string id {get;set;}
        public string name {get;set;}
        public string date {get;set;}
        public string  status {get;set;}
        public string note {get;set;}

        public sv_diemdanh_class(){}
        public sv_diemdanh_class(string id,string name,string date,string status,string note)
        {
            this.id = id;
            this.name= name;
            this.date = date;
            this.status = status;
            this.note = note;
        }

         public List<sv_diemdanh_class> ReadList()
        {
            List<sv_diemdanh_class> list = new List<sv_diemdanh_class>();
            StreamReader rd = System.IO.File.OpenText(path);
            string s = rd.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('#');
                    list.Add(new sv_diemdanh_class(a[0], a[1], a[2], a[3], a[4]));
                }
                s = rd.ReadLine();
            }
            return list;
        }
        public bool CheckDate(string date)
        {
            List<string> list = new List<string>();
            StreamReader rd = System.IO.File.OpenText(path);
            string s = rd.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('#');
                    list.Add(a[2].ToString());
                }
                s = rd.ReadLine();
            }
            
            if(list.Contains(date) == true){
                return true;
            }
            
            return false;
        }
    }
}