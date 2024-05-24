using FinalExam.Areas.Admin.ViewModels;
using FinalExam.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> CreateAdmin()
        {
            AppUser admin = new()
            {
                FullName = "Cavid Suleymanli",
                UserName = "Admin"
            };
            await _userManager.CreateAsync(admin, "Admin123@");
            await _userManager.AddToRoleAsync(admin, "SuperAdmin");

            return Ok("Admin Yarandi");
        }
        public async Task<IActionResult> CreateRoles()
        {
            IdentityRole role1 = new IdentityRole("Member");
            IdentityRole role2 = new IdentityRole("Admin");
            IdentityRole role3 = new IdentityRole("SuperAdmin");
            await _roleManager.CreateAsync(role1);
            await _roleManager.CreateAsync(role2);
            await _roleManager.CreateAsync(role3);

            return Ok("Rollar yarandi!");
        }
        public IActionResult Login()
        {
            return View();
        }
        public Task<IActionResult> Login(AdminLoginVM adminLoginVM)
        {
            if(!ModelState.IsValid)
                
        }
    }
}
