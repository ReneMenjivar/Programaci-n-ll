using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer // Define el espacio de nombres para la clase Customers
{
    public class Customers // Define la clase pública Customers
    {
        public string CustomerID { get; set; } // Propiedad pública CustomerID de tipo string
        public string CompanyName { get; set; } // Propiedad pública CompanyName de tipo string
        public string ContactName { get; set; } // Propiedad pública ContactName de tipo string
        public string ContactTitle { get; set; } // Propiedad pública ContactTitle de tipo string
        public string Address { get; set; } // Propiedad pública Address de tipo string
        public string City { get; set; } // Propiedad pública City de tipo string
        public string Region { get; set; } // Propiedad pública Region de tipo string
        public string PostalCode { get; set; } // Propiedad pública PostalCode de tipo string
        public string Country { get; set; } // Propiedad pública Country de tipo string
        public string Phone { get; set; } // Propiedad pública Phone de tipo string
        public string Fax { get; set; } // Propiedad pública Fax de tipo string
    }
}
