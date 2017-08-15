using System;
using Microsoft.AspNetCore.Mvc;

namespace pt2.Models
{
    public class giaipt2{
        public double a { get;set;}
        public double b { get;set;}
        public double c { get;set;}


        public string cal(){
            if( a == 0)
            {
                if(b==0 && c==0)
                {
                    return "Phương trình vô số nghiệm";
                }
                else
                {
                    return string.Format("Phương trình có 1 nghiệm x = {0}",(-c/b));
                }
            }
            else
            {
                double denta = b*b - 4*a*c;
                if(denta > 0)
                {
                    double x1 = (-b+Math.Sqrt(denta)/(2*a));
                    double x2 = (-b-Math.Sqrt(denta))/(2*a);
                    return string.Format("Phương trình có hai nghiệm phân biệt x1 = {0} , x2 = {1} ",x1,x2);
                }
                if(denta == 0)
                {
                    return string.Format("Phương trình có nghiệm kép x1=x2={0}",(-b/2*a));
                }
                return "Phương trình vô nghiệm";
            }
        }

        public string kq{get;set;}
    }
}