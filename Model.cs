using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace lab13.Models
{
    public class SearchCondition
    {
        public string Field { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }
    }

    public class Warehouse
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        // Properties that shouldn't be serialized to JSON
        [JsonIgnore]
        public string ProductsFileName => $"{Name}_products.json";

        public Warehouse()
        {
            CreatedDate = DateTime.Now;
        }

        public Warehouse(string name) : this()
        {
            Name = name;
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string WarehouseName { get; set; }  // Link to warehouse

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
        [JsonIgnore]
        public decimal DisplayPrice { get; set; }

        [JsonIgnore]
        public string DisplayCurrency { get; set; }

        [JsonIgnore]
        public decimal TotalValue { get; set; }
    }


    public class ExchangeRate
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public decimal Rate { get; set; }
    }
}
