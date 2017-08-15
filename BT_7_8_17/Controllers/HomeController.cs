using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pt.Models;
using pt2.Models;
using pt2an.Models;
using svtext.Models;
using sv_diemdanh.Models;
using System.IO;
using System.Text;
using OfficeOpenXml;

namespace BT_7_8_17.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pt()
        {
            giaipt data = new giaipt();
            try
            {
                data.a = float.Parse(Request.Form["a"].ToString());
                data.b = float.Parse(Request.Form["b"].ToString());
            }
            catch (Exception)
            {

            }
            data.kq = data.cal();
            return View(data);
        }
        
        public IActionResult pt2()
        {
            return View();
        }
        public string giaipt2_ajax(float a,float b,float c)
        {
            giaipt2 pt2 = new giaipt2();
            pt2.kq = "";
            try
            {
                pt2.a = a;
                pt2.b = b;
                pt2.c = c;
            }
            catch (Exception) { }
            return pt2.cal();
        }

        public IActionResult pt2an()
        {
            giaipt2an pt2an = new giaipt2an();
            pt2an.kq = "";
             try
            {
                pt2an.a1 = float.Parse(Request.Form["a1"].ToString());
                pt2an.a2 = float.Parse(Request.Form["a2"].ToString());
                pt2an.b1 = float.Parse(Request.Form["b1"].ToString());
                pt2an.b2 = float.Parse(Request.Form["b2"].ToString());
                pt2an.c1 = float.Parse(Request.Form["c1"].ToString());
                pt2an.c2 = float.Parse(Request.Form["c2"].ToString());
            }
            catch (Exception) { }
            pt2an.kq = pt2an.cal();
            return View(pt2an);
        }

        public IActionResult svtext()
        {
            List<svtext_class> list = ReadList();
            ViewData["count"] = list;
            return View();
        }

        public IActionResult svexcel()
        {
            ViewData["data_excel"] = ReadFromExcel();
            return View();
        }

        public IActionResult svrandom()
        {
            List<svtext_class> list = ReadList();
            // Random rnd = new Random();
            // ViewData["sv_choosed"] = list[rnd.Next(list.Count)];
            ViewData["list_sv"] = list;
            return View();
        }

        public IActionResult svdiemdanh()
        {

            List<svtext_class> list = ReadList();
            ViewData["count"] = list;
            ViewData["path"] = Directory.GetCurrentDirectory() + "/wwwroot/data/svdiemdanh.txt";
            return View();
        }

        public IActionResult svthongke()
        {
            sv_diemdanh_class sv_dd = new sv_diemdanh_class();
            ViewData["lst_sv_diemdanh"] = sv_dd.ReadList();
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }

        public List<svtext_class> ReadList()
        {
            List<svtext_class> list = new List<svtext_class>();
            string path = Directory.GetCurrentDirectory() + "/wwwroot/data/sv.txt";
            StreamReader rd = System.IO.File.OpenText(path);
            string s = rd.ReadLine();
            while (s != null)
            {
                if (s != "")
                {
                    string[] a = s.Split('#');
                    list.Add(new svtext_class(a[0], a[1], a[2], a[3], a[4]));
                }
                s = rd.ReadLine();
            }
            return list;
        }

        public List<svtext_class> ReadFromExcel()
        {
            string sWebRootFolder = Directory.GetCurrentDirectory() + "/wwwroot/data/";
            string sFileName = @"demo.xlsx";
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            using (ExcelPackage package = new ExcelPackage(file))
            {
                List<svtext_class> sv = new List<svtext_class>();
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                int rowCount = worksheet.Dimension.Rows;
                int ColCount = worksheet.Dimension.Columns;
                for (int row = 1; row <= rowCount; row++)
                {
                    sv.Add(new svtext_class(worksheet.Cells[row, 1].Value.ToString(),
                    worksheet.Cells[row, 2].Value.ToString(), worksheet.Cells[row, 3].Value.ToString(),
                    worksheet.Cells[row, 4].Value.ToString(), worksheet.Cells[row, 5].Value.ToString()));
                }
                return sv;
            }
        }
        public string getsv()
        {
            Random rnd = new Random();
            List<svtext_class> list = ReadList();
            svtext_class sv = list[rnd.Next(list.Count)];
            return sv.id + "#" + sv.name;
        }

        public bool add_sv_statistic(string id, string name, string date, string status, string note)
        {
            sv_diemdanh_class sv_dd = new sv_diemdanh_class();
            try
            {
                if (id != "" && name != "" && date != "" && status != "" && note != "")
                {
                    
                        svtext_class sv = new svtext_class();
                        sv.diemdanhsv(id, name, date, status, note);
                        return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
