using Microsoft.AspNetCore.Mvc;
using Task_Service.Interfaces;

namespace BitTestTask.Controllers
{
    public class FileController : Controller
    {
        private readonly IUploadService _uploadService;

        public FileController(IUploadService uploadService)
        {
            _uploadService = uploadService;
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile csvFile)
        {
            await _uploadService.UploadPersons(csvFile);

            return RedirectToAction("HomePage", "Home");
        }
    }
}
