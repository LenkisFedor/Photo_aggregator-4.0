using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Photo_aggregator.Models;
using System.Diagnostics;
using System.Security.Claims;
using Photo_aggregator.Domain.ViewModels;
using Photo_aggregator.Service.Interfaces;

namespace Photo_aggregator.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

        private readonly IAccountService _accountService;

        public HomeController(ILogger<HomeController> logger, IAccountService accountService)
		{
			_logger = logger;
            _accountService = accountService;
        }

        public IActionResult Index() => View();

        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var response = await _accountService.Login(model);
        //        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        //        {
        //            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
        //                new ClaimsPrincipal(response.Data));

        //            return RedirectToAction("Index", "Home");
        //        }
        //        ModelState.AddModelError("", response.Description);
        //    }
        //    return View(model);
        //}

        public IActionResult Privacy()
		{
			return View();
		}

        public IActionResult Photographer()
        {
            return View();
        }

        public IActionResult Photographers()
        {
            return View();
        }

        public IActionResult Requests()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}