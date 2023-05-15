using System.ComponentModel.DataAnnotations;

namespace DecisiveApp.Models
{
    public class ShoppingCartItem
    {

        [Key]
        public int id { get; set; }

        public Service service { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartid { get; set; }
    }
}
