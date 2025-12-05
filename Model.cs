using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace lab13.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Group { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Supplier { get; set; }
        public string Unit { get; set; }

        // These will be serialized to JSON
        public decimal BasePrice { get; set; } // Stored in base currency (EUR)
        public string OriginalCurrency { get; set; }

        public int Quantity { get; set; }
        public DateTime Date { get; set; }

        // These are transient (calculated) - not serialized to JSON
        [System.Text.Json.Serialization.JsonIgnore]
        public decimal DisplayPrice { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public string DisplayCurrency { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public decimal TotalValue { get; set; }
    }


    public class ExchangeRate
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public decimal Rate { get; set; }
    }
}
