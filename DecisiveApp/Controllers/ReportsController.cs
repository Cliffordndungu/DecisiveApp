using DecisiveApp.Data.Enums;
using DecisiveApp.Data.Services;
using DecisiveApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DecisiveApp.Controllers
{
	public class ReportsController : Controller
	{
		private readonly IReportsService _service;

		public ReportsController(IReportsService service)
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
		public async Task<IActionResult> Create([Bind("Filepath,Name,type,Description,userid,email")] Reports reports)
		{
			if (!ModelState.IsValid)
			{
				return View(reports);
			}
			await _service.AddAsync(reports);
			return RedirectToAction(nameof(Index));

		}
		//get Actors/Details/1

		public async Task<IActionResult> Details(int id)
		{
			var ReportDetails = await _service.GetByidAsync(id);
			if (ReportDetails == null) return View("NotFound");
			return View(ReportDetails);

		}

		//Get Edit
		public async Task<IActionResult> Edit(int id)
		{
			var ReportDetails = await _service.GetByidAsync(id);
			if (ReportDetails == null) return View("NotFound");
			return View(ReportDetails);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("Filepath,Name,type,Description,userid,email")] Reports reports)
		{
			if (!ModelState.IsValid)
			{
				return View(reports);
			}
			await _service.UpdateAsync(id, reports);
			return RedirectToAction(nameof(Index));

		}

		//Delete
		public async Task<IActionResult> Delete(int id)
		{
			var ReportDetails = await _service.GetByidAsync(id);
			if (ReportDetails == null) return View("NotFound");
			return View(ReportDetails);
		}
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var ReportDetails = await _service.GetByidAsync(id);
			if (ReportDetails == null) return View("NotFound");
			await _service.DeleteAsync(id);
			return RedirectToAction(nameof(Index));

		}
	}
}
