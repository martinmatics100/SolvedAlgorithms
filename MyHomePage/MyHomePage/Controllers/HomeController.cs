using Microsoft.AspNetCore.Mvc;
using MyHomePage.Models;
using System.Diagnostics;

namespace MyHomePage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //List<Property> Allproperties = ReadPropertiesFromFile("Allproperties.txt");
            //var mostpicks = Allproperties.Where(prop => prop.Popularity == "Most Picks").ToList();
            //var first_mostpick = mostpicks.First();
            //ViewData["mostpicks"] = mostpicks;
            //ViewData["first_mostpick"] = first_mostpick;


            return View();
        }


        //public static List<Property> ReadPropertiesFromFile(string filePath)
        //{
        //    List<Property> properties = new();

        //    using (StreamReader reader = new(filePath))
        //    {
        //        string line;
        //        while ((line = reader.ReadLine()) != null)
        //        {
        //            if (!string.IsNullOrWhiteSpace(line))
        //            {
        //                string[] fields = line.Split('|');

        //                if (fields.Length >= 8)
        //                {
        //                    string id = fields[1].Trim();
        //                    string name = fields[2].Trim();
        //                    string city = fields[3].Trim();
        //                    string location = fields[4].Trim();
        //                    string price = fields[5].Trim();
        //                    string description = fields[6].Trim();
        //                    string type = fields[7].Trim();
        //                    string popularity = fields[8].Trim();

        //                    Property property = new(id, name, city, location, price, description, type, popularity);
        //                    properties.Add(property);
        //                }
        //            }
        //        }
        //    }

        //    return properties;
        //}


        public IActionResult Stories()
        {
            return View();
        }
        public IActionResult Browse_by()
        {
            return View();
        }

        public IActionResult Agents()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}