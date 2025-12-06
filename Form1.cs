using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using lab13.Models;
using lab13.Repositories;

namespace lab13
{
    public partial class Form1 : Form
    {
        private IWarehouseRepository _warehouseRepository;
        private IProductRepository _productRepository;
        private Warehouse _currentWarehouse;
        private string _currentDisplayCurrency = "UAH";
        private string _currentGroupFilter = null;

        // Helper class for display
        private class ProductDisplayItem
        {
            public int RowNumber { get; set; }
            public Product Product { get; set; }

            public string Group => Product.Group;
            public string Name => Product.Name;
            public string Manufacturer => Product.Manufacturer;
            public string Supplier => Product.Supplier;
            public string Unit => Product.Unit;
            public decimal Price => Product.DisplayPrice;
            public string Currency => Product.DisplayCurrency;
            public int Quantity => Product.Quantity;
            public decimal TotalValue => Product.TotalValue;
            public DateTime Date => Product.Date;
        }

        private BindingList<ProductDisplayItem> _displayItems;

        public Form1()
        {
            InitializeComponent();
            InitializeRepositories();
            LoadWarehouseTree();
            InitializeComboBoxes();
        }

        private void InitializeRepositories()
        {
            _warehouseRepository = new WarehouseFileRepository();
            _productRepository = new ProductFileRepository();
        }

        private void InitializeComboBoxes()
        {
            cmbGroup.Items.AddRange(new string[] { "Книги", "Електроніка", "Одяг", "Продукти", "Меблі" });
            cmbSupplier.Items.AddRange(new string[] { "ТзОВ 'Інтерсервіс'", "Приватне підприємство 'Магазин'", "ТОВ 'Дистриб' " });
            cmbUnit.Items.AddRange(new string[] { "шт.", "кг", "л", "м", "уп." });
            cmbCurrency.Items.AddRange(new string[] { "UAH", "USD", "EUR" });

            cmbGroup.SelectedIndex = 0;
            cmbSupplier.SelectedIndex = 0;
            cmbUnit.SelectedIndex = 0;
            cmbCurrency.SelectedIndex = 0;
        }

        private void LoadWarehouseTree()
        {
            treeViewWarehouses.Nodes.Clear();

            var allWarehouses = _warehouseRepository.GetAllWarehouses();

            foreach (var warehouse in allWarehouses)
            {
                int productCount = _productRepository.GetProductsByWarehouse(warehouse.Name).Count;
                TreeNode warehouseNode = new TreeNode($"{warehouse.Name} ({productCount})");
                warehouseNode.Tag = $"Warehouse:{warehouse.Name}";
                warehouseNode.ImageKey = "warehouse";
                warehouseNode.SelectedImageKey = "warehouse";

                // Add groups as child nodes
                var groups = _productRepository.GetGroupsByWarehouse(warehouse.Name);
                foreach (var group in groups)
                {
                    int groupProductCount = _productRepository.GetProductsByWarehouseAndGroup(warehouse.Name, group).Count;
                    TreeNode groupNode = new TreeNode($"{group} ({groupProductCount})");
                    groupNode.Tag = $"Group:{warehouse.Name}:{group}";
                    groupNode.ImageKey = "group";
                    groupNode.SelectedImageKey = "group";
                    warehouseNode.Nodes.Add(groupNode);
                }

                treeViewWarehouses.Nodes.Add(warehouseNode);
            }

            treeViewWarehouses.ExpandAll();

            // Select first warehouse if exists
            if (treeViewWarehouses.Nodes.Count > 0)
            {
                treeViewWarehouses.SelectedNode = treeViewWarehouses.Nodes[0];
                SwitchToWarehouse(GetWarehouseNameFromNode(treeViewWarehouses.Nodes[0]));
            }
        }

        private string GetWarehouseNameFromNode(TreeNode node)
        {
            if (node.Tag != null && node.Tag.ToString().StartsWith("Warehouse:"))
            {
                return node.Tag.ToString().Substring("Warehouse:".Length);
            }
            return null;
        }

        private void SwitchToWarehouse(string warehouseName, string groupFilter = null)
        {
            _currentWarehouse = _warehouseRepository.GetWarehouse(warehouseName);
            _currentGroupFilter = groupFilter;

            if (_currentWarehouse != null)
            {
                lblCurrentWarehouse.Text = $"Склад: {warehouseName}";
                if (!string.IsNullOrEmpty(groupFilter))
                {
                    lblCurrentWarehouse.Text += $" → {groupFilter}";
                }

                LoadProducts();
                InitializeDataGridView();
            }
        }

        private void LoadProducts()
        {
            if (_currentWarehouse != null)
            {
                List<Product> products;

                if (string.IsNullOrEmpty(_currentGroupFilter))
                {
                    products = _productRepository.GetProductsByWarehouseWithCurrency(
                        _currentWarehouse.Name,
                        _currentDisplayCurrency
                    );
                }
                else
                {
                    products = _productRepository.GetProductsByWarehouseAndGroupWithCurrency(
                        _currentWarehouse.Name,
                        _currentGroupFilter,
                        _currentDisplayCurrency
                    );
                }

                _displayItems = new BindingList<ProductDisplayItem>(
                    products.Select((p, index) => new ProductDisplayItem
                    {
                        RowNumber = index + 1,
                        Product = p
                    }).ToList()
                );
            }
        }

        private void InitializeDataGridView()
        {
            dataGridView1.DataSource = _displayItems;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;

            dataGridView1.Columns.Clear();

            // Add columns
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RowNumber",
                HeaderText = "№ п/п",
                ReadOnly = true,
                Width = 50
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Group",
                HeaderText = "Група"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Назва"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Manufacturer",
                HeaderText = "Виробник"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Supplier",
                HeaderText = "Постачальник"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Unit",
                HeaderText = "Од. виміру"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Price",
                HeaderText = "Ціна",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Currency",
                HeaderText = "Валюта",
                Width = 60
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Кількість",
                Width = 70
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalValue",
                HeaderText = "Вартість",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Date",
                HeaderText = "Дата",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" },
                Width = 80
            });
        }

        private void RefreshDataGrid()
        {
            LoadProducts();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _displayItems;
        }

        private void btnAddToTable_Click(object sender, EventArgs e)
        {
            if (_currentWarehouse == null)
            {
                MessageBox.Show("Оберіть склад спочатку.", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtManufacturer.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Будь ласка, заповніть усі обов'язкові поля.", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) ||
                !int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Ціна та кількість мають бути числовими значеннями.", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var product = new Product
            {
                Group = cmbGroup.SelectedItem?.ToString() ?? "",
                Name = txtName.Text,
                Manufacturer = txtManufacturer.Text,
                Supplier = cmbSupplier.SelectedItem?.ToString() ?? "",
                Unit = cmbUnit.SelectedItem?.ToString() ?? "",
                BasePrice = price,
                OriginalCurrency = cmbCurrency.SelectedItem?.ToString() ?? "",
                Quantity = quantity
            };

            _productRepository.AddProductToWarehouse(_currentWarehouse.Name, product);
            RefreshDataGrid();
            ClearInputFields();

            UpdateWarehouseTree();
        }

        private void ClearInputFields()
        {
            cmbGroup.SelectedIndex = -1;
            txtName.Clear();
            txtManufacturer.Clear();
            cmbSupplier.SelectedIndex = -1;
            cmbUnit.SelectedIndex = -1;
            txtPrice.Clear();
            cmbCurrency.SelectedIndex = -1;
            txtQuantity.Clear();
        }

        private void UpdateWarehouseTree()
        {
            LoadWarehouseTree();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create image list for tree view
            ImageList imageList = new ImageList();
            imageList.Images.Add("warehouse", SystemIcons.Shield);
            imageList.Images.Add("group", SystemIcons.Asterisk);
            treeViewWarehouses.ImageList = imageList;
        }

        private void treeViewWarehouses_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Tag != null)
            {
                string tag = e.Node.Tag.ToString();
                if (tag.StartsWith("Warehouse:"))
                {
                    string warehouseName = tag.Substring("Warehouse:".Length);
                    SwitchToWarehouse(warehouseName);
                }
                else if (tag.StartsWith("Group:"))
                {
                    string[] parts = tag.Substring("Group:".Length).Split(':');
                    if (parts.Length == 2)
                    {
                        string warehouseName = parts[0];
                        string groupName = parts[1];
                        SwitchToWarehouse(warehouseName, groupName);
                    }
                }
            }
        }

        private void btnNewWarehouse_Click(object sender, EventArgs e)
        {
            AddNewWarehouse();
        }

        private void додатиСкладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewWarehouse();
        }

        private void AddNewWarehouse()
        {
            using (var dialog = new Form())
            {
                dialog.Text = "Новий склад";
                dialog.Size = new Size(400, 200);
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;

                Label nameLabel = new Label() { Text = "Назва складу:", Left = 20, Top = 20, Width = 100 };
                TextBox nameTextBox = new TextBox() { Left = 130, Top = 20, Width = 230 };

                Label locationLabel = new Label() { Text = "Розташування:", Left = 20, Top = 50, Width = 100 };
                TextBox locationTextBox = new TextBox() { Left = 130, Top = 50, Width = 230 };

                Label descLabel = new Label() { Text = "Опис:", Left = 20, Top = 80, Width = 100 };
                TextBox descTextBox = new TextBox() { Left = 130, Top = 80, Width = 230 };

                Button okButton = new Button() { Text = "OK", Left = 130, Top = 120, Width = 75 };
                Button cancelButton = new Button() { Text = "Скасувати", Left = 210, Top = 120, Width = 75 };

                okButton.Click += (s, ev) => { dialog.DialogResult = DialogResult.OK; };
                cancelButton.Click += (s, ev) => { dialog.DialogResult = DialogResult.Cancel; };

                dialog.Controls.AddRange(new Control[] {
                    nameLabel, nameTextBox,
                    locationLabel, locationTextBox,
                    descLabel, descTextBox,
                    okButton, cancelButton
                });

                if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(nameTextBox.Text))
                {
                    string warehouseName = nameTextBox.Text.Trim();
                    try
                    {
                        var newWarehouse = new Warehouse(warehouseName)
                        {
                            Location = locationTextBox.Text.Trim(),
                            Description = descTextBox.Text.Trim()
                        };

                        _warehouseRepository.CreateWarehouse(newWarehouse);
                        UpdateWarehouseTree();

                        MessageBox.Show($"Склад '{warehouseName}' успішно створений.", "Успіх",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, "Помилка",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка при створенні складу: {ex.Message}", "Помилка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void видалитиСкладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewWarehouses.SelectedNode != null &&
                treeViewWarehouses.SelectedNode.Tag != null &&
                treeViewWarehouses.SelectedNode.Tag.ToString().StartsWith("Warehouse:"))
            {
                string tag = treeViewWarehouses.SelectedNode.Tag.ToString();
                string warehouseName = tag.Substring("Warehouse:".Length);

                if (warehouseName == "Головний")
                {
                    MessageBox.Show("Не можна видалити головний склад.", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show($"Видалити склад '{warehouseName}' та всі його продукти?\nЦя дія незворотна!",
                    "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Delete the warehouse (products file will be deleted automatically)
                        _warehouseRepository.DeleteWarehouse(warehouseName);
                        UpdateWarehouseTree();

                        // Switch to main warehouse if we were on the deleted one
                        if (_currentWarehouse != null && _currentWarehouse.Name == warehouseName)
                        {
                            SwitchToWarehouse("Головний");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка при видаленні складу: {ex.Message}", "Помилка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void перейменуватиСкладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewWarehouses.SelectedNode != null &&
                treeViewWarehouses.SelectedNode.Tag != null &&
                treeViewWarehouses.SelectedNode.Tag.ToString().StartsWith("Warehouse:"))
            {
                string tag = treeViewWarehouses.SelectedNode.Tag.ToString();
                string oldName = tag.Substring("Warehouse:".Length);

                if (oldName == "Головний")
                {
                    MessageBox.Show("Не можна перейменувати головний склад.", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ask for new name
                string newName = ShowInputDialog("Перейменувати склад", "Нова назва складу:", oldName);

                if (!string.IsNullOrEmpty(newName) && newName != oldName)
                {
                    try
                    {
                        // Get all products from the old warehouse
                        var products = _productRepository.GetProductsByWarehouse(oldName);

                        if (products.Count > 0)
                        {
                            var result = MessageBox.Show($"Склад '{oldName}' містить {products.Count} продуктів.\n" +
                                                        "Перейменувати склад та перенести всі продукти?",
                                                        "Підтвердження",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);

                            if (result != DialogResult.Yes)
                            {
                                return;
                            }
                        }

                        // Create new warehouse
                        var oldWarehouse = _warehouseRepository.GetWarehouse(oldName);
                        var newWarehouse = new Warehouse(newName)
                        {
                            Location = oldWarehouse.Location,
                            Description = oldWarehouse.Description,
                            CreatedDate = oldWarehouse.CreatedDate
                        };

                        // Create new warehouse (creates empty products file)
                        _warehouseRepository.CreateWarehouse(newWarehouse);

                        // Move all products to new warehouse
                        foreach (var product in products)
                        {
                            // Create a copy of the product for the new warehouse
                            var newProduct = new Product
                            {
                                Group = product.Group,
                                Name = product.Name,
                                Manufacturer = product.Manufacturer,
                                Supplier = product.Supplier,
                                Unit = product.Unit,
                                BasePrice = product.BasePrice,
                                OriginalCurrency = product.OriginalCurrency,
                                Quantity = product.Quantity,
                                Date = product.Date
                            };

                            // Add to new warehouse
                            _productRepository.AddProductToWarehouse(newName, newProduct);
                        }

                        // Delete old warehouse (and its products file)
                        _warehouseRepository.DeleteWarehouse(oldName);

                        // Update current warehouse if needed
                        if (_currentWarehouse != null && _currentWarehouse.Name == oldName)
                        {
                            SwitchToWarehouse(newName);
                        }

                        // Update tree
                        UpdateWarehouseTree();

                        MessageBox.Show($"Склад успішно перейменовано з '{oldName}' на '{newName}'.\n" +
                                      $"Перенесено {products.Count} продуктів.", "Успіх",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, "Помилка",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка при перейменуванні: {ex.Message}", "Помилка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Helper method for input dialog
        private string ShowInputDialog(string title, string prompt, string defaultValue = "")
        {
            Form dialog = new Form()
            {
                Text = title,
                Size = new Size(300, 150),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label label = new Label() { Text = prompt, Left = 20, Top = 20, Width = 260 };
            TextBox textBox = new TextBox() { Left = 20, Top = 45, Width = 240, Text = defaultValue };
            Button okButton = new Button() { Text = "OK", Left = 80, Top = 80, Width = 75, DialogResult = DialogResult.OK };
            Button cancelButton = new Button() { Text = "Скасувати", Left = 160, Top = 80, Width = 75, DialogResult = DialogResult.Cancel };

            dialog.Controls.AddRange(new Control[] { label, textBox, okButton, cancelButton });
            dialog.AcceptButton = okButton;
            dialog.CancelButton = cancelButton;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return textBox.Text.Trim();
            }

            return null;
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _warehouseRepository.SaveAllWarehouses();
                if (_currentWarehouse != null)
                {
                    _productRepository.SaveWarehouseChanges(_currentWarehouse.Name);
                }
                MessageBox.Show("Дані успішно збережено.", "Успіх",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка збереження: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void завантажитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                InitializeRepositories();
                UpdateWarehouseTree();
                MessageBox.Show("Всі дані успішно завантажено.", "Успіх",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void видалитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && _currentWarehouse != null)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var displayItem = selectedRow.DataBoundItem as ProductDisplayItem;

                if (displayItem != null)
                {
                    var result = MessageBox.Show($"Видалити продукт '{displayItem.Name}' зі складу '{_currentWarehouse.Name}'?",
                        "Підтвердження",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        _productRepository.DeleteProductFromWarehouse(_currentWarehouse.Name, displayItem.Product.Id);
                        RefreshDataGrid();
                        UpdateWarehouseTree();
                    }
                }
            }
        }

        private void редагуватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && _currentWarehouse != null)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var displayItem = selectedRow.DataBoundItem as ProductDisplayItem;

                if (displayItem != null)
                {
                    var editForm = new EditForm(displayItem.Product, _productRepository, _currentWarehouse.Name);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        RefreshDataGrid();
                        UpdateWarehouseTree();
                    }
                }
            }
        }

        private void пошукToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var searchForm = new SearchForm();
            if (searchForm.ShowDialog() == DialogResult.OK)
            {
                ApplySearch(searchForm.Conditions);
            }
        }

        private void ApplySearch(List<SearchCondition> conditions)
        {
            if (_currentWarehouse == null) return;

            List<Product> allProducts;

            if (string.IsNullOrEmpty(_currentGroupFilter))
            {
                allProducts = _productRepository.GetProductsByWarehouseWithCurrency(
                    _currentWarehouse.Name,
                    _currentDisplayCurrency
                );
            }
            else
            {
                allProducts = _productRepository.GetProductsByWarehouseAndGroupWithCurrency(
                    _currentWarehouse.Name,
                    _currentGroupFilter,
                    _currentDisplayCurrency
                );
            }

            var filtered = allProducts.AsQueryable();

            foreach (var condition in conditions)
            {
                filtered = ApplyCondition(filtered, condition);
            }

            _displayItems = new BindingList<ProductDisplayItem>(
                filtered.Select((p, index) => new ProductDisplayItem
                {
                    RowNumber = index + 1,
                    Product = p
                }).ToList()
            );

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _displayItems;
        }

        private IQueryable<Product> ApplyCondition(IQueryable<Product> query, SearchCondition condition)
        {
            switch (condition.Field.ToLower())
            {
                case "name":
                    return ApplyStringCondition(query, p => p.Name, condition);
                case "group":
                    return ApplyStringCondition(query, p => p.Group, condition);
                case "manufacturer":
                    return ApplyStringCondition(query, p => p.Manufacturer, condition);
                case "quantity":
                    return ApplyNumericCondition(query, p => p.Quantity, condition);
                case "price":
                    return ApplyNumericCondition(query, p => p.DisplayPrice, condition);
                default:
                    return query;
            }
        }

        private IQueryable<Product> ApplyStringCondition(IQueryable<Product> query,
            Func<Product, string> selector, SearchCondition condition)
        {
            switch (condition.Operator)
            {
                case "=":
                    return query.Where(p => selector(p) == condition.Value);
                case "!=":
                    return query.Where(p => selector(p) != condition.Value);
                case "Contains":
                    return query.Where(p => selector(p).Contains(condition.Value));
                case "StartsWith":
                    return query.Where(p => selector(p).StartsWith(condition.Value));
                default:
                    return query;
            }
        }

        private IQueryable<Product> ApplyNumericCondition(IQueryable<Product> query,
            Func<Product, decimal> selector, SearchCondition condition)
        {
            if (!decimal.TryParse(condition.Value, out decimal value))
                return query;

            switch (condition.Operator)
            {
                case "=":
                    return query.Where(p => selector(p) == value);
                case "!=":
                    return query.Where(p => selector(p) != value);
                case ">":
                    return query.Where(p => selector(p) > value);
                case "<":
                    return query.Where(p => selector(p) < value);
                case ">=":
                    return query.Where(p => selector(p) >= value);
                case "<=":
                    return query.Where(p => selector(p) <= value);
                default:
                    return query;
            }
        }

        private void змінитиВалютуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currencyForm = new CurrencyForm(_currentDisplayCurrency);
            if (currencyForm.ShowDialog() == DialogResult.OK)
            {
                _currentDisplayCurrency = currencyForm.SelectedCurrency;
                RefreshDataGrid();
            }
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void курсиВалютToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Функція управління курсами валют буде реалізована окремо.", "Інформація",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void додатиРозділToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Групи створюються автоматично при додаванні продуктів.", "Інформація",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void видалитиРозділToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewWarehouses.SelectedNode != null &&
                treeViewWarehouses.SelectedNode.Parent != null &&
                treeViewWarehouses.SelectedNode.Tag != null &&
                treeViewWarehouses.SelectedNode.Tag.ToString().StartsWith("Group:"))
            {
                string tag = treeViewWarehouses.SelectedNode.Tag.ToString();
                string[] parts = tag.Substring("Group:".Length).Split(':');
                if (parts.Length == 2)
                {
                    string warehouseName = parts[0];
                    string groupName = parts[1];

                    var result = MessageBox.Show($"Видалити всі продукти групи '{groupName}' зі складу '{warehouseName}'?",
                        "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            _productRepository.DeleteProductsByWarehouseAndGroup(warehouseName, groupName);

                            if (_currentWarehouse != null && _currentWarehouse.Name == warehouseName)
                            {
                                if (_currentGroupFilter == groupName)
                                {
                                    _currentGroupFilter = null;
                                }
                                RefreshDataGrid();
                            }

                            UpdateWarehouseTree();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Помилка при видаленні групи: {ex.Message}", "Помилка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void перейменуватиРозділToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeViewWarehouses.SelectedNode != null &&
                treeViewWarehouses.SelectedNode.Parent != null &&
                treeViewWarehouses.SelectedNode.Tag != null &&
                treeViewWarehouses.SelectedNode.Tag.ToString().StartsWith("Group:"))
            {
                string tag = treeViewWarehouses.SelectedNode.Tag.ToString();
                string[] parts = tag.Substring("Group:".Length).Split(':');
                if (parts.Length == 2)
                {
                    string warehouseName = parts[0];
                    string oldGroupName = parts[1];

                    using (var dialog = new Form())
                    {
                        dialog.Text = "Перейменувати групу";
                        dialog.Size = new Size(300, 150);
                        dialog.StartPosition = FormStartPosition.CenterParent;

                        Label label = new Label() { Text = "Нова назва групи:", Left = 20, Top = 20, Width = 120 };
                        TextBox textBox = new TextBox() { Left = 140, Top = 20, Width = 130, Text = oldGroupName };
                        Button okButton = new Button() { Text = "OK", Left = 140, Top = 60, Width = 75 };
                        Button cancelButton = new Button() { Text = "Скасувати", Left = 215, Top = 60, Width = 75 };

                        okButton.Click += (s, ev) => { dialog.DialogResult = DialogResult.OK; };
                        cancelButton.Click += (s, ev) => { dialog.DialogResult = DialogResult.Cancel; };

                        dialog.Controls.Add(label);
                        dialog.Controls.Add(textBox);
                        dialog.Controls.Add(okButton);
                        dialog.Controls.Add(cancelButton);

                        if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(textBox.Text))
                        {
                            string newGroupName = textBox.Text.Trim();

                            if (newGroupName != oldGroupName)
                            {
                                try
                                {
                                    _productRepository.UpdateProductGroupInWarehouse(warehouseName, oldGroupName, newGroupName);

                                    if (_currentWarehouse != null && _currentWarehouse.Name == warehouseName)
                                    {
                                        if (_currentGroupFilter == oldGroupName)
                                        {
                                            _currentGroupFilter = newGroupName;
                                        }
                                        RefreshDataGrid();
                                    }

                                    UpdateWarehouseTree();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Помилка при перейменуванні групи: {ex.Message}", "Помилка",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}