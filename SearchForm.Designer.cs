namespace lab13
{
    partial class SearchForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.ComboBox cmbField;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.ComboBox cmbOperator;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnAddCondition;
        private System.Windows.Forms.ListBox lstConditions;
        private System.Windows.Forms.Button btnRemoveCondition;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblField = new System.Windows.Forms.Label();
            this.cmbField = new System.Windows.Forms.ComboBox();
            this.lblOperator = new System.Windows.Forms.Label();
            this.cmbOperator = new System.Windows.Forms.ComboBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnAddCondition = new System.Windows.Forms.Button();
            this.lstConditions = new System.Windows.Forms.ListBox();
            this.btnRemoveCondition = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.Location = new System.Drawing.Point(8, 10);
            this.lblField.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(32, 13);
            this.lblField.TabIndex = 0;
            this.lblField.Text = "Field:";
            // 
            // cmbField
            // 
            this.cmbField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbField.FormattingEnabled = true;
            this.cmbField.Location = new System.Drawing.Point(41, 8);
            this.cmbField.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new System.Drawing.Size(101, 21);
            this.cmbField.TabIndex = 1;
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Location = new System.Drawing.Point(145, 10);
            this.lblOperator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(51, 13);
            this.lblOperator.TabIndex = 2;
            this.lblOperator.Text = "Operator:";
            // 
            // cmbOperator
            // 
            this.cmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperator.FormattingEnabled = true;
            this.cmbOperator.Location = new System.Drawing.Point(197, 8);
            this.cmbOperator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbOperator.Name = "cmbOperator";
            this.cmbOperator.Size = new System.Drawing.Size(68, 21);
            this.cmbOperator.TabIndex = 3;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(267, 10);
            this.lblValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(37, 13);
            this.lblValue.TabIndex = 4;
            this.lblValue.Text = "Value:";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(305, 8);
            this.txtValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(101, 20);
            this.txtValue.TabIndex = 5;
            // 
            // btnAddCondition
            // 
            this.btnAddCondition.Location = new System.Drawing.Point(409, 8);
            this.btnAddCondition.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddCondition.Name = "btnAddCondition";
            this.btnAddCondition.Size = new System.Drawing.Size(50, 21);
            this.btnAddCondition.TabIndex = 6;
            this.btnAddCondition.Text = "Add";
            this.btnAddCondition.UseVisualStyleBackColor = true;
            this.btnAddCondition.Click += new System.EventHandler(this.btnAddCondition_Click);
            // 
            // lstConditions
            // 
            this.lstConditions.FormattingEnabled = true;
            this.lstConditions.Location = new System.Drawing.Point(8, 45);
            this.lstConditions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstConditions.Name = "lstConditions";
            this.lstConditions.Size = new System.Drawing.Size(398, 95);
            this.lstConditions.TabIndex = 7;
            // 
            // btnRemoveCondition
            // 
            this.btnRemoveCondition.Location = new System.Drawing.Point(410, 45);
            this.btnRemoveCondition.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRemoveCondition.Name = "btnRemoveCondition";
            this.btnRemoveCondition.Size = new System.Drawing.Size(50, 23);
            this.btnRemoveCondition.TabIndex = 8;
            this.btnRemoveCondition.Text = "Remove";
            this.btnRemoveCondition.UseVisualStyleBackColor = true;
            this.btnRemoveCondition.Click += new System.EventHandler(this.btnRemoveCondition_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(8, 143);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 20);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(79, 143);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(67, 20);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 169);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRemoveCondition);
            this.Controls.Add(this.lstConditions);
            this.Controls.Add(this.btnAddCondition);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.cmbOperator);
            this.Controls.Add(this.lblOperator);
            this.Controls.Add(this.cmbField);
            this.Controls.Add(this.lblField);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search Products";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}