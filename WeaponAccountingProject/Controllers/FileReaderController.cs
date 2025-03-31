using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Data;
using WeaponAccountingProject.Data;
using WeaponAccountingProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Security.AccessControl;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeaponAccountingProject.Interfaces;

namespace WeaponAccountingProject.Controllers
{
    public class FileReaderController : Controller
    {
        private List<List<String>> _fileData;
        private readonly IWeaponRepository _weaponRepository;
        public FileReaderController(IWeaponRepository weaponRepository)
        {
            _weaponRepository = weaponRepository;
        }
        public IActionResult Index()
        {
            ViewData["Locations"] = new SelectList(_weaponRepository.GetAllLocations(), "LocationId", "Name");
            //ViewBag.Data = _fileData;
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
                    var lineWithDelimitor = replaceComaWithDotComa(line);
                    var values = lineWithDelimitor.Split(';').ToList();

                    Data.Add(values);
                }
                _fileData = Data;
                ViewBag.Data = Data;

                ViewData["Locations"] = new SelectList(_weaponRepository.GetAllLocations(), "LocationId", "Name");
                return View();
            }
        }

        private string replaceComaWithDotComa(string fileString)
        {
            string pattern = @"(,|\r?\n|`)([^`"",\r\n]+|""(?:[^""]|"")*"")?";
            string result = "";
            var regex = new Regex(pattern, RegexOptions.Compiled);
            MatchCollection matches = regex.Matches(fileString);

            foreach (Match match in matches)
            {
                if (match.Groups[1].Value == ",")
                {
                    // Add a tab character and the second group value (if exists)
                    result += ";" + (match.Groups[2].Success ? match.Groups[2].Value : "");
                }
                else
                {
                    // Add the entire match to the result
                    result += match.Value;
                }
            }

            return result;
        }
    }
}
