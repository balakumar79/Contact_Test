using Contact_Test.ModelFactory.Interface;
using Contact_Test.Models;
using Contact_Test.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Contact_Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactRepository _contactRepository;
        private readonly IContactModelFactory _contactModelFactory;
        private IHostingEnvironment _hostingEnvironment;

        public HomeController(ILogger<HomeController> logger, IContactRepository contactRepository, IContactModelFactory contactModelFactory,
            IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _contactRepository = contactRepository;
            _contactModelFactory = contactModelFactory;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var model = _contactRepository.GetContacts().OrderByDescending(s => s.CreatedDate);
            return View(model);
        }
        public IActionResult Contact(int id)
        {
            if (id > 0)
            {
                var model = _contactRepository.GetContact(id);
                model = _contactModelFactory.PrepareContactModel(model);
                return View(model);

            }
            else
            {

                return View(_contactModelFactory.PrepareContactModel(new ContactModel()));
            }
        }
        [HttpPost]
        public IActionResult Contact(ContactModel model, [FromForm] IFormFile File)
        {

            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    var dirc = "Files";
                    string filePath = Path.Combine(_hostingEnvironment.WebRootPath, dirc);
                    if (!Directory.Exists(filePath))
                        Directory.CreateDirectory(filePath);
                    var fileName = File.FileName;
                    var path = Path.Combine(filePath, fileName);
                    using (var fs = System.IO.File.Create(path))
                    {
                        File.CopyTo(fs);
                        model.ProfileImage = fileName;
                    }
                }
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
