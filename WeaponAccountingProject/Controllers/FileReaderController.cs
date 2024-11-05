using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WeaponAccountingProject.Controllers
{
    public class FileReaderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            var Data = new List<List<string>> { };
            if (file == null || file.Length == 0)
            {
                return Content("File not selected");
            }
            using (var reader = new StreamReader(file.OpenReadStream(), Encoding.UTF8))
            { 
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';').ToList();
                    
                    Data.Add(values);
                }
               
                ViewBag.Data = Data;
                return View();
            }
        }
    }
}
