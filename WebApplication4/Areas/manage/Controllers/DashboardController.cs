using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Areas.manage.Controllers
{
    [Area("manage")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        //public async Task<IActionResult> CreateAdmin() 
        //{
        //    AppUser user=new AppUser
        //    {
        //        FullName="Ferid Nesirli",
        //        UserName="SuperAdmin"
        //    };
        //    var result= await _userManager.CreateAsync(user,"Ferid2003");
        //    return Ok(result);
        //}
    }
}
