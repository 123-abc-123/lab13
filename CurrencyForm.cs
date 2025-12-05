using System;
using System.Windows.Forms;

namespace lab13
{
    public partial class CurrencyForm : Form
    {
        public string SelectedCurrency { get; private set; }

        public CurrencyForm(string currentCurrency)
        {
            InitializeComponent();
            cmbCurrency.Items.AddRange(new string[] { "UAH", "USD", "EUR" });
            cmbCurrency.SelectedItem = currentCurrency;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedCurrency = cmbCurrency.SelectedItem?.ToString() ?? "UAH";
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