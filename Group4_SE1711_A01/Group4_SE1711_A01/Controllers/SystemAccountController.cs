using FUNews.DAL.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Group4_SE1711_A01.Controllers
{
    public class SystemAccountController : Controller
    {
        private readonly AppDbContext _context;

        public SystemAccountController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /SystemAccount
        public async Task<IActionResult> Index()
        {
            var accounts = await _context.SystemAccounts.ToListAsync();
            return View(accounts);
        }
    }
}
