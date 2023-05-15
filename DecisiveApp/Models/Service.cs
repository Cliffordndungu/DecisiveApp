using DecisiveApp.Data.Base;
using DecisiveApp.Data.Enums;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.ComponentModel.DataAnnotations;

namespace DecisiveApp.Models
{
    public class Service: IEntityBase
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Pricing pricing { get; set; }
        public double Price { get; set; }
        public string imageurl { get; set; }
        //public DateTime Startdate { get; set; }
        //public DateTime Enddate { get; set; }
      
    }
}
