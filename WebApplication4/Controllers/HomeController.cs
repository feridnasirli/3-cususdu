using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private readonly BusConetext _busConetext;

        public HomeController(BusConetext busConetext)
        {
            _busConetext = busConetext;
        }

        public IActionResult Index()
        {
            List<Team> teams = _busConetext.Teams.ToList();
            return View(teams);
        }

    }
}