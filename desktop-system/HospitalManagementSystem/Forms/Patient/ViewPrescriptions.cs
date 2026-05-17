using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using HospitalManagementSystem.Core;
using HospitalManagementSystem.Helpers;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Forms.Patient
{
    public partial class ViewPrescriptions : Form
    {
        public ViewPrescriptions()
        {
            InitializeComponent();
            DataGridHelper.Apply(dgvPrescriptions);

            // ID | doctor | date | time | disease | allergy
            DataGridHelper.SetColumnWidths(dgvPrescriptions,
                60,   // App ID
                120,  // Doctor
                110,  // Date
                80,   // Time
                -1,   // Disease — fills space
                150   // Allergies
            );

            LoadMyPrescriptions();
        }

        // ── Load Patient's Prescriptions ────────────────────────
        private async void LoadMyPrescriptions()
        {
            try
            {
                var result = await ApiClient.GetAsync<ApiResponse<List<Prescription>>>(
                        $"prescriptions?pid={SessionManager.PatientId}");

                if (result.Success)
                {
                    dgvPrescriptions.Rows.Clear();

                    lblCount.Text = $"Total Prescriptions: {result.Data.Count}";

                    foreach (var p in result.Data)
                    {
                        dgvPrescriptions.Rows.Add(
                            p.ID,
                            p.Doctor,
                            p.Appdate,
                            p.Apptime,
                            p.Disease,
                            p.Allergy
                        );

                        DataGridHelper.AutoFitColumns(dgvPrescriptions,minWidth: 60, maxWidth: 300);

                    }
                }
                else
                {
                    MessageBox.Show(result.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load prescriptions:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Row Selected — Show Full Prescription ───────────────
        private void dgvPrescriptions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPrescriptions.SelectedRows.Count == 0) return;

            var row = dgvPrescriptions.SelectedRows[0];
            int selectedID = int.Parse(row.Cells["colID"].Value?.ToString() ?? "0");

            // Fetch full prescription detail for this appointment ID
            LoadPrescriptionDetail(selectedID);

            // Fill quick-view fields
            txtAppID.Text = row.Cells["colID"].Value?.ToString();
            txtDoctor.Text = row.Cells["colDoctor"].Value?.ToString();
            txtDate.Text = row.Cells["colDate"].Value?.ToString();
            txtTime.Text = row.Cells["colTime"].Value?.ToString();
            txtDisease.Text = row.Cells["colDisease"].Value?.ToString();
            txtAllergy.Text = row.Cells["colAllergy"].Value?.ToString();
        }

        // ── Load Full Prescription Text ─────────────────────────
        private async void LoadPrescriptionDetail(int appId)
        {
            try
            {
                var result = await ApiClient.GetAsync<ApiResponse<Models.Prescription>>(
                    $"prescriptions/{appId}?pid={SessionManager.PatientId}");

                if (result.Success && result.Data != null)
                {
                    txtPrescription.Text = result.Data.PrescriptionText;
                }
                else
                {
                    txtPrescription.Text = "No prescription details found.";
                }
            }
            catch
            {
                txtPrescription.Text = "Could not load prescription.";
            }
        }

        // ── Print Prescription ──────────────────────────────────
        private string _printContent = "";

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAppID.Text))
            {
                MessageBox.Show("Please select a prescription to print.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ── Build printable content ────────────────────────
            _printContent =
                "════════════════════════════════════\r\n" +
                "     HOSPITAL MANAGEMENT SYSTEM     \r\n" +
                "════════════════════════════════════\r\n\r\n" +
                $"Patient    : {SessionManager.Username}\r\n" +
                $"Patient ID : {SessionManager.PatientId}\r\n\r\n" +
                $"Doctor     : Dr. {txtDoctor.Text}\r\n" +
                $"Date       : {txtDate.Text}\r\n" +
                $"Time       : {txtTime.Text}\r\n\r\n" +
                "────────────────────────────────────\r\n" +
                $"Disease    : {txtDisease.Text}\r\n" +
                $"Allergies  : {txtAllergy.Text}\r\n\r\n" +
                "PRESCRIPTION:\r\n" +
                $"{txtPrescription.Text}\r\n\r\n" +
                "────────────────────────────────────\r\n" +
                "      ** Keep this prescription **  \r\n" +
                "════════════════════════════════════\r\n";

            // ── Show preview dialog ────────────────────────────
            var printForm = new Form();
            printForm.Text = "Prescription Preview";
            printForm.Size = new System.Drawing.Size(520, 640);
            printForm.StartPosition = FormStartPosition.CenterParent;
            printForm.BackColor = System.Drawing.Color.White;

            var rtb = new RichTextBox();
            rtb.Text = _printContent;
            rtb.Font = new System.Drawing.Font("Courier New", 10F);
            rtb.ReadOnly = true;
            rtb.Dock = DockStyle.Fill;
            rtb.BorderStyle = BorderStyle.None;
            rtb.BackColor = System.Drawing.Color.White;

            // ── Print button inside preview ────────────────────
            var btnPrintNow = new Button();
            btnPrintNow.Text = "🖨  Send to Printer";
            btnPrintNow.Dock = DockStyle.Bottom;
            btnPrintNow.Height = 44;
            btnPrintNow.Font = new System.Drawing.Font("Roboto", 10F);
            btnPrintNow.BackColor = System.Drawing.Color.FromArgb(13, 71, 161);
            btnPrintNow.ForeColor = System.Drawing.Color.White;
            btnPrintNow.FlatStyle = FlatStyle.Flat;

            btnPrintNow.Click += (s, ev) =>
            {
                var pd = new PrintDocument();
                pd.PrintPage += PrintPage;

                var dlg = new PrintDialog();
                dlg.Document = pd;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pd.Print();
                }
            };

            printForm.Controls.Add(rtb);
            printForm.Controls.Add(btnPrintNow);
            printForm.ShowDialog();
        }

        // ── PrintDocument PagePrint Handler ────────────────────
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            // Split content into lines and draw each line
            string[] lines = _printContent.Split(
                new[] { "\r\n", "\n" }, StringSplitOptions.None);

            float yPos = e.MarginBounds.Top;
            float leftX = e.MarginBounds.Left;
            var font = new System.Drawing.Font("Courier New", 10F);
            float lineH = font.GetHeight(e.Graphics);

            foreach (string line in lines)
            {
                // Stop if we exceed page bounds
                if (yPos + lineH > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    break;
                }

                e.Graphics.DrawString(
                    line,
                    font,
                    System.Drawing.Brushes.Black,
                    leftX,
                    yPos);

                yPos += lineH;
            }
        }

        // ── Refresh ─────────────────────────────────────────────
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearDetail();
            LoadMyPrescriptions();
        }

        // ── Helpers ─────────────────────────────────────────────
        private void ClearDetail()
        {
            txtAppID.Text = "";
            txtDoctor.Text = "";
            txtDate.Text = "";
            txtTime.Text = "";
            txtDisease.Text = "";
            txtAllergy.Text = "";
            txtPrescription.Text = "";
            dgvPrescriptions.ClearSelection();
        }
    }
}