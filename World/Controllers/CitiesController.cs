using Microsoft.AspNetCore.Mvc;
using World.Models;
using System.Collections.Generic;

namespace World.Controllers
{
    public class CitiesController : Controller
    {
        [HttpGet("/cities")]
        public ActionResult Index()
        {
            return View(City.GetAllCities());
        }
    }
}