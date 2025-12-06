namespace lab13
{
    partial class PdfExportPreviewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxMetadata = new System.Windows.Forms.GroupBox();
            this.chkIncludeHeaders = new System.Windows.Forms.CheckBox();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.rdoLandscape = new System.Windows.Forms.RadioButton();
            this.rdoPortrait = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxPreview = new System.Windows.Forms.GroupBox();
            this.panelZoomControls = new System.Windows.Forms.Panel();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.lblZoomLevel = new System.Windows.Forms.Label();
            this.btnZoomFit = new System.Windows.Forms.Button();
            this.trackBarZoom = new System.Windows.Forms.TrackBar();
            this.panelPdfContainer = new System.Windows.Forms.Panel();
            this.panelPdfSimulation = new System.Windows.Forms.Panel();
            this.panelPdfContent = new System.Windows.Forms.Panel();
            this.panelGridContainer = new System.Windows.Forms.Panel();
            this.dataGridViewPreview = new System.Windows.Forms.DataGridView();
            this.panelPdfBorder = new System.Windows.Forms.Panel();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.mainLayout.SuspendLayout();
            this.groupBoxMetadata.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxPreview.SuspendLayout();
            this.panelZoomControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).BeginInit();
            this.panelPdfContainer.SuspendLayout();
            this.panelPdfSimulation.SuspendLayout();
            this.panelPdfContent.SuspendLayout();
            this.panelGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPreview)).BeginInit();
            this.panelPdfBorder.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.groupBoxMetadata, 0, 0);
            this.mainLayout.Controls.Add(this.groupBoxOptions, 0, 1);
            this.mainLayout.Controls.Add(this.groupBoxPreview, 0, 2);
            this.mainLayout.Controls.Add(this.panelButtons, 0, 3);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Margin = new System.Windows.Forms.Padding(2);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 4;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.mainLayout.Size = new System.Drawing.Size(825, 691);
            this.mainLayout.TabIndex = 0;
            // 
            // groupBoxMetadata
            // 
            this.groupBoxMetadata.Controls.Add(this.chkIncludeHeaders);
            this.groupBoxMetadata.Controls.Add(this.txtKeywords);
            this.groupBoxMetadata.Controls.Add(this.label4);
            this.groupBoxMetadata.Controls.Add(this.txtSubject);
            this.groupBoxMetadata.Controls.Add(this.label3);
            this.groupBoxMetadata.Controls.Add(this.txtAuthor);
            this.groupBoxMetadata.Controls.Add(this.label2);
            this.groupBoxMetadata.Controls.Add(this.txtTitle);
            this.groupBoxMetadata.Controls.Add(this.label1);
            this.groupBoxMetadata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMetadata.Location = new System.Drawing.Point(8, 8);
            this.groupBoxMetadata.Margin = new System.Windows.Forms.Padding(8);
            this.groupBoxMetadata.Name = "groupBoxMetadata";
            this.groupBoxMetadata.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxMetadata.Size = new System.Drawing.Size(809, 130);
            this.groupBoxMetadata.TabIndex = 0;
            this.groupBoxMetadata.TabStop = false;
            this.groupBoxMetadata.Text = "Метадані документа";
            // 
            // chkIncludeHeaders
            // 
            this.chkIncludeHeaders.AutoSize = true;
            this.chkIncludeHeaders.Checked = true;
            this.chkIncludeHeaders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeHeaders.Location = new System.Drawing.Point(135, 97);
            this.chkIncludeHeaders.Margin = new System.Windows.Forms.Padding(2);
            this.chkIncludeHeaders.Name = "chkIncludeHeaders";
            this.chkIncludeHeaders.Size = new System.Drawing.Size(177, 17);
            this.chkIncludeHeaders.TabIndex = 8;
            this.chkIncludeHeaders.Text = "Включати заголовки стовпців";
            this.chkIncludeHeaders.UseVisualStyleBackColor = true;
            this.chkIncludeHeaders.CheckedChanged += new System.EventHandler(this.chkIncludeHeaders_CheckedChanged);
            // 
            // txtKeywords
            // 
            this.txtKeywords.Location = new System.Drawing.Point(215, 73);
            this.txtKeywords.Margin = new System.Windows.Forms.Padding(2);
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.Size = new System.Drawing.Size(264, 20);
            this.txtKeywords.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(132, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ключові слова:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(215, 49);
            this.txtSubject.Margin = new System.Windows.Forms.Padding(2);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(264, 20);
            this.txtSubject.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 51);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Тема:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(215, 24);
            this.txtAuthor.Margin = new System.Windows.Forms.Padding(2);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(264, 20);
            this.txtAuthor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Автор:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(215, 0);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(2);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(264, 20);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Заголовок:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.rdoLandscape);
            this.groupBoxOptions.Controls.Add(this.rdoPortrait);
            this.groupBoxOptions.Controls.Add(this.label5);
            this.groupBoxOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxOptions.Location = new System.Drawing.Point(8, 154);
            this.groupBoxOptions.Margin = new System.Windows.Forms.Padding(8);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxOptions.Size = new System.Drawing.Size(809, 49);
            this.groupBoxOptions.TabIndex = 3;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Опції друку";
            // 
            // rdoLandscape
            // 
            this.rdoLandscape.AutoSize = true;
            this.rdoLandscape.Checked = true;
            this.rdoLandscape.Location = new System.Drawing.Point(172, 20);
            this.rdoLandscape.Margin = new System.Windows.Forms.Padding(2);
            this.rdoLandscape.Name = "rdoLandscape";
            this.rdoLandscape.Size = new System.Drawing.Size(98, 17);
            this.rdoLandscape.TabIndex = 2;
            this.rdoLandscape.TabStop = true;
            this.rdoLandscape.Text = "Альбомна (A4)";
            this.rdoLandscape.UseVisualStyleBackColor = true;
            this.rdoLandscape.CheckedChanged += new System.EventHandler(this.rdoLandscape_CheckedChanged);
            // 
            // rdoPortrait
            // 
            this.rdoPortrait.AutoSize = true;
            this.rdoPortrait.Location = new System.Drawing.Point(98, 20);
            this.rdoPortrait.Margin = new System.Windows.Forms.Padding(2);
            this.rdoPortrait.Name = "rdoPortrait";
            this.rdoPortrait.Size = new System.Drawing.Size(86, 17);
            this.rdoPortrait.TabIndex = 1;
            this.rdoPortrait.Text = "Книжна (A4)";
            this.rdoPortrait.UseVisualStyleBackColor = true;
            this.rdoPortrait.CheckedChanged += new System.EventHandler(this.rdoPortrait_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Орієнтація:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxPreview
            // 
            this.groupBoxPreview.Controls.Add(this.panelZoomControls);
            this.groupBoxPreview.Controls.Add(this.panelPdfContainer);
            this.groupBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPreview.Location = new System.Drawing.Point(8, 219);
            this.groupBoxPreview.Margin = new System.Windows.Forms.Padding(8);
            this.groupBoxPreview.Name = "groupBoxPreview";
            this.groupBoxPreview.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxPreview.Size = new System.Drawing.Size(809, 415);
            this.groupBoxPreview.TabIndex = 1;
            this.groupBoxPreview.TabStop = false;
            this.groupBoxPreview.Text = "Попередній перегляд PDF";
            // 
            // panelZoomControls
            // 
            this.panelZoomControls.BackColor = System.Drawing.SystemColors.Control;
            this.panelZoomControls.Controls.Add(this.btnZoomOut);
            this.panelZoomControls.Controls.Add(this.btnZoomIn);
            this.panelZoomControls.Controls.Add(this.lblZoomLevel);
            this.panelZoomControls.Controls.Add(this.btnZoomFit);
            this.panelZoomControls.Controls.Add(this.trackBarZoom);
            this.panelZoomControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelZoomControls.Location = new System.Drawing.Point(2, 376);
            this.panelZoomControls.Margin = new System.Windows.Forms.Padding(2);
            this.panelZoomControls.Name = "panelZoomControls";
            this.panelZoomControls.Size = new System.Drawing.Size(805, 37);
            this.panelZoomControls.TabIndex = 1;
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnZoomOut.Location = new System.Drawing.Point(172, 8);
            this.btnZoomOut.Margin = new System.Windows.Forms.Padding(2);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(30, 24);
            this.btnZoomOut.TabIndex = 4;
            this.btnZoomOut.Text = "-";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnZoomIn.Location = new System.Drawing.Point(135, 8);
            this.btnZoomIn.Margin = new System.Windows.Forms.Padding(2);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(30, 24);
            this.btnZoomIn.TabIndex = 3;
            this.btnZoomIn.Text = "+";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // lblZoomLevel
            // 
            this.lblZoomLevel.AutoSize = true;
            this.lblZoomLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblZoomLevel.Location = new System.Drawing.Point(210, 12);
            this.lblZoomLevel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblZoomLevel.Name = "lblZoomLevel";
            this.lblZoomLevel.Size = new System.Drawing.Size(39, 15);
            this.lblZoomLevel.TabIndex = 2;
            this.lblZoomLevel.Text = "100%";
            // 
            // btnZoomFit
            // 
            this.btnZoomFit.Location = new System.Drawing.Point(262, 8);
            this.btnZoomFit.Margin = new System.Windows.Forms.Padding(2);
            this.btnZoomFit.Name = "btnZoomFit";
            this.btnZoomFit.Size = new System.Drawing.Size(90, 24);
            this.btnZoomFit.TabIndex = 1;
            this.btnZoomFit.Text = "По ширині";
            this.btnZoomFit.UseVisualStyleBackColor = true;
            this.btnZoomFit.Click += new System.EventHandler(this.btnZoomFit_Click);
            // 
            // trackBarZoom
            // 
            this.trackBarZoom.LargeChange = 20;
            this.trackBarZoom.Location = new System.Drawing.Point(8, 8);
            this.trackBarZoom.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarZoom.Maximum = 400;
            this.trackBarZoom.Minimum = 10;
            this.trackBarZoom.Name = "trackBarZoom";
            this.trackBarZoom.Size = new System.Drawing.Size(120, 45);
            this.trackBarZoom.SmallChange = 10;
            this.trackBarZoom.TabIndex = 0;
            this.trackBarZoom.TickFrequency = 50;
            this.trackBarZoom.Value = 70;
            this.trackBarZoom.Scroll += new System.EventHandler(this.trackBarZoom_Scroll);
            // 
            // panelPdfContainer
            // 
            this.panelPdfContainer.AutoScroll = true;
            this.panelPdfContainer.BackColor = System.Drawing.Color.Gray;
            this.panelPdfContainer.Controls.Add(this.panelPdfSimulation);
            this.panelPdfContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPdfContainer.Location = new System.Drawing.Point(2, 15);
            this.panelPdfContainer.Margin = new System.Windows.Forms.Padding(2);
            this.panelPdfContainer.Name = "panelPdfContainer";
            this.panelPdfContainer.Size = new System.Drawing.Size(805, 398);
            this.panelPdfContainer.TabIndex = 0;
            this.panelPdfContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelPdfContainer_MouseDown);
            this.panelPdfContainer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelPdfContainer_MouseMove);
            this.panelPdfContainer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelPdfContainer_MouseUp);
            // 
            // panelPdfSimulation
            // 
            this.panelPdfSimulation.BackColor = System.Drawing.SystemColors.Window;
            this.panelPdfSimulation.Controls.Add(this.panelPdfContent);
            this.panelPdfSimulation.Controls.Add(this.panelPdfBorder);
            this.panelPdfSimulation.Location = new System.Drawing.Point(8, 8);
            this.panelPdfSimulation.Margin = new System.Windows.Forms.Padding(2);
            this.panelPdfSimulation.Name = "panelPdfSimulation";
            this.panelPdfSimulation.Size = new System.Drawing.Size(615, 422);
            this.panelPdfSimulation.TabIndex = 0;
            // 
            // panelPdfContent
            // 
            this.panelPdfContent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelPdfContent.BackColor = System.Drawing.Color.White;
            this.panelPdfContent.Controls.Add(this.panelGridContainer);
            this.panelPdfContent.Location = new System.Drawing.Point(8, 8);
            this.panelPdfContent.Margin = new System.Windows.Forms.Padding(2);
            this.panelPdfContent.Name = "panelPdfContent";
            this.panelPdfContent.Size = new System.Drawing.Size(600, 406);
            this.panelPdfContent.TabIndex = 2;
            // 
            // panelGridContainer
            // 
            this.panelGridContainer.Controls.Add(this.dataGridViewPreview);
            this.panelGridContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGridContainer.Location = new System.Drawing.Point(0, 0);
            this.panelGridContainer.Margin = new System.Windows.Forms.Padding(2);
            this.panelGridContainer.Name = "panelGridContainer";
            this.panelGridContainer.Padding = new System.Windows.Forms.Padding(8);
            this.panelGridContainer.Size = new System.Drawing.Size(600, 406);
            this.panelGridContainer.TabIndex = 2;
            // 
            // dataGridViewPreview
            // 
            this.dataGridViewPreview.AllowUserToAddRows = false;
            this.dataGridViewPreview.AllowUserToDeleteRows = false;
            this.dataGridViewPreview.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPreview.GridColor = System.Drawing.Color.Silver;
            this.dataGridViewPreview.Location = new System.Drawing.Point(8, 8);
            this.dataGridViewPreview.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewPreview.Name = "dataGridViewPreview";
            this.dataGridViewPreview.ReadOnly = true;
            this.dataGridViewPreview.RowHeadersWidth = 30;
            this.dataGridViewPreview.RowTemplate.Height = 24;
            this.dataGridViewPreview.Size = new System.Drawing.Size(584, 390);
            this.dataGridViewPreview.TabIndex = 1;
            // 
            // panelPdfBorder
            // 
            this.panelPdfBorder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelPdfBorder.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelPdfBorder.Controls.Add(this.lblPageSize);
            this.panelPdfBorder.Location = new System.Drawing.Point(0, 0);
            this.panelPdfBorder.Margin = new System.Windows.Forms.Padding(2);
            this.panelPdfBorder.Name = "panelPdfBorder";
            this.panelPdfBorder.Padding = new System.Windows.Forms.Padding(1);
            this.panelPdfBorder.Size = new System.Drawing.Size(615, 422);
            this.panelPdfBorder.TabIndex = 3;
            // 
            // lblPageSize
            // 
            this.lblPageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.BackColor = System.Drawing.Color.White;
            this.lblPageSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPageSize.ForeColor = System.Drawing.Color.Gray;
            this.lblPageSize.Location = new System.Drawing.Point(488, 4);
            this.lblPageSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(125, 13);
            this.lblPageSize.TabIndex = 0;
            this.lblPageSize.Text = "A4 (210×297 мм) - 100%";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnOk);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(2, 644);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(2);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(821, 45);
            this.panelButtons.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(721, 8);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(623, 8);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 28);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Експортувати";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // PdfExportPreviewForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(825, 691);
            this.Controls.Add(this.mainLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PdfExportPreviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Попередній перегляд експорту в PDF";
            this.Load += new System.EventHandler(this.PdfExportPreviewForm_Load);
            this.mainLayout.ResumeLayout(false);
            this.groupBoxMetadata.ResumeLayout(false);
            this.groupBoxMetadata.PerformLayout();
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.groupBoxPreview.ResumeLayout(false);
            this.panelZoomControls.ResumeLayout(false);
            this.panelZoomControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).EndInit();
            this.panelPdfContainer.ResumeLayout(false);
            this.panelPdfSimulation.ResumeLayout(false);
            this.panelPdfContent.ResumeLayout(false);
            this.panelGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPreview)).EndInit();
            this.panelPdfBorder.ResumeLayout(false);
            this.panelPdfBorder.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.GroupBox groupBoxMetadata;
        private System.Windows.Forms.CheckBox chkIncludeHeaders;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxPreview;
        private System.Windows.Forms.Panel panelPdfContainer;
        private System.Windows.Forms.Panel panelPdfSimulation;
        private System.Windows.Forms.Panel panelPdfBorder;
        private System.Windows.Forms.Panel panelPdfContent;
        private System.Windows.Forms.Panel panelGridContainer;
        private System.Windows.Forms.DataGridView dataGridViewPreview;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.RadioButton rdoLandscape;
        private System.Windows.Forms.RadioButton rdoPortrait;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelZoomControls;
        private System.Windows.Forms.TrackBar trackBarZoom;
        private System.Windows.Forms.Label lblZoomLevel;
        private System.Windows.Forms.Button btnZoomFit;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnZoomIn;
    }
}