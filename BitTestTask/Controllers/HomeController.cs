using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Domain.Models;
using Task_Service.Interfaces;

namespace BitTestTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonService _personService;

        public HomeController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> HomePage()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<Person>> GetAllPerson()
        {
            return await _personService.GetAll().Result.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePerson(Person data)
        {
            await _personService.UpdateData(data);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeletePerson(int id)
        {

            await _personService.DeleteData(id);
            return Ok();
        }
    }
}
