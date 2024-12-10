using Contact_Project_MVC_.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Contact_Project_MVC_.Controllers
{
    public class ContactController : Controller
    {
        private ContactRepository contactRepository;

        public ContactController()
        {
            contactRepository = new ContactRepository();
        }
         
        public IActionResult Index()
        {
            return View(this.contactRepository.GetContacts());
        }

        public IActionResult Details(int ID)
        {
            var contactResult = this.contactRepository.GetContactByID(ID);

            if(contactResult is null)
            {
                return RedirectToAction("Index", "Contact");
            }

            return View(contactResult);
        }
    }
}
