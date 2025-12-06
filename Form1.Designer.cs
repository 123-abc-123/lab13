namespace lab13
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зберегтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.завантажитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.експортУPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.змінитиВалютуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.курсиВалютToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.вихідToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редагуватиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редагуватиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.видалитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пошукToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пошукToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnAddToTable = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewWarehouses = new System.Windows.Forms.TreeView();
            this.contextMenuStripTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.додатиСкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видалитиСкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перейменуватиСкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.додатиРозділToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видалитиРозділToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перейменуватиРозділToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNewWarehouse = new System.Windows.Forms.Button();
            this.lblCurrentWarehouse = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStripTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.редагуватиToolStripMenuItem,
            this.пошукToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(912, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.зберегтиToolStripMenuItem,
            this.завантажитиToolStripMenuItem,
            this.toolStripSeparator1,
            this.експортУPDFToolStripMenuItem,
            this.toolStripSeparator4,
            this.змінитиВалютуToolStripMenuItem,
            this.курсиВалютToolStripMenuItem,
            this.toolStripSeparator2,
            this.вихідToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(56, 22);
            this.файлToolStripMenuItem.Text = "📁 Файл";
            // 
            // зберегтиToolStripMenuItem
            // 
            this.зберегтиToolStripMenuItem.Name = "зберегтиToolStripMenuItem";
            this.зберегтиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.зберегтиToolStripMenuItem.Text = "💾 Зберегти";
            // 
            // завантажитиToolStripMenuItem
            // 
            this.завантажитиToolStripMenuItem.Name = "завантажитиToolStripMenuItem";
            this.завантажитиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.завантажитиToolStripMenuItem.Text = "📂 Завантажити";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // експортУPDFToolStripMenuItem
            // 
            this.експортУPDFToolStripMenuItem.Name = "експортУPDFToolStripMenuItem";
            this.експортУPDFToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.експортУPDFToolStripMenuItem.Text = "📄 Експорт у PDF";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // змінитиВалютуToolStripMenuItem
            // 
            this.змінитиВалютуToolStripMenuItem.Name = "змінитиВалютуToolStripMenuItem";
            this.змінитиВалютуToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.змінитиВалютуToolStripMenuItem.Text = "🔄 Змінити валюту";
            // 
            // курсиВалютToolStripMenuItem
            // 
            this.курсиВалютToolStripMenuItem.Name = "курсиВалютToolStripMenuItem";
            this.курсиВалютToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.курсиВалютToolStripMenuItem.Text = "💰 Курси валют";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // вихідToolStripMenuItem
            // 
            this.вихідToolStripMenuItem.Name = "вихідToolStripMenuItem";
            this.вихідToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.вихідToolStripMenuItem.Text = "🚪 Вихід";
            // 
            // редагуватиToolStripMenuItem
            // 
            this.редагуватиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.редагуватиToolStripMenuItem1,
            this.видалитиToolStripMenuItem});
            this.редагуватиToolStripMenuItem.Name = "редагуватиToolStripMenuItem";
            this.редагуватиToolStripMenuItem.Size = new System.Drawing.Size(87, 22);
            this.редагуватиToolStripMenuItem.Text = "✏️ Редагувати";
            // 
            // редагуватиToolStripMenuItem1
            // 
            this.редагуватиToolStripMenuItem1.Name = "редагуватиToolStripMenuItem1";
            this.редагуватиToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.редагуватиToolStripMenuItem1.Text = "📝 Редагувати запис";
            // 
            // видалитиToolStripMenuItem
            // 
            this.видалитиToolStripMenuItem.Name = "видалитиToolStripMenuItem";
            this.видалитиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.видалитиToolStripMenuItem.Text = "🗑️ Видалити запис";
            // 
            // пошукToolStripMenuItem
            // 
            this.пошукToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пошукToolStripMenuItem1});
            this.пошукToolStripMenuItem.Name = "пошукToolStripMenuItem";
            this.пошукToolStripMenuItem.Size = new System.Drawing.Size(66, 22);
            this.пошукToolStripMenuItem.Text = "🔍 Пошук";
            // 
            // пошукToolStripMenuItem1
            // 
            this.пошукToolStripMenuItem1.Name = "пошукToolStripMenuItem1";
            this.пошукToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.пошукToolStripMenuItem1.Text = "🔎 Пошук";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Location = new System.Drawing.Point(0, 442);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
            this.statusStrip1.Size = new System.Drawing.Size(912, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введіть нові дані у таблицю Склад:";
            // 
            // cmbGroup
            // 
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(11, 68);
            this.cmbGroup.Margin = new System.Windows.Forms.Padding(2);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(68, 21);
            this.cmbGroup.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(81, 68);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(81, 20);
            this.txtName.TabIndex = 4;
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Location = new System.Drawing.Point(165, 68);
            this.txtManufacturer.Margin = new System.Windows.Forms.Padding(2);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(81, 20);
            this.txtManufacturer.TabIndex = 5;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(249, 68);
            this.cmbSupplier.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(101, 21);
            this.cmbSupplier.TabIndex = 6;
            // 
            // cmbUnit
            // 
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(353, 68);
            this.cmbUnit.Margin = new System.Windows.Forms.Padding(2);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(48, 21);
            this.cmbUnit.TabIndex = 7;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(404, 68);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(55, 20);
            this.txtPrice.TabIndex = 8;
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(461, 68);
            this.cmbCurrency.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(48, 21);
            this.cmbCurrency.TabIndex = 9;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(512, 68);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(41, 20);
            this.txtQuantity.TabIndex = 10;
            // 
            // btnAddToTable
            // 
            this.btnAddToTable.Location = new System.Drawing.Point(557, 48);
            this.btnAddToTable.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddToTable.Name = "btnAddToTable";
            this.btnAddToTable.Size = new System.Drawing.Size(144, 41);
            this.btnAddToTable.TabIndex = 11;
            this.btnAddToTable.Text = "➕ Додати до таблиці";
            this.btnAddToTable.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 2);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(712, 347);
            this.dataGridView1.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(712, 349);
            this.panel1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Group";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Producer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(249, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Supplier";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(353, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Units";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(404, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Price";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(461, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Currency";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(512, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Quantity";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(0, 93);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewWarehouses);
            this.splitContainer1.Panel1.Controls.Add(this.btnNewWarehouse);
            this.splitContainer1.Panel1.Controls.Add(this.lblCurrentWarehouse);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(912, 349);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 22;
            // 
            // treeViewWarehouses
            // 
            this.treeViewWarehouses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewWarehouses.ContextMenuStrip = this.contextMenuStripTree;
            this.treeViewWarehouses.Location = new System.Drawing.Point(0, 25);
            this.treeViewWarehouses.Margin = new System.Windows.Forms.Padding(2);
            this.treeViewWarehouses.Name = "treeViewWarehouses";
            this.treeViewWarehouses.Size = new System.Drawing.Size(200, 324);
            this.treeViewWarehouses.TabIndex = 2;
            // 
            // contextMenuStripTree
            // 
            this.contextMenuStripTree.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.додатиСкладToolStripMenuItem,
            this.видалитиСкладToolStripMenuItem,
            this.перейменуватиСкладToolStripMenuItem,
            this.toolStripSeparator3,
            this.додатиРозділToolStripMenuItem,
            this.видалитиРозділToolStripMenuItem,
            this.перейменуватиРозділToolStripMenuItem});
            this.contextMenuStripTree.Name = "contextMenuStripTree";
            this.contextMenuStripTree.Size = new System.Drawing.Size(203, 148);
            // 
            // додатиСкладToolStripMenuItem
            // 
            this.додатиСкладToolStripMenuItem.Name = "додатиСкладToolStripMenuItem";
            this.додатиСкладToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.додатиСкладToolStripMenuItem.Text = "➕ Додати склад";
            // 
            // видалитиСкладToolStripMenuItem
            // 
            this.видалитиСкладToolStripMenuItem.Name = "видалитиСкладToolStripMenuItem";
            this.видалитиСкладToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.видалитиСкладToolStripMenuItem.Text = "🗑️ Видалити склад";
            // 
            // перейменуватиСкладToolStripMenuItem
            // 
            this.перейменуватиСкладToolStripMenuItem.Name = "перейменуватиСкладToolStripMenuItem";
            this.перейменуватиСкладToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.перейменуватиСкладToolStripMenuItem.Text = "✏️ Перейменувати склад";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(199, 6);
            // 
            // додатиРозділToolStripMenuItem
            // 
            this.додатиРозділToolStripMenuItem.Name = "додатиРозділToolStripMenuItem";
            this.додатиРозділToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.додатиРозділToolStripMenuItem.Text = "➕ Додати розділ";
            // 
            // видалитиРозділToolStripMenuItem
            // 
            this.видалитиРозділToolStripMenuItem.Name = "видалитиРозділToolStripMenuItem";
            this.видалитиРозділToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.видалитиРозділToolStripMenuItem.Text = "🗑️ Видалити розділ";
            // 
            // перейменуватиРозділToolStripMenuItem
            // 
            this.перейменуватиРозділToolStripMenuItem.Name = "перейменуватиРозділToolStripMenuItem";
            this.перейменуватиРозділToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.перейменуватиРозділToolStripMenuItem.Text = "✏️ Перейменувати розділ";
            // 
            // btnNewWarehouse
            // 
            this.btnNewWarehouse.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNewWarehouse.Location = new System.Drawing.Point(0, 0);
            this.btnNewWarehouse.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewWarehouse.Name = "btnNewWarehouse";
            this.btnNewWarehouse.Size = new System.Drawing.Size(200, 25);
            this.btnNewWarehouse.TabIndex = 1;
            this.btnNewWarehouse.Text = "➕ Новий склад";
            this.btnNewWarehouse.UseVisualStyleBackColor = true;
            // 
            // lblCurrentWarehouse
            // 
            this.lblCurrentWarehouse.AutoSize = true;
            this.lblCurrentWarehouse.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCurrentWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurrentWarehouse.Location = new System.Drawing.Point(0, 334);
            this.lblCurrentWarehouse.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentWarehouse.Name = "lblCurrentWarehouse";
            this.lblCurrentWarehouse.Padding = new System.Windows.Forms.Padding(2);
            this.lblCurrentWarehouse.Size = new System.Drawing.Size(95, 15);
            this.lblCurrentWarehouse.TabIndex = 0;
            this.lblCurrentWarehouse.Text = "Склад: Головний";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 464);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddToTable);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.cmbCurrency);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.txtManufacturer);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cmbGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "📦 Склад";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStripTree.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

            // In the InitializeComponent() method of Form1

            // File menu items
            this.зберегтиToolStripMenuItem.Click += new System.EventHandler(this.зберегтиToolStripMenuItem_Click);
            this.завантажитиToolStripMenuItem.Click += new System.EventHandler(this.завантажитиToolStripMenuItem_Click);
            this.експортУPDFToolStripMenuItem.Click += new System.EventHandler(this.ExportToPdfToolStripMenuItem_Click);
            this.змінитиВалютуToolStripMenuItem.Click += new System.EventHandler(this.змінитиВалютуToolStripMenuItem_Click);
            this.курсиВалютToolStripMenuItem.Click += new System.EventHandler(this.курсиВалютToolStripMenuItem_Click);
            this.вихідToolStripMenuItem.Click += new System.EventHandler(this.вихідToolStripMenuItem_Click);

            // Edit menu items
            this.редагуватиToolStripMenuItem1.Click += new System.EventHandler(this.редагуватиToolStripMenuItem_Click);
            this.видалитиToolStripMenuItem.Click += new System.EventHandler(this.видалитиToolStripMenuItem_Click);

            // Search menu
            this.пошукToolStripMenuItem1.Click += new System.EventHandler(this.пошукToolStripMenuItem_Click);

            // Context menu for tree view
            this.додатиСкладToolStripMenuItem.Click += new System.EventHandler(this.додатиСкладToolStripMenuItem_Click);
            this.видалитиСкладToolStripMenuItem.Click += new System.EventHandler(this.видалитиСкладToolStripMenuItem_Click);
            this.перейменуватиСкладToolStripMenuItem.Click += new System.EventHandler(this.перейменуватиСкладToolStripMenuItem_Click);
            this.додатиРозділToolStripMenuItem.Click += new System.EventHandler(this.додатиРозділToolStripMenuItem_Click);
            this.видалитиРозділToolStripMenuItem.Click += new System.EventHandler(this.видалитиРозділToolStripMenuItem_Click);
            this.перейменуватиРозділToolStripMenuItem.Click += new System.EventHandler(this.перейменуватиРозділToolStripMenuItem_Click);

            // Buttons
            this.btnAddToTable.Click += new System.EventHandler(this.btnAddToTable_Click);
            this.btnNewWarehouse.Click += new System.EventHandler(this.btnNewWarehouse_Click);

            // Tree view
            this.treeViewWarehouses.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewWarehouses_AfterSelect);
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зберегтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem завантажитиToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem експортУPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem змінитиВалютуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem курсиВалютToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem вихідToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редагуватиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редагуватиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem видалитиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пошукToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пошукToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnAddToTable;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewWarehouses;
        private System.Windows.Forms.Button btnNewWarehouse;
        private System.Windows.Forms.Label lblCurrentWarehouse;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTree;
        private System.Windows.Forms.ToolStripMenuItem додатиСкладToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видалитиСкладToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перейменуватиСкладToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem додатиРозділToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видалитиРозділToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перейменуватиРозділToolStripMenuItem;
    }
}