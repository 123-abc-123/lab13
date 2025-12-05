using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace lab13
{
    public partial class SearchForm : Form
    {
        public List<SearchCondition> Conditions { get; private set; }

        public SearchForm()
        {
            InitializeComponent();
            Conditions = new List<SearchCondition>();
            InitializeFields();
        }

        private void InitializeFields()
        {
            cmbField.Items.AddRange(new string[] {
                "Group", "Name", "Manufacturer", "Supplier",
                "Unit", "Price", "Quantity"
            });

            cmbOperator.Items.AddRange(new string[] {
                "=", "!=", ">", "<", ">=", "<=", "Contains", "StartsWith"
            });

            cmbField.SelectedIndex = 0;
            cmbOperator.SelectedIndex = 0;
        }

        private void btnAddCondition_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtValue.Text))
            {
                MessageBox.Show("Please enter a value for the condition.");
                return;
            }

            var condition = new SearchCondition
            {
                Field = cmbField.SelectedItem.ToString(),
                Operator = cmbOperator.SelectedItem.ToString(),
                Value = txtValue.Text
            };

            Conditions.Add(condition);
            UpdateConditionsList();
            txtValue.Clear();
        }

        private void UpdateConditionsList()
        {
            lstConditions.Items.Clear();
            foreach (var condition in Conditions)
            {
                lstConditions.Items.Add($"{condition.Field} {condition.Operator} '{condition.Value}'");
            }
        }

        private void btnRemoveCondition_Click(object sender, EventArgs e)
        {
            if (lstConditions.SelectedIndex >= 0)
            {
                Conditions.RemoveAt(lstConditions.SelectedIndex);
                UpdateConditionsList();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    public class SearchCondition
    {
        public string Field { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }
    }
}