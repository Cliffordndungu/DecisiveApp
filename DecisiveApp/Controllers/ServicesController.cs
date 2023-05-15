using DecisiveApp.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DecisiveApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace DecisiveApp.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServiceService _service;

        public ServicesController(IServiceService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var Services = await _service.GetAllAsync();
            return View(Services);
        }

        //Get request url: Services/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("name,description,pricing,Price,imageurl")] Service service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }
            await _service.AddAsync(service);
            return RedirectToAction(nameof(Index));

        }

        //get Actors/Details/1
      
        public async Task<IActionResult> Details(int id)
        {
            var serviceDetails = await _service.GetByidAsync(id);
            if (serviceDetails == null) return View("NotFound");
            return View(serviceDetails);

        }

        //Get Edit
        public async Task<IActionResult> Edit(int id)
        {
            var serviceDetails = await _service.GetByidAsync(id);
            if (serviceDetails == null) return View("NotFound");
            return View(serviceDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("name,description,pricing,Price,imageurl")] Service service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }
            await _service.UpdateAsync(id, service);
            return RedirectToAction(nameof(Index));

        }
    }
}
