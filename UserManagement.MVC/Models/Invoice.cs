using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.MVC.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Material { get; set; }
        public int Quantity { get; set; }
        public string Units { get; set; }
        public string Counterparty { get; set; }
        public string Type { get; set; }
    }
}
