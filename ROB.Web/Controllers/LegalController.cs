using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ROB.Web.Models;

namespace ROB.Web.Controllers
{
    public class LegalController : Controller
    {
        public IActionResult TermsOfUse()
        {
            return View();
        }

        public IActionResult PrivacyPolicy()
        {
            return View();
        }
    }
}
