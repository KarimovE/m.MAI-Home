using HackatonProject.Data;
using HackatonProject.DataAccessLayer;
using HackatonProject.Models;
using HackatonProject.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HackatonProject.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<User> _userManager;

        private readonly AppDbContext _dbContext;

        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager = null, AppDbContext dbContext = null)
        {
            _userManager = userManager;

            _signInManager = signInManager;

            _dbContext = dbContext;
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var ExistUser = await _userManager.FindByNameAsync(registerViewModel.Username);

            if (ExistUser != null)
            {
                ModelState.AddModelError("Username", "User with this username already exits");

                return View(registerViewModel);
            }

            var user = new User()
            {
                FullName = registerViewModel.Fullname,

                UserName = registerViewModel.Username,

                Email = registerViewModel.Email,
            };

            var result = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(registerViewModel);
            }



            await _userManager.AddToRoleAsync(user, RoleConstants.UserRole);

            await _signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)

                return View(loginViewModel);

            var existUser = await _userManager.FindByNameAsync(loginViewModel.Username);

            if (existUser == null)
            {
                ModelState.AddModelError("", "Incorrect username or password");

                return View(loginViewModel);
            }

            var result = await _signInManager.PasswordSignInAsync(existUser, loginViewModel.Password, loginViewModel.RememberMe, true);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password incorrect");

                return View(loginViewModel);
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "You are locked out");

                return View(loginViewModel);
            }

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }


    }
}