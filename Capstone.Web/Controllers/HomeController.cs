using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL.Interfaces;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Http;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {

        private IParkDao parkDao;
        private IWeatherDao weatherDao;

        public HomeController(IParkDao parkDao, IWeatherDao weatherDao)
        {
            this.parkDao = parkDao;
            this.weatherDao = weatherDao;
        }

        public IActionResult Index()
        {
            IList<Park> parks = parkDao.GetAllParks();
            return View(parks);
        }


        public IActionResult Details(string parkCode, string tempType)
        {
            Park park = parkDao.GetParkByCode(parkCode);

            IList<Weather> weather = weatherDao.GetWeather(parkCode);
            TempData["Weather"] = weather;

            string result = TempChoice(tempType);
            TempData["TempChoice"] = result;

            return View(park);
        }



        private string TempChoice(string tempType)
        {
            string result = "Fahrenheit";
            string current = HttpContext.Session.GetString("TempChoice");
            if (current == null)
            {
                HttpContext.Session.SetString("TempChoice", result);

                current = result;
            }
            if(tempType != null)
            { 
            current = tempType;
            HttpContext.Session.SetString("TempChoice", current);
            }
            return current;
        }

 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
