using System.Threading.Tasks;
using CreativeFusions.Auth.Data;
using CreativeFusions.Auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CreativeFusions.Auth.Controllers
{
    public class AuthController : Controller
    {
        #region Fields

        private readonly SignInManager<AppUser> _signInManager;

        private readonly UserManager<AppUser> _userManager;
        #endregion

        #region Constructors

        public AuthController(SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        #endregion

        #region Register

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            return View(new RegisterViewModel(returnUrl));
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            AppUser user = new AppUser(registerViewModel);

            IdentityResult result = await _userManager.CreateAsync(user, registerViewModel.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Redirect(registerViewModel.ReturnUrl);
            }

            return View();
        }
        #endregion

        #region Login

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel(returnUrl));
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager
                    .PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    return Redirect(loginViewModel.ReturnUrl);
                }

                return View();
            }

            return View();
        }
        #endregion
    }
}