using DecisiveApp.Data.Base;
using DecisiveApp.Data.Enums;

namespace DecisiveApp.Models
{
    public class Downloads :IEntityBase
    {
        public int id { get; set; }
        public string Filepath { get; set; }
        public string Name { get; set; }

        public OSCategory OS { get; set; }
        public string Description { get; set; }
    }
}
