using System;
using Microsoft.AspNetCore.Mvc;
namespace pt2an.Models
{
    public class giaipt2an
    {
         public double? a1 { get;set;}
        public double? a2 { get;set;}
        public double? b1 { get;set;}
         public double? b2 { get;set;}
        public double? c1 { get;set;}
         public double? c2 { get;set;}
        public string kq{get;set;}
         public string cal(){
             if(a1 == null && a2 == null &&
             b1 == null && b2 == null && c1 == null && c2 == null){
                 return "";
             }
            double? d = a1*b2 - a2*b1;
            double? dx = c1*b2 - c2*b1;
            double? dy = a1*c2 - a2*c1;

            if(d == 0 && dx == 0 && dy == 0){
                return "Hệ phương trình có vô số nghiệm";
            }else{
                if(d == 0 && (dx != 0 || dy!= 0 )){
                    return "Hệ phương trình vô nghiệm";
                }else{
                    return string.Format("Hệ phương trình có nghiệm duy nhất x = {0} và y = {1} ",dx/d,dy/d);
                }
            }
         }
    }
}