using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using lab13.Models;
using lab13.Repositories;

namespace lab13
{
    public partial class Form1 : Form
    {
        private BindingList<Product> products;
        private FileRepository repository;
        private string currentDisplayCurrency = "UAH";

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

        private BindingList<ProductDisplayItem> displayItems;

        public Form1()
        {
            InitializeComponent();
            InitializeRepository();
            LoadProducts();
            InitializeDataGridView();
        }

        private void InitializeRepository()
        {
            repository = new FileRepository();
        }

        private void LoadProducts()
        {
            var productList = repository.GetAllWithCurrency(currentDisplayCurrency);
            displayItems = new BindingList<ProductDisplayItem>(
                productList.Select((p, index) => new ProductDisplayItem
                {
                    RowNumber = index + 1,
                    Product = p
                }).ToList()
            );
        }

        private void InitializeDataGridView()
        {
            dataGridView1.DataSource = displayItems;
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

        private void btnAddToTable_Click(object sender, EventArgs e)
        {
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

            repository.Add(product);
            RefreshDataGrid();
            ClearInputFields();
        }

        private void RefreshDataGrid()
        {
            LoadProducts();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = displayItems;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbGroup.Items.AddRange(new string[] { "Книги", "Електроніка", "Одяг" });
            cmbSupplier.Items.AddRange(new string[] { "ТзОВ 'Інтерсервіс'", "Приватне підприємство 'Магазин'", "ТОВ 'Дистриб' " });
            cmbUnit.Items.AddRange(new string[] { "шт.", "кг", "л" });
            cmbCurrency.Items.AddRange(new string[] { "UAH", "USD", "EUR" });

            cmbGroup.SelectedIndex = 0;
            cmbSupplier.SelectedIndex = 0;
            cmbUnit.SelectedIndex = 0;
            cmbCurrency.SelectedIndex = 0;
        }

        // Menu event handlers - FIXED NAMES
        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                repository.SaveChanges();
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
            RefreshDataGrid();
            MessageBox.Show("Дані успішно завантажено.", "Успіх",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // FIXED: Changed from видалитиЗаписToolStripMenuItem_Click to видалитиToolStripMenuItem_Click
        private void видалитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var displayItem = selectedRow.DataBoundItem as ProductDisplayItem;

                if (displayItem != null)
                {
                    var result = MessageBox.Show($"Видалити продукт '{displayItem.Name}'?",
                        "Підтвердження",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        repository.Delete(displayItem.Product.Id);
                        RefreshDataGrid();
                    }
                }
            }
        }

        // FIXED: Changed from редагуватиЗаписToolStripMenuItem_Click to редагуватиToolStripMenuItem_Click
        private void редагуватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var displayItem = selectedRow.DataBoundItem as ProductDisplayItem;

                if (displayItem != null)
                {
                    var editForm = new EditForm(displayItem.Product, repository);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        RefreshDataGrid();
                    }
                }
            }
        }

        // FIXED: Changed from пошукToolStripMenuItem1_Click to пошукToolStripMenuItem_Click
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
            var allProducts = repository.GetAllWithCurrency(currentDisplayCurrency);
            var filtered = allProducts.AsQueryable();

            foreach (var condition in conditions)
            {
                filtered = ApplyCondition(filtered, condition);
            }

            displayItems = new BindingList<ProductDisplayItem>(
                filtered.Select((p, index) => new ProductDisplayItem
                {
                    RowNumber = index + 1,
                    Product = p
                }).ToList()
            );

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = displayItems;
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
            var currencyForm = new CurrencyForm(currentDisplayCurrency);
            if (currencyForm.ShowDialog() == DialogResult.OK)
            {
                currentDisplayCurrency = currencyForm.SelectedCurrency;
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
    }
}