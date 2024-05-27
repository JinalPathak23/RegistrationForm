using Microsoft.AspNetCore.Mvc;
using RegistrationForm.Domain;
using RegistrationForm.Services;

namespace RegistrationForm.Controllers
{
    public class RegisterController : Controller
    {
        #region Fields

        private readonly IFormDataRepository _formDataRepository;

        #endregion

        #region Ctor
        public RegisterController(IFormDataRepository formDataRepository)
        {
            _formDataRepository = formDataRepository;
        }

        #endregion

        #region Methods
        public IActionResult Index()
        {         
            var data = _formDataRepository.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult AddEdit(int? id)
        {
            if (id.HasValue)
            {
                var data = _formDataRepository.GetById(id.Value);
                return PartialView("_AddEditData", data);
            }
            else
            {
                return PartialView("_AddEditData", new FormData());
            }
        }

        [HttpPost]
        public IActionResult Save(FormData data)
        {
            if (ModelState.IsValid)
            {
                if (data.Id == 0)
                {
                    _formDataRepository.Add(data);
                    TempData["SuccessMessage"] = "Data added successfully.";
                }
                else
                {
                    _formDataRepository.Update(data);
                    TempData["SuccessMessage"] = "Data updated successfully.";
                }

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _formDataRepository.Delete(id);        
            return RedirectToAction("Index");
        }


        public IActionResult ViewData(int id)
        {
            var data = _formDataRepository.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }


        #endregion

    }
}
