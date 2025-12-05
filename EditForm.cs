using System;
using System.Windows.Forms;
using lab13.Models;
using lab13.Repositories;

namespace lab13
{
    public partial class EditForm : Form
    {
        private Product product;
        private FileRepository repository;

        public EditForm(Product productToEdit, FileRepository repo)
        {
            InitializeComponent();
            product = productToEdit;
            repository = repo;
            LoadProductData();
        }

        private void LoadProductData()
        {
            txtName.Text = product.Name;
            txtManufacturer.Text = product.Manufacturer;
            txtPrice.Text = product.BasePrice.ToString();
            txtQuantity.Text = product.Quantity.ToString();

            cmbGroup.Items.AddRange(new string[] { "Книги", "Електроніка", "Одяг" });
            cmbSupplier.Items.AddRange(new string[] { "ТзОВ 'Інтерсервіс'", "Приватне підприємство 'Магазин'", "ТОВ 'Дистриб' " });
            cmbUnit.Items.AddRange(new string[] { "шт.", "кг", "л" });
            cmbCurrency.Items.AddRange(new string[] { "UAH", "USD", "EUR" });

            cmbGroup.SelectedItem = product.Group;
            cmbSupplier.SelectedItem = product.Supplier;
            cmbUnit.SelectedItem = product.Unit;
            cmbCurrency.SelectedItem = product.OriginalCurrency;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtPrice.Text, out decimal price) ||
                !int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Ціна та кількість мають бути числовими значеннями.", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            product.Name = txtName.Text;
            product.Manufacturer = txtManufacturer.Text;
            product.BasePrice = price;
            product.Quantity = quantity;
            product.Group = cmbGroup.SelectedItem?.ToString();
            product.Supplier = cmbSupplier.SelectedItem?.ToString();
            product.Unit = cmbUnit.SelectedItem?.ToString();
            product.OriginalCurrency = cmbCurrency.SelectedItem?.ToString();

            repository.Update(product);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}