using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using lab13.Models;

namespace lab13.Repositories
{
    public interface IWarehouseRepository
    {
        List<Warehouse> GetAllWarehouses();
        Warehouse GetWarehouse(string name);
        void CreateWarehouse(Warehouse warehouse);
        void UpdateWarehouse(Warehouse warehouse);
        void DeleteWarehouse(string name);
        void SaveAllWarehouses();
        bool WarehouseExists(string name);
    }

    public interface IProductRepository
    {
        List<Product> GetProductsByWarehouse(string warehouseName);
        List<Product> GetProductsByWarehouseAndGroup(string warehouseName, string group);
        List<string> GetGroupsByWarehouse(string warehouseName);
        void SaveWarehouseChanges(string warehouseName);

        void AddProductToWarehouse(string warehouseName, Product product);
        void UpdateProductInWarehouse(string warehouseName, Product product);
        void DeleteProductFromWarehouse(string warehouseName, int productId);
        void DeleteProductsByWarehouseAndGroup(string warehouseName, string group);
        void UpdateProductGroupInWarehouse(string warehouseName, string oldGroup, string newGroup);

        // Currency operations
        List<Product> GetProductsByWarehouseWithCurrency(string warehouseName, string targetCurrency);
        List<Product> GetProductsByWarehouseAndGroupWithCurrency(string warehouseName, string group, string targetCurrency);
        decimal ConvertCurrency(decimal amount, string fromCurrency, string toCurrency);
        void SaveAllChanges();
    }

    public class WarehouseFileRepository : IWarehouseRepository
    {
        private readonly string _dataDirectory;
        private List<Warehouse> _warehouses;

        public WarehouseFileRepository(string dataDirectory = "Data")
        {
            _dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dataDirectory);
            _warehouses = new List<Warehouse>();

            Directory.CreateDirectory(_dataDirectory);
            LoadWarehouses();
        }

        private void LoadWarehouses()
        {
            var warehouseFile = Path.Combine(_dataDirectory, "warehouses.json");

            if (File.Exists(warehouseFile))
            {
                try
                {
                    var json = File.ReadAllText(warehouseFile);
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    _warehouses = JsonSerializer.Deserialize<List<Warehouse>>(json, options) ?? new List<Warehouse>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading warehouses: {ex.Message}");
                    _warehouses = new List<Warehouse>();
                }
            }

            // Create default warehouse if none exist
            if (_warehouses.Count == 0)
            {
                var defaultWarehouse = new Warehouse("Головний")
                {
                    Location = "Головний офіс",
                    Description = "Основний склад компанії"
                };
                CreateWarehouse(defaultWarehouse);
            }
        }

        private void SaveWarehouses()
        {
            try
            {
                var warehouseFile = Path.Combine(_dataDirectory, "warehouses.json");
                var options = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(_warehouses, options);
                File.WriteAllText(warehouseFile, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving warehouses: {ex.Message}");
            }
        }

        public List<Warehouse> GetAllWarehouses()
        {
            return _warehouses.ToList();
        }

        public Warehouse GetWarehouse(string name)
        {
            return _warehouses.FirstOrDefault(w =>
                w.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void CreateWarehouse(Warehouse warehouse)
        {
            if (WarehouseExists(warehouse.Name))
            {
                throw new ArgumentException($"Warehouse with name '{warehouse.Name}' already exists.");
            }

            _warehouses.Add(warehouse);
            SaveWarehouses();
        }

        public void UpdateWarehouse(Warehouse warehouse)
        {
            var existing = GetWarehouse(warehouse.Name);
            if (existing != null)
            {
                existing.Location = warehouse.Location;
                existing.Description = warehouse.Description;
                SaveWarehouses();
            }
        }

        public void DeleteWarehouse(string name)
        {
            if (name.Equals("Головний", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Cannot delete the main warehouse.");
            }

            var warehouse = GetWarehouse(name);
            if (warehouse != null)
            {
                _warehouses.Remove(warehouse);
                SaveWarehouses();
            }
        }

        public void SaveAllWarehouses()
        {
            SaveWarehouses();
        }

        public bool WarehouseExists(string name)
        {
            return _warehouses.Any(w =>
                w.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }

    public class ProductFileRepository : IProductRepository
    {
        private readonly string _dataDirectory;
        private readonly Dictionary<string, List<Product>> _warehouseProducts;
        private readonly List<ExchangeRate> _exchangeRates;
        private const string BASE_CURRENCY = "EUR";

        public ProductFileRepository(string dataDirectory = "Data")
        {
            _dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dataDirectory);
            _warehouseProducts = new Dictionary<string, List<Product>>(StringComparer.OrdinalIgnoreCase);

            Directory.CreateDirectory(_dataDirectory);

            // Load exchange rates
            _exchangeRates = LoadExchangeRates();

            // Load all products
            LoadAllProducts();
        }

        private List<ExchangeRate> LoadExchangeRates()
        {
            var exchangeRatesFile = Path.Combine(_dataDirectory, "exchange_rates.json");

            if (File.Exists(exchangeRatesFile))
            {
                try
                {
                    var json = File.ReadAllText(exchangeRatesFile);
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    return JsonSerializer.Deserialize<List<ExchangeRate>>(json, options)
                        ?? CreateDefaultExchangeRates();
                }
                catch (Exception)
                {
                    return CreateDefaultExchangeRates();
                }
            }

            return CreateDefaultExchangeRates();
        }

        public void SaveWarehouseChanges(string warehouseName)
        {
            SaveWarehouseProducts(warehouseName);
        }

        private List<ExchangeRate> CreateDefaultExchangeRates()
        {
            return new List<ExchangeRate>
            {
                new ExchangeRate { FromCurrency = "EUR", ToCurrency = "UAH", Rate = 40.0m },
                new ExchangeRate { FromCurrency = "EUR", ToCurrency = "USD", Rate = 1.08m },
                new ExchangeRate { FromCurrency = "EUR", ToCurrency = "EUR", Rate = 1.0m },
                new ExchangeRate { FromCurrency = "UAH", ToCurrency = "EUR", Rate = 0.025m },
                new ExchangeRate { FromCurrency = "USD", ToCurrency = "EUR", Rate = 0.93m }
            };
        }

        private void LoadAllProducts()
        {
            _warehouseProducts.Clear();

            // Find all product files
            var productFiles = Directory.GetFiles(_dataDirectory, "*_products.json");

            foreach (var file in productFiles)
            {
                try
                {
                    var json = File.ReadAllText(file);
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var products = JsonSerializer.Deserialize<List<Product>>(json, options) ?? new List<Product>();

                    // Extract warehouse name from filename
                    var fileName = Path.GetFileNameWithoutExtension(file);
                    var warehouseName = fileName.Replace("_products", "");

                    // Set warehouse name for each product
                    foreach (var product in products)
                    {
                        product.WarehouseName = warehouseName;
                    }

                    _warehouseProducts[warehouseName] = products;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading products from {file}: {ex.Message}");
                }
            }
        }

        private void SaveWarehouseProducts(string warehouseName)
        {
            if (_warehouseProducts.ContainsKey(warehouseName))
            {
                try
                {
                    var filePath = Path.Combine(_dataDirectory, $"{warehouseName}_products.json");
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    var json = JsonSerializer.Serialize(_warehouseProducts[warehouseName], options);
                    File.WriteAllText(filePath, json);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error saving products for warehouse '{warehouseName}': {ex.Message}", ex);
                }
            }
        }

        public decimal ConvertCurrency(decimal amount, string fromCurrency, string toCurrency)
        {
            if (fromCurrency == toCurrency) return amount;

            // Try direct rate
            var directRate = _exchangeRates.FirstOrDefault(er =>
                er.FromCurrency.Equals(fromCurrency, StringComparison.OrdinalIgnoreCase) &&
                er.ToCurrency.Equals(toCurrency, StringComparison.OrdinalIgnoreCase));

            if (directRate != null)
                return amount * directRate.Rate;

            // Try reverse rate
            var reverseRate = _exchangeRates.FirstOrDefault(er =>
                er.FromCurrency.Equals(toCurrency, StringComparison.OrdinalIgnoreCase) &&
                er.ToCurrency.Equals(fromCurrency, StringComparison.OrdinalIgnoreCase));

            if (reverseRate != null)
                return amount / reverseRate.Rate;

            // Convert through base currency (EUR)
            var toBase = _exchangeRates.FirstOrDefault(er =>
                er.FromCurrency.Equals(fromCurrency, StringComparison.OrdinalIgnoreCase) &&
                er.ToCurrency.Equals(BASE_CURRENCY, StringComparison.OrdinalIgnoreCase));

            var fromBase = _exchangeRates.FirstOrDefault(er =>
                er.FromCurrency.Equals(BASE_CURRENCY, StringComparison.OrdinalIgnoreCase) &&
                er.ToCurrency.Equals(toCurrency, StringComparison.OrdinalIgnoreCase));

            if (toBase != null && fromBase != null)
                return amount * toBase.Rate * fromBase.Rate;

            // Default: no conversion
            return amount;
        }

        public List<Product> GetProductsByWarehouse(string warehouseName)
        {
            return _warehouseProducts.ContainsKey(warehouseName)
                ? _warehouseProducts[warehouseName].ToList()
                : new List<Product>();
        }

        public List<Product> GetProductsByWarehouseAndGroup(string warehouseName, string group)
        {
            if (!_warehouseProducts.ContainsKey(warehouseName))
                return new List<Product>();

            return _warehouseProducts[warehouseName]
                .Where(p => p.Group == group)
                .ToList();
        }

        public List<string> GetGroupsByWarehouse(string warehouseName)
        {
            if (!_warehouseProducts.ContainsKey(warehouseName))
                return new List<string>();

            return _warehouseProducts[warehouseName]
                .Select(p => p.Group)
                .Distinct()
                .OrderBy(g => g)
                .ToList();
        }

        public void AddProductToWarehouse(string warehouseName, Product product)
        {
            if (!_warehouseProducts.ContainsKey(warehouseName))
            {
                _warehouseProducts[warehouseName] = new List<Product>();
            }

            // Set warehouse name
            product.WarehouseName = warehouseName;

            // Convert price to base currency (EUR) for storage
            if (!string.IsNullOrEmpty(product.OriginalCurrency) &&
                !product.OriginalCurrency.Equals(BASE_CURRENCY, StringComparison.OrdinalIgnoreCase))
            {
                product.BasePrice = ConvertCurrency(product.BasePrice, product.OriginalCurrency, BASE_CURRENCY);
            }
            else if (string.IsNullOrEmpty(product.OriginalCurrency))
            {
                product.OriginalCurrency = "UAH"; // Default currency
                product.BasePrice = ConvertCurrency(product.BasePrice, "UAH", BASE_CURRENCY);
            }

            // Generate unique ID
            var warehouseProducts = _warehouseProducts[warehouseName];
            product.Id = warehouseProducts.Count > 0
                ? warehouseProducts.Max(p => p.Id) + 1
                : 1;

            product.Date = DateTime.Now;

            warehouseProducts.Add(product);
            SaveWarehouseProducts(warehouseName);
        }

        public void UpdateProductInWarehouse(string warehouseName, Product product)
        {
            if (!_warehouseProducts.ContainsKey(warehouseName))
                return;

            var warehouseProducts = _warehouseProducts[warehouseName];
            var existing = warehouseProducts.FirstOrDefault(p => p.Id == product.Id);

            if (existing != null)
            {
                // Update fields
                existing.Group = product.Group;
                existing.Name = product.Name;
                existing.Manufacturer = product.Manufacturer;
                existing.Supplier = product.Supplier;
                existing.Unit = product.Unit;

                // Handle currency conversion
                if (product.OriginalCurrency != existing.OriginalCurrency ||
                    product.BasePrice != existing.BasePrice)
                {
                    if (!string.IsNullOrEmpty(product.OriginalCurrency) &&
                        !product.OriginalCurrency.Equals(BASE_CURRENCY, StringComparison.OrdinalIgnoreCase))
                    {
                        existing.BasePrice = ConvertCurrency(product.BasePrice, product.OriginalCurrency, BASE_CURRENCY);
                        existing.OriginalCurrency = product.OriginalCurrency;
                    }
                    else
                    {
                        existing.BasePrice = product.BasePrice;
                        existing.OriginalCurrency = product.OriginalCurrency;
                    }
                }

                existing.Quantity = product.Quantity;

                SaveWarehouseProducts(warehouseName);
            }
        }

        public void DeleteProductFromWarehouse(string warehouseName, int productId)
        {
            if (!_warehouseProducts.ContainsKey(warehouseName))
                return;

            var warehouseProducts = _warehouseProducts[warehouseName];
            var product = warehouseProducts.FirstOrDefault(p => p.Id == productId);

            if (product != null)
            {
                warehouseProducts.Remove(product);
                SaveWarehouseProducts(warehouseName);
            }
        }

        public void DeleteProductsByWarehouseAndGroup(string warehouseName, string group)
        {
            if (!_warehouseProducts.ContainsKey(warehouseName))
                return;

            var warehouseProducts = _warehouseProducts[warehouseName];
            var productsToRemove = warehouseProducts
                .Where(p => p.Group == group)
                .ToList();

            foreach (var product in productsToRemove)
            {
                warehouseProducts.Remove(product);
            }

            if (productsToRemove.Count > 0)
            {
                SaveWarehouseProducts(warehouseName);
            }
        }

        public void UpdateProductGroupInWarehouse(string warehouseName, string oldGroup, string newGroup)
        {
            if (!_warehouseProducts.ContainsKey(warehouseName))
                return;

            var warehouseProducts = _warehouseProducts[warehouseName];
            var productsToUpdate = warehouseProducts
                .Where(p => p.Group == oldGroup)
                .ToList();

            foreach (var product in productsToUpdate)
            {
                product.Group = newGroup;
            }

            if (productsToUpdate.Count > 0)
            {
                SaveWarehouseProducts(warehouseName);
            }
        }

        public List<Product> GetProductsByWarehouseWithCurrency(string warehouseName, string targetCurrency)
        {
            if (!_warehouseProducts.ContainsKey(warehouseName))
                return new List<Product>();

            var result = new List<Product>();
            foreach (var product in _warehouseProducts[warehouseName])
            {
                var displayPrice = ConvertCurrency(product.BasePrice, BASE_CURRENCY, targetCurrency);

                var productCopy = new Product
                {
                    Id = product.Id,
                    WarehouseName = product.WarehouseName,
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

                result.Add(productCopy);
            }

            return result;
        }

        public List<Product> GetProductsByWarehouseAndGroupWithCurrency(string warehouseName, string group, string targetCurrency)
        {
            if (!_warehouseProducts.ContainsKey(warehouseName))
                return new List<Product>();

            var result = new List<Product>();
            foreach (var product in _warehouseProducts[warehouseName].Where(p => p.Group == group))
            {
                var displayPrice = ConvertCurrency(product.BasePrice, BASE_CURRENCY, targetCurrency);

                var productCopy = new Product
                {
                    Id = product.Id,
                    WarehouseName = product.WarehouseName,
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

                result.Add(productCopy);
            }

            return result;
        }

        public void SaveAllChanges()
        {
            foreach (var warehouseName in _warehouseProducts.Keys)
            {
                SaveWarehouseProducts(warehouseName);
            }

            // Save exchange rates
            var exchangeRatesFile = Path.Combine(_dataDirectory, "exchange_rates.json");
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(_exchangeRates, options);
            File.WriteAllText(exchangeRatesFile, json);
        }
    }
}