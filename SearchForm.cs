using System;
using System.Collections.Generic;
using System.Windows.Forms;
using lab13.Models;

namespace lab13
{
    public partial class SearchForm : Form
    {
        public List<SearchCondition> Conditions { get; private set; }
        private List<SearchCondition> _conditions;

        public SearchForm()
        {
            InitializeComponent();
            _conditions = new List<SearchCondition>();
        }

        private void btnAddCondition_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbField.Text) && !string.IsNullOrEmpty(cmbOperator.Text))
            {
                var condition = new SearchCondition
                {
                    Field = cmbField.Text,
                    Operator = cmbOperator.Text,
                    Value = txtValue.Text
                };
                _conditions.Add(condition);
                UpdateConditionsList();
            }
        }

        private void btnRemoveCondition_Click(object sender, EventArgs e)
        {
            if (lstConditions.SelectedIndex >= 0)
            {
                _conditions.RemoveAt(lstConditions.SelectedIndex);
                UpdateConditionsList();
            }
        }

        private void btnClearConditions_Click(object sender, EventArgs e)
        {
            _conditions.Clear();
            UpdateConditionsList();
        }

        private void UpdateConditionsList()
        {
            lstConditions.Items.Clear();
            foreach (var condition in _conditions)
            {
                lstConditions.Items.Add($"{condition.Field} {condition.Operator} '{condition.Value}'");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                Conditions = new List<SearchCondition>(_conditions);
            }
            base.OnFormClosing(e);
        }
    }
}