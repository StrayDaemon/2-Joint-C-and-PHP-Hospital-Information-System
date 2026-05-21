using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalManagementSystem.Helpers
{
    public static class DataGridHelper
    {
        // ════════════════════════════════════════════════════════
        //  Call this once per DataGridView in InitializeComponent
        //  or in the Form constructor after InitializeComponent()
        // ════════════════════════════════════════════════════════
        public static void Apply(DataGridView dgv,
                                 bool allowResize = true,
                                 bool alternateRows = true)
        {
            // ── Layout & Behavior ─────────────────────────────
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.ScrollBars = ScrollBars.Both;
            dgv.AllowUserToResizeColumns = allowResize;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible = false;
            dgv.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 38;
            dgv.RowTemplate.Height = 32;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(220, 220, 220);
            dgv.BorderStyle = BorderStyle.None;
            dgv.Cursor = Cursors.Hand;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ClipboardCopyMode =
                DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            // ── Column Header Style ───────────────────────────
            dgv.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(25, 118, 210);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font("Roboto", 9.5f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding =
                new Padding(8, 0, 0, 0);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(25, 118, 210);

            // ── Default Cell Style ────────────────────────────
            dgv.DefaultCellStyle.Font =
                new Font("Roboto", 9f, FontStyle.Regular);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(187, 222, 251);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(13, 71, 161);
            dgv.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            dgv.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            // ── Alternate Row Coloring ────────────────────────
            if (alternateRows)
            {
                dgv.AlternatingRowsDefaultCellStyle.BackColor =
                    Color.FromArgb(232, 240, 254);
                dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor =
                    Color.FromArgb(187, 222, 251);
                dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor =
                    Color.FromArgb(13, 71, 161);
            }

            // ── Background ────────────────────────────────────
            dgv.BackgroundColor = Color.White;

            // ── Hook into paint for sort indicator ────────────
            dgv.ColumnHeaderMouseClick += OnColumnHeaderClick;

            // ── Double-click to auto-fit that column ──────────
            dgv.ColumnDividerDoubleClick += OnColumnDividerDoubleClick;

            // ── Right-click context menu ──────────────────────
            AttachContextMenu(dgv);
        }

        // ════════════════════════════════════════════════════════
        //  Set column widths using a simple int[] array
        //  widths.Length must match dgv.Columns.Count
        //  Pass -1 for any column to auto-fill remaining space
        // ════════════════════════════════════════════════════════
        public static void SetColumnWidths(DataGridView dgv,
                                           params int[] widths)
        {
            if (widths.Length != dgv.Columns.Count) return;

            int fillIndex = -1;

            for (int i = 0; i < widths.Length; i++)
            {
                if (widths[i] == -1)
                {
                    fillIndex = i;
                    dgv.Columns[i].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    dgv.Columns[i].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.None;
                    dgv.Columns[i].Width = widths[i];
                }

                // Allow user to resize all columns
                dgv.Columns[i].Resizable =
                    DataGridViewTriState.True;
            }
        }

        // ════════════════════════════════════════════════════════
        //  Auto-fit ALL columns to their content
        //  Call after loading data into the grid
        // ════════════════════════════════════════════════════════
        public static void AutoFitColumns(DataGridView dgv,
                                          int minWidth = 60,
                                          int maxWidth = 300)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                // Measure header
                int headerWidth = TextRenderer.MeasureText(
                    col.HeaderText,
                    new Font("Roboto", 9.5f, FontStyle.Bold)).Width + 30;

                // Measure all cell content
                int cellMax = 0;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;
                    string val = row.Cells[col.Index].Value?.ToString() ?? "";
                    int w = TextRenderer.MeasureText(
                        val,
                        new Font("Roboto", 9f)).Width + 24;
                    if (w > cellMax) cellMax = w;
                }

                int best = Math.Max(headerWidth, cellMax);
                best = Math.Max(best, minWidth);
                best = Math.Min(best, maxWidth);

                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                col.Width = best;
            }
        }

        // ════════════════════════════════════════════════════════
        //  Highlight a row by color based on a cell value
        //  e.g. color pending rows orange, confirmed green
        // ════════════════════════════════════════════════════════
        public static void ColorRowsByStatus(
            DataGridView dgv,
            string columnName,
            string pendingValue = "⏳ Pending",
            string confirmedValue = "✅ Confirmed")
        {
            if (!dgv.Columns.Contains(columnName)) return;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                string val = row.Cells[columnName].Value?.ToString() ?? "";

                if (val == pendingValue)
                {
                    row.DefaultCellStyle.ForeColor =
                        Color.FromArgb(230, 81, 0);
                }
                else if (val == confirmedValue)
                {
                    row.DefaultCellStyle.ForeColor =
                        Color.FromArgb(27, 94, 32);
                }
            }
        }

        // ════════════════════════════════════════════════════════
        //  Sort column on header click
        // ════════════════════════════════════════════════════════
        private static void OnColumnHeaderClick(object sender,
            DataGridViewCellMouseEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            var col = dgv.Columns[e.ColumnIndex];

            ListSortDirection direction =
                col.HeaderCell.SortGlyphDirection ==
                SortOrder.Ascending
                    ? ListSortDirection.Descending
                    : ListSortDirection.Ascending;

            dgv.Sort(col, direction);
        }

        // ════════════════════════════════════════════════════════
        //  Double-click column divider → auto-fit that column
        // ════════════════════════════════════════════════════════
        private static void OnColumnDividerDoubleClick(object sender,
            DataGridViewColumnDividerDoubleClickEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            DataGridViewColumn col = dgv.Columns[e.ColumnIndex];

            // Measure header
            int headerW = TextRenderer.MeasureText(
                col.HeaderText,
                new Font("Roboto", 9.5f, FontStyle.Bold)).Width + 30;

            // Measure cells
            int cellMax = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                string val = row.Cells[e.ColumnIndex].Value?.ToString() ?? "";
                int w = TextRenderer.MeasureText(
                    val, new Font("Roboto", 9f)).Width + 24;
                if (w > cellMax) cellMax = w;
            }

            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            col.Width = Math.Max(headerW, cellMax);

            e.Handled = true;
        }

        // ════════════════════════════════════════════════════════
        //  Right-click context menu:
        //    • Auto-fit this column
        //    • Auto-fit all columns
        //    • Copy cell value
        //    • Copy row
        // ════════════════════════════════════════════════════════
        private static void AttachContextMenu(DataGridView dgv)
        {
            var menu = new ContextMenuStrip();
            menu.Font = new Font("Roboto", 9f);

            // ── Auto-fit this column ──────────────────────────
            var fitCol = new ToolStripMenuItem("↔  Auto-fit This Column");
            fitCol.Click += (s, e) =>
            {
                if (dgv.CurrentCell == null) return;
                var col = dgv.Columns[dgv.CurrentCell.ColumnIndex];

                int headerW = TextRenderer.MeasureText(
                    col.HeaderText,
                    new Font("Roboto", 9.5f, FontStyle.Bold)).Width + 30;

                int cellMax = 0;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;
                    string val = row.Cells[col.Index].Value?.ToString() ?? "";
                    int w = TextRenderer.MeasureText(
                        val, new Font("Roboto", 9f)).Width + 24;
                    if (w > cellMax) cellMax = w;
                }

                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                col.Width = Math.Max(headerW, cellMax);
            };

            // ── Auto-fit all columns ──────────────────────────
            var fitAll = new ToolStripMenuItem("⇔  Auto-fit All Columns");
            fitAll.Click += (s, e) => AutoFitColumns(dgv);

            // ── Separator ─────────────────────────────────────
            var sep1 = new ToolStripSeparator();

            // ── Copy cell ─────────────────────────────────────
            var copyCell = new ToolStripMenuItem("📋  Copy Cell Value");
            copyCell.Click += (s, e) =>
            {
                if (dgv.CurrentCell?.Value != null)
                    Clipboard.SetText(dgv.CurrentCell.Value.ToString());
            };

            // ── Copy row ──────────────────────────────────────
            var copyRow = new ToolStripMenuItem("📄  Copy Row");
            copyRow.Click += (s, e) =>
            {
                if (dgv.CurrentRow == null) return;

                var parts = new System.Collections.Generic.List<string>();
                foreach (DataGridViewCell cell in dgv.CurrentRow.Cells)
                    parts.Add(cell.Value?.ToString() ?? "");

                Clipboard.SetText(string.Join("\t", parts));
            };

            // ── Separator ─────────────────────────────────────
            var sep2 = new ToolStripSeparator();

            // ── Reset column widths ───────────────────────────
            var reset = new ToolStripMenuItem("↺  Reset Column Widths");
            reset.Click += (s, e) => AutoFitColumns(dgv);

            menu.Items.AddRange(new ToolStripItem[]
            {
                fitCol, fitAll,
                sep1,
                copyCell, copyRow,
                sep2,
                reset
            });

            dgv.ContextMenuStrip = menu;
        }
    }
}