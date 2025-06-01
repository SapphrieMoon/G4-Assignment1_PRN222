using FUNews.DAL.Database;
using Group4_SE1711_A01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Group4_SE1711_A01.Controllers.Auth
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var account = _context.SystemAccounts
                .FirstOrDefault(a => a.AccountEmail == model.Email && a.AccountPassword == model.Password);

            if (account != null)
            {
                HttpContext.Session.SetString("UserID", account.AccountID.ToString());
                HttpContext.Session.SetString("UserName", account.AccountName);
                HttpContext.Session.SetString("Role", account.AccountRole);

                if (account.AccountRole == "Admin")
                    return RedirectToAction("Index", "SystemAccount");

                if (account.AccountRole == "Staff")
                    return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Email hoặc mật khẩu không đúng.";
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
