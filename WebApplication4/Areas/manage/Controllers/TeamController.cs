using Microsoft.AspNetCore.Mvc;
using WebApplication4.Helpers;
using WebApplication4.Models;

namespace WebApplication4.Areas.manage.Controllers
{
    [Area("manage")]
    public class TeamController : Controller
    {
        private readonly BusConetext _busConetext;
        private readonly IWebHostEnvironment _web;

        public TeamController(BusConetext busConetext,IWebHostEnvironment web)
        {
            _busConetext = busConetext;
            _web = web;
        }
        public IActionResult Index()
        {
            List<Team> teams = _busConetext.Teams.ToList();
            return View(teams);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
           
            if (team.ImageFile.ContentType != "image/png" && team.ImageFile.ContentType != "image/jpeg")
            {
                ModelState.AddModelError("ImageFile", "Only .jpeg and .png");
                return View();
            }
            team.Image = FileManager.SaveFile(_web.WebRootPath, "uploads/teams", team.ImageFile);
            _busConetext.Teams.Add(team);
            _busConetext.SaveChanges();

            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Team team = _busConetext.Teams.Find(id);
            return View(team);
        }
        [HttpPost]
        public IActionResult Update(Team team)
        {
            Team exteam= _busConetext.Teams.FirstOrDefault(x=>x.Id == team.Id);
            if (team != null) NotFound();

            if(team.ImageFile!=null)
            {
                if (team.ImageFile.ContentType != "image/png" && team.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "Only .jpeg and .png");
                    return View();
                }
                string name = FileManager.SaveFile(_web.WebRootPath, "uploads/teams", team.ImageFile);
                FileManager.DeleteFile(_web.WebRootPath, "uploads/teams", exteam.Image);
                exteam.Image = name;
            }
            exteam.FacebookURL=team.FacebookURL;
            exteam.TwitterURL=team.TwitterURL;
            exteam.Pression=team.Pression;
            exteam.InstagramURL=team.InstagramURL;
            exteam.FullName=team.FullName;

            _busConetext.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Team team= _busConetext.Teams.FirstOrDefault(y=>y.Id == id);
            if (team != null) NotFound();
            if (team.Image != null)
            {
                FileManager.DeleteFile(_web.WebRootPath, "uploads/teams", team.Image);
            }
            _busConetext.Remove(team);
            _busConetext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
