using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using lab13.Models;
using System.Text.Json;


namespace lab13.Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void SaveChanges();
    }




    public class FileRepository : IRepository<Product>
    {
        private readonly string _filePath;
        private readonly string _exchangeRatesPath;
        private List<Product> _products;
        private List<ExchangeRate> _exchangeRates;
        private const string BASE_CURRENCY = "EUR";

        public FileRepository(string productsFilePath = "products.json",
                            string exchangeRatesPath = "exchange_rates.csv")
        {
            _filePath = productsFilePath;
            _exchangeRatesPath = exchangeRatesPath;
            LoadExchangeRates();
            LoadProducts();
        }

        private void LoadExchangeRates()
        {
            _exchangeRates = new List<ExchangeRate>();

            if (!File.Exists(_exchangeRatesPath))
            {
                // Create default exchange rates
                CreateDefaultExchangeRates();
                return;
            }

            try
            {
                var lines = File.ReadAllLines(_exchangeRatesPath);
                foreach (var line in lines.Skip(1)) // Skip header
                {
                    var parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        _exchangeRates.Add(new ExchangeRate
                        {
                            FromCurrency = parts[0],
                            ToCurrency = parts[1],
                            Rate = decimal.Parse(parts[2])
                        });
                    }
                }
            }
            catch (Exception)
            {
                CreateDefaultExchangeRates();
            }
        }

        private void CreateDefaultExchangeRates()
        {
            _exchangeRates = new List<ExchangeRate>
            {
                new ExchangeRate { FromCurrency = "EUR", ToCurrency = "UAH", Rate = 40.0m },
                new ExchangeRate { FromCurrency = "EUR", ToCurrency = "USD", Rate = 1.08m },
                new ExchangeRate { FromCurrency = "EUR", ToCurrency = "EUR", Rate = 1.0m },
                new ExchangeRate { FromCurrency = "UAH", ToCurrency = "EUR", Rate = 0.025m },
                new ExchangeRate { FromCurrency = "USD", ToCurrency = "EUR", Rate = 0.93m }
            };

            SaveExchangeRates();
        }

        private void SaveExchangeRates()
        {
            try
            {
                var lines = new List<string> { "FromCurrency,ToCurrency,Rate" };
                lines.AddRange(_exchangeRates.Select(er => $"{er.FromCurrency},{er.ToCurrency},{er.Rate}"));
                File.WriteAllLines(_exchangeRatesPath, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving exchange rates: {ex.Message}");
            }
        }

        private void LoadProducts()
        {
            if (!File.Exists(_filePath))
            {
                _products = new List<Product>();
                return;
            }

            try
            {
                var json = File.ReadAllText(_filePath);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                _products = JsonSerializer.Deserialize<List<Product>>(json, options) ?? new List<Product>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading products: {ex.Message}");
                _products = new List<Product>();
            }
        }

        private void SaveProductsToJson()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                var json = JsonSerializer.Serialize(_products, options);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving products to JSON: {ex.Message}");
            }
        }

        public decimal ConvertCurrency(decimal amount, string fromCurrency, string toCurrency)
        {
            if (fromCurrency == toCurrency) return amount;

            // Try direct conversion
            var directRate = _exchangeRates.FirstOrDefault(er =>
                er.FromCurrency == fromCurrency && er.ToCurrency == toCurrency);
            if (directRate != null)
                return amount * directRate.Rate;

            // Try reverse conversion
            var reverseRate = _exchangeRates.FirstOrDefault(er =>
                er.FromCurrency == toCurrency && er.ToCurrency == fromCurrency);
            if (reverseRate != null)
                return amount / reverseRate.Rate;

            // Try through base currency
            var toBase = _exchangeRates.FirstOrDefault(er =>
                er.FromCurrency == fromCurrency && er.ToCurrency == BASE_CURRENCY);
            var fromBase = _exchangeRates.FirstOrDefault(er =>
                er.FromCurrency == BASE_CURRENCY && er.ToCurrency == toCurrency);

            if (toBase != null && fromBase != null)
                return amount * toBase.Rate * fromBase.Rate;

            return amount; // Fallback
        }

        public List<Product> GetAll()
        {
            return _products.ToList();
        }

        public List<Product> GetAllWithCurrency(string targetCurrency)
        {
            var products = new List<Product>();
            foreach (var product in _products)
            {
                var displayPrice = ConvertCurrency(product.BasePrice, BASE_CURRENCY, targetCurrency);
                var productCopy = new Product
                {
                    Id = product.Id,
                    Group = product.Group,
                    Name = product.Name,
                    Manufacturer = product.Manufacturer,
                    Supplier = product.Supplier,
                    Unit = product.Unit,
                    BasePrice = product.BasePrice,
                    OriginalCurrency = product.OriginalCurrency,
                    Quantity = product.Quantity,
                    Date = product.Date,
                    DisplayPrice = displayPrice,
                    DisplayCurrency = targetCurrency,
                    TotalValue = displayPrice * product.Quantity
                };
                products.Add(productCopy);
            }
            return products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            // Convert price to base currency for storage
            if (product.OriginalCurrency != BASE_CURRENCY)
            {
                product.BasePrice = ConvertCurrency(product.BasePrice, product.OriginalCurrency, BASE_CURRENCY);
            }

            product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
            product.Date = DateTime.Now;
            _products.Add(product);
            SaveProductsToJson();
        }

        public void Update(Product product)
        {
            var existing = GetById(product.Id);
            if (existing != null)
            {
                // Convert to base currency if original currency changed
                if (product.OriginalCurrency != BASE_CURRENCY)
                {
                    product.BasePrice = ConvertCurrency(product.BasePrice, product.OriginalCurrency, BASE_CURRENCY);
                }

                existing.Group = product.Group;
                existing.Name = product.Name;
                existing.Manufacturer = product.Manufacturer;
                existing.Supplier = product.Supplier;
                existing.Unit = product.Unit;
                existing.BasePrice = product.BasePrice;
                existing.OriginalCurrency = product.OriginalCurrency;
                existing.Quantity = product.Quantity;

                SaveProductsToJson();
            }
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _products.Remove(product);
                SaveProductsToJson();
            }
        }

        public void SaveChanges()
        {
            SaveProductsToJson();
        }
    }
}