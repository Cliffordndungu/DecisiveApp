using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using DecisiveApp.Data.Enums;

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

        public DateTime Startdate { get; set; }
        public DateTime Nextbillingdate { get; set; }

        public string status { get; set; }
        public string lastpaymentdate { get; set;}

        public BillingCycle billingcycle{ get; set; }

    }
}
