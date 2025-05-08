using IdentityChatEmailNight.Context;
using IdentityChatEmailNight.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityChatEmailNight.Controllers
{
    public class ProfileController : Controller
    {
        private readonly EmailContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(EmailContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async  Task<IActionResult> ProfileDetail()
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.name = values.Name;
            ViewBag.surname=values.Surname;
            ViewBag.email=values.Email;
            ViewBag.phone = values.PhoneNumber;
            return View();
        }
    }
}
