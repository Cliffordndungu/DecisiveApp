using System.ComponentModel.DataAnnotations.Schema;

namespace DecisiveApp.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        public int serviceid { get; set; }
        [ForeignKey("serviceid")]
        public Service Service { get; set; }

        public int Orderid { get; set; }
        [ForeignKey("Orderid")]
        public Orders Order { get; set; }
    }
}
