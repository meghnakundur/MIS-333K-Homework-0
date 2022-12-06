using Microsoft.AspNetCore.Mvc;
using Kundur_Meghna_HW0.Models;


namespace Kundur_Meghna_HW0.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid == false) //response is not valid 
            {
                return View();
            }
            Repository.AddResponse(guestResponse);
            return View("Thanks", guestResponse);
        }

        public IActionResult ListResponses()
        {
            IEnumerable<GuestResponse> attendeeList = Repository.Responses
                                                .Where(r => r.WillAttend == true);
            return View(attendeeList);
        }
    }
}

