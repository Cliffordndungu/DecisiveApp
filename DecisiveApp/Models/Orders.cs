using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecisiveApp.Models
{
    public class Orders
    {
        [Key]
        public int id { get; set; }
        public string Email { get; set; }
        public string userid { get; set; }
        //[ForeignKey(nameof(userid))]
        //public ApplicationUser User { get; set; }


        public List<OrderItem> orderItems { get; set; }
    }
}
