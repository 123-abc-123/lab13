namespace lab13
{
    partial class SearchForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstConditions;
        private System.Windows.Forms.ComboBox cmbField;
        private System.Windows.Forms.ComboBox cmbOperator;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnAddCondition;
        private System.Windows.Forms.Button btnRemoveCondition;
        private System.Windows.Forms.Button btnClearConditions;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblField;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.Label lblValue;

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
            this.lstConditions = new System.Windows.Forms.ListBox();
            this.lblField = new System.Windows.Forms.Label();
            this.cmbField = new System.Windows.Forms.ComboBox();
            this.lblOperator = new System.Windows.Forms.Label();
            this.cmbOperator = new System.Windows.Forms.ComboBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnAddCondition = new System.Windows.Forms.Button();
            this.btnRemoveCondition = new System.Windows.Forms.Button();
            this.btnClearConditions = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstConditions
            // 
            this.lstConditions.FormattingEnabled = true;
            this.lstConditions.Location = new System.Drawing.Point(20, 20);
            this.lstConditions.Name = "lstConditions";
            this.lstConditions.Size = new System.Drawing.Size(460, 200);
            this.lstConditions.TabIndex = 0;
            // 
            // lblField
            // 
            this.lblField.AutoSize = true;
            this.lblField.Location = new System.Drawing.Point(20, 230);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(35, 13);
            this.lblField.TabIndex = 1;
            this.lblField.Text = "Поле:";
            // 
            // cmbField
            // 
            this.cmbField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbField.FormattingEnabled = true;
            this.cmbField.Items.AddRange(new object[] {
            "Name",
            "Group",
            "Manufacturer",
            "Quantity",
            "Price"});
            this.cmbField.Location = new System.Drawing.Point(70, 230);
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new System.Drawing.Size(100, 21);
            this.cmbField.TabIndex = 2;
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Location = new System.Drawing.Point(180, 230);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(56, 13);
            this.lblOperator.TabIndex = 3;
            this.lblOperator.Text = "Оператор:";
            // 
            // cmbOperator
            // 
            this.cmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperator.FormattingEnabled = true;
            this.cmbOperator.Items.AddRange(new object[] {
            "=",
            "!=",
            ">",
            "<",
            ">=",
            "<=",
            "Contains",
            "StartsWith"});
            this.cmbOperator.Location = new System.Drawing.Point(240, 230);
            this.cmbOperator.Name = "cmbOperator";
            this.cmbOperator.Size = new System.Drawing.Size(80, 21);
            this.cmbOperator.TabIndex = 4;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(330, 230);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(56, 13);
            this.lblValue.TabIndex = 5;
            this.lblValue.Text = "Значення:";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(390, 230);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(90, 20);
            this.txtValue.TabIndex = 6;
            // 
            // btnAddCondition
            // 
            this.btnAddCondition.Location = new System.Drawing.Point(20, 270);
            this.btnAddCondition.Name = "btnAddCondition";
            this.btnAddCondition.Size = new System.Drawing.Size(120, 23);
            this.btnAddCondition.TabIndex = 7;
            this.btnAddCondition.Text = "Додати умову";
            this.btnAddCondition.UseVisualStyleBackColor = true;
            this.btnAddCondition.Click += new System.EventHandler(this.btnAddCondition_Click);
            // 
            // btnRemoveCondition
            // 
            this.btnRemoveCondition.Location = new System.Drawing.Point(150, 270);
            this.btnRemoveCondition.Name = "btnRemoveCondition";
            this.btnRemoveCondition.Size = new System.Drawing.Size(120, 23);
            this.btnRemoveCondition.TabIndex = 8;
            this.btnRemoveCondition.Text = "Видалити умову";
            this.btnRemoveCondition.UseVisualStyleBackColor = true;
            this.btnRemoveCondition.Click += new System.EventHandler(this.btnRemoveCondition_Click);
            // 
            // btnClearConditions
            // 
            this.btnClearConditions.Location = new System.Drawing.Point(280, 270);
            this.btnClearConditions.Name = "btnClearConditions";
            this.btnClearConditions.Size = new System.Drawing.Size(100, 23);
            this.btnClearConditions.TabIndex = 9;
            this.btnClearConditions.Text = "Очистити всі";
            this.btnClearConditions.UseVisualStyleBackColor = true;
            this.btnClearConditions.Click += new System.EventHandler(this.btnClearConditions_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSearch.Location = new System.Drawing.Point(150, 320);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Пошук";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(260, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // SearchForm
            // 
            this.AcceptButton = this.btnSearch;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClearConditions);
            this.Controls.Add(this.btnRemoveCondition);
            this.Controls.Add(this.btnAddCondition);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.cmbOperator);
            this.Controls.Add(this.lblOperator);
            this.Controls.Add(this.cmbField);
            this.Controls.Add(this.lblField);
            this.Controls.Add(this.lstConditions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Пошук продуктів";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}