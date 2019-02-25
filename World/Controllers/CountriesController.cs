using Microsoft.AspNetCore.Mvc;
using World.Models;
using System.Collections.Generic;

namespace World.Controllers
{
    public class CountriesController : Controller
    {
        [HttpGet("/countries")]
        public ActionResult Index()
        {
            return View(Country.GetAllCountries());
        }
    }
}