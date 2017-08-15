using System;
using Microsoft.AspNetCore.Mvc;

namespace pt.Models
{
    public class giaipt{
        public float? a { get;set;}
        public float? b { get;set;}

        public string cal(){
           if(a == null && b== null){
               return "";
           }else{
                if(a==0){
                if(b==0){
                    return "Phương trình có vô số nghiệm";
                }else{
                    return "Phương trình vô nghiệm";
                }
            }else{
                return string.Format("Phương trình có nghiệm x = {0}",-b/a);
            }
           }
        }

        public string kq{get;set;}
    }
}