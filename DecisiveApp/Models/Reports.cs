using DecisiveApp.Data.Base;
using DecisiveApp.Data.Enums;

namespace DecisiveApp.Models
{
    public class Reports : IEntityBase
    {
        public int id { get; set; }
        public string Filepath { get; set; }
        public string Name { get; set; }

        public ReportType type { get; set; }
        public string Description { get; set; }

        public string userid  { get; set; }
        public string email { get; set; }

    }
}
