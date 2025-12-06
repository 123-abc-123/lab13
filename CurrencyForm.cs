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

            if (cmbCurrency.Items.Contains(currentCurrency))
            {
                cmbCurrency.SelectedItem = currentCurrency;
            }
            else if (cmbCurrency.Items.Count > 0)
            {
                cmbCurrency.SelectedIndex = 0;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedCurrency = cmbCurrency.SelectedItem?.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Nothing to do here - form will close with Cancel result
        }
    }
}