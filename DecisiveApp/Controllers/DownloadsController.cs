using DecisiveApp.Data.Services;
using DecisiveApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace DecisiveApp.Controllers
{
    public class DownloadsController : Controller
    {
        private readonly IDownloadsService _service;

        public DownloadsController(IDownloadsService service)
        {
            _service = service;
        }
       
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get request url: Actors/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Description,Filepath,OS")] Downloads downloads)
        {
            if (!ModelState.IsValid)
            {
                return View(downloads);
            }
            await _service.AddAsync(downloads);
            return RedirectToAction(nameof(Index));

        }

        //get Actors/Details/1
        
        public async Task<IActionResult> Details(int id)
        {
            var downloadDetails = await _service.GetByidAsync(id);
            if (downloadDetails == null) return View("NotFound");
            return View(downloadDetails);

        }

        //Get Edit
        public async Task<IActionResult> Edit(int id)
        {
            var downloadDetails = await _service.GetByidAsync(id);
            if (downloadDetails == null) return View("NotFound");
            return View(downloadDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,Filepath,OS")] Downloads downloads)
        {
            if (!ModelState.IsValid)
            {
                return View(downloads);
            }
            await _service.UpdateAsync(id, downloads);
            return RedirectToAction(nameof(Index));

        }

        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            var downloadDetails = await _service.GetByidAsync(id);
            if (downloadDetails == null) return View("NotFound");
            return View(downloadDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var downloadDetails = await _service.GetByidAsync(id);
            if (downloadDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
