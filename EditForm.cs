using System;
using System.Windows.Forms;
using lab13.Models;
using lab13.Repositories;

namespace lab13
{
    public partial class EditForm : Form
    {
        private Product _product;
        private IProductRepository _repository;
        private string _warehouseName;

        public EditForm(Product product, IProductRepository repository, string warehouseName)
        {
            InitializeComponent();
            _product = product;
            _repository = repository;
            _warehouseName = warehouseName;
            LoadProductData();
        }

        private void LoadProductData()
        {
            txtGroup.Text = _product.Group;
            txtName.Text = _product.Name;
            txtManufacturer.Text = _product.Manufacturer;
            txtSupplier.Text = _product.Supplier;
            txtUnit.Text = _product.Unit;
            txtPrice.Text = _product.BasePrice.ToString("N2");
            cmbCurrency.Text = _product.OriginalCurrency;
            txtQuantity.Text = _product.Quantity.ToString();
            txtWarehouse.Text = _warehouseName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    MessageBox.Show("Некоректний формат ціни", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtQuantity.Text, out int quantity))
                {
                    MessageBox.Show("Некоректний формат кількості", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var updatedProduct = new Product
                {
                    Id = _product.Id,
                    Group = txtGroup.Text,
                    Name = txtName.Text,
                    Manufacturer = txtManufacturer.Text,
                    Supplier = txtSupplier.Text,
                    Unit = txtUnit.Text,
                    BasePrice = price,
                    OriginalCurrency = cmbCurrency.Text,
                    Quantity = quantity
                };

                _repository.UpdateProductInWarehouse(_warehouseName, updatedProduct);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при збереженні змін: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}