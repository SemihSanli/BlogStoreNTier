using BlogStore.EntityLayer.Entities;
using BlogStore.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signinManager;

        public LoginController(SignInManager<AppUser> signinManager)
        {
            _signinManager = signinManager;
        }

        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginViewModel userLoginViewModel)
        {
            var result = await _signinManager.PasswordSignInAsync(userLoginViewModel.Username, userLoginViewModel.Password, true, false);
            if (result.Succeeded)
            {
                return RedirectToAction("GetPorfile", "Author");
            }
            return View();
        }
    }
}
