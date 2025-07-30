using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bright_Future.Models;

namespace Bright_Future.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // === Static Page Views ===

        public IActionResult Index() => View();
        public IActionResult About() => View();
        public IActionResult StudyInNZ() => View();
        public IActionResult Contact() => View();
        public IActionResult ThankYou() => View();
        public IActionResult Error() =>
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        // === Optional Views (if these .cshtml files exist) ===

        public IActionResult Tertiary() => View();
        public IActionResult SecondarySchool() => View();
        public IActionResult PrimarySchool() => View();

        public IActionResult Migration() => View();
        public IActionResult SkilledMigration() => View();
        public IActionResult ActiveInvestmentPlus() => View();
        public IActionResult PartnershipCategory() => View();
        public IActionResult ParentCategory() => View();

        public IActionResult VisaServices() => View();
        public IActionResult StudentVisa() => View();
        public IActionResult PostStudyVisa() => View();
        public IActionResult EmployerAccreditation() => View();
        public IActionResult JobCheck() => View();
        public IActionResult AccreditedEmployerWorkVisa() => View();
        public IActionResult VisitVisa() => View();

        public IActionResult DifficultIssues() => View();
        public IActionResult TrialAppeal() => View();
        public IActionResult CharacterWaiver() => View();
        public IActionResult MedicalWaiver() => View();
        public IActionResult CaseStudies() => View();

        public IActionResult PolicyUpdates() => View();
        public IActionResult Privacy() => View();

        // === Contact Form Handling ===

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(ContactInquiry inquiry)
        {
            if (ModelState.IsValid)
            {
                inquiry.SubmissionDate = DateTime.Now;
                inquiry.IsProcessed = false;

                _context.ContactInquiries.Add(inquiry);
                await _context.SaveChangesAsync();

                // Optional: Send email notification to admin

                return RedirectToAction(nameof(ThankYou));
            }
            return View(inquiry);
        }

        // === Language Switching ===

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            // Set culture cookie
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl ?? "/");
        }
    }
}
