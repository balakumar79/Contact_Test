using Contact_Test.Models;
using Contact_Test.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Contact_Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactRepository _contactRepository;

        public HomeController(ILogger<HomeController> logger, IContactRepository contactRepository)
        {
            _logger = logger;
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {
            var model = _contactRepository.GetContacts();
            return View(model);
        }
        public IActionResult Contact(int id)
        {
            if (id > 0)
                return View(_contactRepository.GetContact(id));
            else
                return View(new ContactModel());
        }
        [HttpPost]
        public IActionResult Contact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                if (_contactRepository.UpdateContact(model))
                    return RedirectToAction(nameof(Index));

                return View();
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult DeleteContact(int id)
        {
            _contactRepository.DeleteContact(id);
            return RedirectToAction(nameof(Index));
        }
        [AcceptVerbs("Get", "Post")]
        public IActionResult IsEmailExists(int Id, string email)
        {
            return Json(!_contactRepository.IsEmailExists(email, Id));
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
    }
}
