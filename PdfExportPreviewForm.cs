using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using lab13.Models;

namespace lab13
{
    public partial class PdfExportPreviewForm : Form
    {
        public PdfMetadata Metadata { get; private set; }
        public bool IncludeHeaders { get; private set; } = true;
        public bool IsLandscape { get; private set; } = true;
        private List<Form1.ProductDisplayItem> _displayItems;
        private Warehouse _warehouse;
        private string _groupFilter;

        // PDF constants (A4 @96 DPI simulation)
        private const float MM_TO_INCH = 0.0393701f;
        private const float RENDER_DPI = 96f;
        private const float A4_WIDTH_MM = 210f;
        private const float A4_HEIGHT_MM = 297f;

        // Zoom & pan
        private float _zoomLevel = 0.7f;
        private Point _lastMousePos;
        private bool _isDragging = false;
        private Point _pdfOffset = new Point(10, 10);
        private float[] _zoomLevels = { 0.1f, 0.25f, 0.5f, 0.75f, 1.0f, 1.25f, 1.5f, 2.0f, 3.0f, 4.0f };
        private bool _isInitialized = false;

        // Reference to custom renderer
        private PdfPreviewRenderer _pdfRenderer;

        public PdfExportPreviewForm(Warehouse warehouse, List<Form1.ProductDisplayItem> displayItems, string groupFilter)
        {
            InitializeComponent();
            _warehouse = warehouse;
            _displayItems = displayItems;
            _groupFilter = groupFilter;
            InitializeMetadata();

            // Replace DataGridView with custom renderer
            InitializePdfRenderer();

            // Setup UI
            txtTitle.Text = Metadata.Title;
            txtAuthor.Text = Metadata.Author;
            txtSubject.Text = Metadata.Subject;
            txtKeywords.Text = Metadata.Keywords;
            chkIncludeHeaders.Checked = IncludeHeaders;
            rdoLandscape.Checked = IsLandscape;
            rdoPortrait.Checked = !IsLandscape;

            trackBarZoom.Value = (int)(_zoomLevel * 100);
            UpdateZoomLabel();
            panelPdfContainer.Cursor = Cursors.Hand;
        }

        private void InitializeMetadata()
        {
            Metadata = new PdfMetadata
            {
                Title = $"Звіт по складу: {_warehouse.Name}",
                Subject = $"Складова звітність",
                Keywords = $"склад, інвентаризація, {_warehouse.Name}",
                Author = Environment.UserName,
                WarehouseName = _warehouse.Name,
                GroupFilter = _groupFilter,
                ExportDate = DateTime.Now,
                DisplayItems = _displayItems,
                IsLandscape = IsLandscape
            };
        }

        private void InitializePdfRenderer()
        {
            // Remove old DataGridView
            panelGridContainer.Controls.Clear();

            _pdfRenderer = new PdfPreviewRenderer
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            panelGridContainer.Controls.Add(_pdfRenderer);
        }

        private void LoadPreviewData()
        {
            if (dataGridViewPreview == null) return;

            dataGridViewPreview.DataSource = null;

            var displayList = new BindingList<object>();
            int rowNumber = 1;

            foreach (var item in _displayItems)
            {
                displayList.Add(new
                {
                    RowNumber = rowNumber++,
                    item.Group,
                    item.Name,
                    item.Manufacturer,
                    item.Supplier,
                    item.Unit,
                    Price = item.Price.ToString("N2"),
                    item.Currency,
                    Quantity = item.Quantity.ToString(),
                    TotalValue = item.TotalValue.ToString("N2"),
                    Date = item.Date.ToString("dd.MM.yyyy")
                });
            }

            dataGridViewPreview.DataSource = displayList;
            dataGridViewPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewPreview.ReadOnly = true;
            dataGridViewPreview.AllowUserToAddRows = false;
            dataGridViewPreview.AllowUserToDeleteRows = false;
            dataGridViewPreview.AllowUserToOrderColumns = false;

            dataGridViewPreview.ScrollBars = ScrollBars.None; // We handle scrolling in container

            UpdateDataGridViewAppearance();
        }

        private void UpdateDataGridViewAppearance()
        {
            if (dataGridViewPreview == null) return;

            // Apply PDF-like styling
            dataGridViewPreview.BackgroundColor = Color.White;
            dataGridViewPreview.GridColor = Color.Silver;
            dataGridViewPreview.BorderStyle = BorderStyle.None;

            // Header styling
            dataGridViewPreview.EnableHeadersVisualStyles = false;
            dataGridViewPreview.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 102, 153);
            dataGridViewPreview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewPreview.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dataGridViewPreview.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Cell styling
            dataGridViewPreview.DefaultCellStyle.Font = new Font("Arial", 8);
            dataGridViewPreview.DefaultCellStyle.BackColor = Color.White;
            dataGridViewPreview.DefaultCellStyle.ForeColor = Color.Black;

            // Row headers
            dataGridViewPreview.RowHeadersVisible = false;

            // Selection styling
            dataGridViewPreview.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridViewPreview.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Adjust column widths based on orientation and zoom
            AdjustColumnWidthsForPdf();
        }

        private void AdjustColumnWidthsForPdf()
        {
            if (dataGridViewPreview == null || dataGridViewPreview.Columns.Count == 0) return;

            // Calculate available width based on zoom
            int availableWidth = (int)((IsLandscape ? A4_HEIGHT_MM : A4_WIDTH_MM) * MM_TO_INCH * RENDER_DPI * _zoomLevel) - 40; // Account for padding

            // PDF column ratios (same as in actual PDF generation)
            float[] columnRatios;
            if (IsLandscape)
            {
                columnRatios = new float[] { 0.5f, 1.0f, 1.5f, 1.2f, 1.5f, 0.8f, 0.8f, 0.6f, 0.8f, 1.0f, 0.8f };
            }
            else
            {
                columnRatios = new float[] { 0.4f, 0.8f, 1.2f, 1.0f, 1.2f, 0.6f, 0.6f, 0.5f, 0.6f, 0.8f, 0.6f };
            }

            float totalRatio = columnRatios.Sum();

            // Apply widths
            for (int i = 0; i < dataGridViewPreview.Columns.Count && i < columnRatios.Length; i++)
            {
                int width = (int)((columnRatios[i] / totalRatio) * availableWidth);
                dataGridViewPreview.Columns[i].Width = Math.Max(width, 30); // Minimum width 30px
            }

            // Last column fill
            if (dataGridViewPreview.Columns.Count > 0)
            {
                dataGridViewPreview.Columns[dataGridViewPreview.Columns.Count - 1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void UpdatePdfPreview()
        {
            if (!_isInitialized) return;

            try
            {
                float widthMM = IsLandscape ? A4_HEIGHT_MM : A4_WIDTH_MM;
                float heightMM = IsLandscape ? A4_WIDTH_MM : A4_HEIGHT_MM;
                int widthPixels = (int)(widthMM * MM_TO_INCH * RENDER_DPI);
                int heightPixels = (int)(heightMM * MM_TO_INCH * RENDER_DPI);

                panelPdfContent.Size = new Size(widthPixels, heightPixels);
                panelPdfBorder.Size = new Size(widthPixels + 20, heightPixels + 20);
                panelPdfSimulation.Size = new Size(widthPixels + 20, heightPixels + 20);
                panelPdfSimulation.Location = _pdfOffset;

                // Update labels
                string orientation = IsLandscape ? "Альбомна" : "Книжна";
                string dims = IsLandscape ? "297×210 мм" : "210×297 мм";
                lblPageSize.Text = $"A4 {orientation} ({dims}) - {_zoomLevel * 100:0}%";

                // Update renderer
                _pdfRenderer.Items = _displayItems;
                _pdfRenderer.Metadata = Metadata;
                _pdfRenderer.IncludeHeaders = chkIncludeHeaders.Checked;
                _pdfRenderer.ZoomLevel = _zoomLevel;
                _pdfRenderer.IsLandscape = IsLandscape;
                _pdfRenderer.Invalidate();

                UpdateZoomLabel();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdatePdfPreview error: {ex.Message}");
            }
        }

        private void UpdateZoomLabel()
        {
            if (lblZoomLevel != null)
            {
                lblZoomLevel.Text = $"{_zoomLevel * 100:0}%";
            }
            if (trackBarZoom != null)
            {
                trackBarZoom.Value = (int)(_zoomLevel * 100);
            }
        }

        // Mouse panning handlers
        private void panelPdfContainer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _lastMousePos = e.Location;
                panelPdfContainer.Cursor = Cursors.SizeAll;
            }
        }

        private void panelPdfContainer_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                int deltaX = e.X - _lastMousePos.X;
                int deltaY = e.Y - _lastMousePos.Y;

                _pdfOffset.X += deltaX;
                _pdfOffset.Y += deltaY;

                // Keep PDF within bounds (optional)
                _pdfOffset.X = Math.Max(0, Math.Min(_pdfOffset.X, panelPdfContainer.ClientSize.Width));
                _pdfOffset.Y = Math.Max(0, Math.Min(_pdfOffset.Y, panelPdfContainer.ClientSize.Height));

                panelPdfSimulation.Location = _pdfOffset;
                _lastMousePos = e.Location;
            }
        }

        private void panelPdfContainer_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = false;
                panelPdfContainer.Cursor = Cursors.Hand;
            }
        }

        // Mouse wheel zoom - FIXED VERSION
        private void PanelPdfContainer_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control || Control.ModifierKeys == Keys.Shift)
            {
                // Zoom in/out with mouse wheel
                float zoomChange = e.Delta > 0 ? 0.1f : -0.1f;
                SetZoomLevel(_zoomLevel + zoomChange);

                // In WinForms, we mark the event as handled by not passing it to parent controls
                // The event bubbles up, but we've done our handling
            }
        }

        // Zoom control handlers
        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            SetZoomLevel(_zoomLevel + 0.1f);
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            SetZoomLevel(_zoomLevel - 0.1f);
        }

        private void trackBarZoom_Scroll(object sender, EventArgs e)
        {
            SetZoomLevel(trackBarZoom.Value / 100f);
        }

        private void btnZoomFit_Click(object sender, EventArgs e)
        {
            // Fit to width
            float widthMM = IsLandscape ? A4_HEIGHT_MM : A4_WIDTH_MM;
            float targetWidth = panelPdfContainer.ClientSize.Width - 40; // Leave some margin
            float newZoom = (targetWidth / (widthMM * MM_TO_INCH * RENDER_DPI)) * 0.9f; // 90% of width

            SetZoomLevel(newZoom);
            CenterPdf();
        }

        private void SetZoomLevel(float newZoom)
        {
            // Clamp zoom level
            newZoom = Math.Max(0.1f, Math.Min(4.0f, newZoom));

            // Snap to common zoom levels
            foreach (float level in _zoomLevels)
            {
                if (Math.Abs(newZoom - level) < 0.05f)
                {
                    newZoom = level;
                    break;
                }
            }

            if (Math.Abs(_zoomLevel - newZoom) > 0.01f)
            {
                _zoomLevel = newZoom;
                UpdatePdfPreview();
            }
        }

        private void CenterPdf()
        {
            // Center PDF in container
            _pdfOffset = new Point(
                (panelPdfContainer.ClientSize.Width - panelPdfSimulation.Width) / 2,
                (panelPdfContainer.ClientSize.Height - panelPdfSimulation.Height) / 2
            );

            panelPdfSimulation.Location = _pdfOffset;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введіть заголовок документа.", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UpdateMetadata();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void UpdateMetadata()
        {
            Metadata.Title = txtTitle.Text;
            Metadata.Author = txtAuthor.Text;
            Metadata.Subject = txtSubject.Text;
            Metadata.Keywords = txtKeywords.Text;
            Metadata.IsLandscape = IsLandscape;
            IncludeHeaders = chkIncludeHeaders.Checked;
        }

        private void chkIncludeHeaders_CheckedChanged(object sender, EventArgs e)
        {
            IncludeHeaders = chkIncludeHeaders.Checked;
            UpdatePdfPreview(); // Just invalidate renderer
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            Metadata.Title = txtTitle.Text; // update live
            UpdatePdfPreview();
        }

        private void PdfExportPreviewForm_Load(object sender, EventArgs e)
        {
            // Mark as initialized
            _isInitialized = true;

            // Set up mouse wheel event
            panelPdfContainer.MouseWheel += PanelPdfContainer_MouseWheel;

            // Load preview data now that form is ready
            LoadPreviewData();
            UpdatePdfPreview();
            CenterPdf();
        }

        private void rdoLandscape_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoLandscape.Checked)
            {
                IsLandscape = true;
                UpdatePdfPreview();
                CenterPdf();
            }
        }

        private void rdoPortrait_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPortrait.Checked)
            {
                IsLandscape = false;
                UpdatePdfPreview();
                CenterPdf();
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (_isInitialized)
            {
                UpdatePdfPreview();
            }
        }
    }



    public class PdfPreviewRenderer : Panel
    {
        public List<Form1.ProductDisplayItem> Items { get; set; }
        public PdfMetadata Metadata { get; set; }
        public bool IncludeHeaders { get; set; } = true;
        public float ZoomLevel { get; set; } = 1.0f;
        public bool IsLandscape { get; set; } = true;

        // Constants matching iTextSharp and standard DPI
        private const float POINTS_PER_INCH = 72f;
        private const float RENDER_DPI = 96f; // What we simulate on screen
        private const float MM_TO_INCH = 0.0393701f;
        private static readonly float A4_WIDTH_MM = 210f;
        private static readonly float A4_HEIGHT_MM = 297f;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Items == null || Metadata == null) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Apply zoom uniformly
            g.ScaleTransform(ZoomLevel, ZoomLevel);

            // Compute printable area (PDF uses 25pt = ~8.8mm margins)
            float marginInches = 25f / POINTS_PER_INCH; // 25pt = 25/72 inch
            float marginPx = marginInches * RENDER_DPI;

            float contentWidthMm = IsLandscape ? A4_HEIGHT_MM : A4_WIDTH_MM;
            float contentHeightMm = IsLandscape ? A4_WIDTH_MM : A4_HEIGHT_MM;
            float contentWidthPx = contentWidthMm * MM_TO_INCH * RENDER_DPI;
            float contentHeightPx = contentHeightMm * MM_TO_INCH * RENDER_DPI;

            RectangleF printable = new RectangleF(
                marginPx, marginPx,
                contentWidthPx - 2 * marginPx,
                contentHeightPx - 2 * marginPx
            );

            DrawHeader(g, printable);
            DrawTable(g, printable);
        }

        private void DrawHeader(Graphics g, RectangleF printable)
        {
            // Font sizes in points → convert to pixels @96 DPI (px = pt * 96/72 = pt * 1.333)
            float titleFontSizePx = 16f * (RENDER_DPI / POINTS_PER_INCH);
            float infoFontSizePx = 10f * (RENDER_DPI / POINTS_PER_INCH);

            using (Font titleFont = new Font("Arial", titleFontSizePx, FontStyle.Bold))
            using (Font infoFont = new Font("Arial", infoFontSizePx))
            {
                // Title
                StringFormat sfCenter = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString(Metadata.Title, titleFont, Brushes.Black, new RectangleF(0, 0, printable.Width, 40), sfCenter);

                // Info line
                string info = $"Склад: {Metadata.WarehouseName}";
                if (!string.IsNullOrEmpty(Metadata.GroupFilter)) info += $" | Група: {Metadata.GroupFilter}";
                info += $" | Дата: {Metadata.ExportDate:dd.MM.yyyy HH:mm}";
                g.DrawString(info, infoFont, Brushes.Black, new RectangleF(0, 40, printable.Width, 25), sfCenter);

                // Separator
                g.DrawLine(Pens.Gray, 0, 70, printable.Width, 70);
            }
        }

        private void DrawTable(Graphics g, RectangleF printable)
        {
            float[] ratios = IsLandscape
                ? new float[] { 0.5f, 1.0f, 1.5f, 1.2f, 1.5f, 0.8f, 0.8f, 0.6f, 0.8f, 1.0f, 0.8f }
                : new float[] { 0.4f, 0.8f, 1.2f, 1.0f, 1.2f, 0.6f, 0.6f, 0.5f, 0.6f, 0.8f, 0.6f };

            float totalRatio = ratios.Sum();
            float[] colWidths = ratios.Select(r => r / totalRatio * printable.Width).ToArray();

            float y = 80;
            float rowHeight = IsLandscape ? 20 : 18;

            float headerFontSizePx = (IsLandscape ? 9 : 8) * (RENDER_DPI / POINTS_PER_INCH);
            float cellFontSizePx = (IsLandscape ? 8 : 7) * (RENDER_DPI / POINTS_PER_INCH);

            using (Font headerFont = new Font("Arial", headerFontSizePx, FontStyle.Bold))
            using (Font cellFont = new Font("Arial", cellFontSizePx))
            using (Brush headerBg = new SolidBrush(Color.FromArgb(51, 102, 153)))
            {
                // Headers
                if (IncludeHeaders)
                {
                    string[] headers = { "№ п/п", "Група", "Назва", "Виробник", "Постачальник", "Од. виміру", "Ціна", "Вал", "Кількість", "Вартість", "Дата" };
                    for (int i = 0; i < headers.Length; i++)
                    {
                        float x = colWidths.Take(i).Sum();
                        g.FillRectangle(headerBg, x, y, colWidths[i], rowHeight);
                        g.DrawString(headers[i], headerFont, Brushes.White,
                            new RectangleF(x, y, colWidths[i], rowHeight),
                            new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                    y += rowHeight;
                }

                // Rows
                foreach (var item in Items)
                {
                    var values = new object[]
                    {
                    item.RowNumber, item.Group, item.Name, item.Manufacturer, item.Supplier,
                    item.Unit, item.Price.ToString("N2"), item.Currency, item.Quantity,
                    item.TotalValue.ToString("N2"), item.Date.ToString("dd.MM.yyyy")
                    };

                    for (int i = 0; i < values.Length; i++)
                    {
                        float x = colWidths.Take(i).Sum();
                        StringAlignment align = StringAlignment.Near;
                        if (i == 0 || i == 8 || i == 9) align = StringAlignment.Far;
                        else if (i == 5 || i == 7) align = StringAlignment.Center;

                        g.DrawString(values[i].ToString(), cellFont, Brushes.Black,
                            new RectangleF(x, y, colWidths[i], rowHeight),
                            new StringFormat { Alignment = align, LineAlignment = StringAlignment.Center });
                    }
                    y += rowHeight;
                }
            }
        }
    }
}