using DecisiveApp.Data.Base;
using DecisiveApp.Models;

namespace DecisiveApp.Data.Services
{
	public class ReportsService : EntityBaseRepository<Reports>, IReportsService
	{
		private readonly AppDBContext _context;
		public ReportsService(AppDBContext context) : base(context)
		{
			_context = context;
		}
	}
}
