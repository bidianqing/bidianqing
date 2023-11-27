using bidianqing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

namespace bidianqing.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHubContext<NotificationHub> _hubContext;


        public HomeController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> SendAll([FromQuery] string message)
        {
            await _hubContext.Clients.All.SendAsync("receiveMessage", message);

            return Content("ok");
        }
    }
}